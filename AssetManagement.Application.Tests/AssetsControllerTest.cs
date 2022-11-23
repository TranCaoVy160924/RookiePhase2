using AssetManagement.Application.Controllers;
using AssetManagement.Contracts.Asset.Request;
using AssetManagement.Contracts.Asset.Response;
using AssetManagement.Contracts.AutoMapper;
using AssetManagement.Data.EF;
using AssetManagement.Domain.Enums.Asset;
using AssetManagement.Domain.Models;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AssetManagement.Application.Tests.TestHelper.ConverterFromIActionResult;
using Xunit;

namespace AssetManagement.Application.Tests
{
    public class AssetsControllerTest
    {
        private readonly DbContextOptions _options;
        private readonly AssetManagementDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private List<Asset> _assets;

        public AssetsControllerTest()
        {
            // Create InMemory dbcontext options
            _options = new DbContextOptionsBuilder<AssetManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "AssetTestDb").Options;

            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new UserProfile())).CreateMapper();

            // Create InMemory dbcontext with options
            _context = new AssetManagementDbContext(_options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        #region DeleteAsset
        [Fact]
        public async Task DeleteAsset_Success_ReturnDeletedAsset()
        {
            // Arrange 
            AssetsController assetController = new AssetsController(_context, _mapper);
            var deletedAsset = _mapper
                .Map<DeleteAssetReponse>(await _context.Assets
                    .Where(a => a.Id == 1)
                    .FirstOrDefaultAsync());
            deletedAsset.IsDeleted = true;

            // Act 
            var result = await assetController.DeleteAsset(1);

            string resultObject = ConvertOkObject<DeleteAssetReponse>(result);
            string expectedObject = JsonConvert.SerializeObject(deletedAsset);

            // Assert
            Assert.Equal(resultObject, expectedObject);
        }

        [Fact]
        public async Task DeleteAsset_Invalid_ReturnBadRequest()
        {
            // Arrange 
            AssetsController assetController = new AssetsController(_context, _mapper);

            // Act 
            var result = await assetController.DeleteAsset(2);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();

        }
        #endregion

        #region GetList
        [Fact]
        public async Task GetList_ForDefault()
        {
            // Arrange 
            AssetsController assetController = new AssetsController(_context, _mapper);

            // Act 
            var result = await assetController.Get(1, 2);

            var query = _context.Assets.Include(x => x.Category).OrderBy(x => x.Name);

            var list = StaticFunctions<Asset>.Paging(query, 1, 2);

            var expected = _mapper.Map <List<ViewListAssets_AssetResponse>>(list);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListAssets_ListResponse)okobjectResult.Value;

            var assetsList = resultValue.Assets;

            var isSorted = assetsList.SequenceEqual(expected);
            // Assert
            Assert.True(isSorted);
            Assert.Equal(assetsList.Count(), expected.Count());
        }

        [Fact]
        public async Task GetList_SearchString_WithData()
        {
            // Arrange 
            AssetsController assetController = new AssetsController(_context, _mapper);

            var searchString = "top 1";

            // Act 
            var result = await assetController.Get(1, 2, searchString);

            var query = _context.Assets.Include(x => x.Category).Where(x=>x.Name.Contains(searchString) || x.AssetCode.Contains(searchString)).OrderBy(x => x.Name);

            var list = StaticFunctions<Asset>.Paging(query, 1, 2);

            var expected = _mapper.Map<List<ViewListAssets_AssetResponse>>(list);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListAssets_ListResponse)okobjectResult.Value;

            var assetsList = resultValue.Assets;

            var isSorted = assetsList.SequenceEqual(expected);
            // Assert
            Assert.True(isSorted);
            Assert.Equal(assetsList.Count(), expected.Count());
        }

        [Fact]
        public async Task GetList_SearchString_WithOutData()
        {
            // Arrange 
            AssetsController assetController = new AssetsController(_context, _mapper);

            var searchString = "Nash 1";

            // Act 
            var result = await assetController.Get(1, 2, searchString);

            var query = _context.Assets.Include(x => x.Category).Where(x => x.Name.Contains(searchString) || x.AssetCode.Contains(searchString)).OrderBy(x => x.Name);

            var list = StaticFunctions<Asset>.Paging(query, 1, 2);

            var expected = _mapper.Map<List<ViewListAssets_AssetResponse>>(list);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListAssets_ListResponse)okobjectResult.Value;

            var assetsList = resultValue.Assets;

            var isSorted = assetsList.SequenceEqual(expected);
            // Assert
            Assert.True(isSorted);
            Assert.Equal(assetsList.Count(), expected.Count());
        }

        [Fact]
        public async Task GetList_FilterState()
        {
            // Arrange 
            AssetsController assetController = new AssetsController(_context, _mapper);
            var state = (int)AssetManagement.Domain.Enums.Asset.State.Available;
            // Act 
            var result = await assetController.Get(1, 2,"","",state.ToString());

            var query = _context.Assets.Include(x => x.Category).Where(x=>(int)x.State == state).OrderBy(x => x.Name);

            var list = StaticFunctions<Asset>.Paging(query, 1, 2);

            var expected = _mapper.Map<List<ViewListAssets_AssetResponse>>(list);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListAssets_ListResponse)okobjectResult.Value;

            var assetsList = resultValue.Assets;

            var isSorted = assetsList.SequenceEqual(expected);
            // Assert
            Assert.True(isSorted);
            Assert.Equal(assetsList.Count(), expected.Count());
        }

        [Fact]
        public async Task GetList_ForDefaultSorted()
        {
            // Arrange 
            AssetsController assetController = new AssetsController(_context, _mapper);

            var sortType = "id";
            // Act 
            var result = await assetController.Get(1, 2, "", "", "", sortType);

            var query = _context.Assets.Include(x => x.Category).OrderBy(x => x.Id);

            var list = StaticFunctions<Asset>.Paging(query, 1, 2);

            var expected = _mapper.Map<List<ViewListAssets_AssetResponse>>(list);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListAssets_ListResponse)okobjectResult.Value;

            var assetsList = resultValue.Assets;

            var isSorted = assetsList.SequenceEqual(expected);
            // Assert
            Assert.Equal(assetsList.Count(), expected.Count());
            Assert.True(isSorted);
        }

        [Fact]
        public async Task GetList_ForDefaultSortedByCode()
        {
            // Arrange 
            AssetsController assetController = new AssetsController(_context, _mapper);

            var sortType = "assetCode";
            // Act 
            var result = await assetController.Get(1, 2, "", "", "", sortType);

            var query = _context.Assets.Include(x => x.Category).OrderBy(x => x.AssetCode);

            var list = StaticFunctions<Asset>.Paging(query, 1, 2);

            var expected = _mapper.Map<List<ViewListAssets_AssetResponse>>(list);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListAssets_ListResponse)okobjectResult.Value;

            var assetsList = resultValue.Assets;

            var isSorted = assetsList.SequenceEqual(expected);
            // Assert
            Assert.Equal(assetsList.Count(), expected.Count());
            Assert.True(isSorted);
        }       
        
        [Fact]
        public async Task GetList_ForDefaultSortedByState()
        {
            // Arrange 
            AssetsController assetController = new AssetsController(_context, _mapper);

            var sortType = "state";
            // Act 
            var result = await assetController.Get(1, 2, "", "", "", sortType);

            var query = _context.Assets.Include(x => x.Category).OrderBy(x => x.State);

            var list = StaticFunctions<Asset>.Paging(query, 1, 2);

            var expected = _mapper.Map<List<ViewListAssets_AssetResponse>>(list);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListAssets_ListResponse)okobjectResult.Value;

            var assetsList = resultValue.Assets;

            var isSorted = assetsList.SequenceEqual(expected);
            // Assert
            Assert.Equal(assetsList.Count(), expected.Count());
            Assert.True(isSorted);
        }        
        
        [Fact]
        public async Task GetList_ForDefaultSortedByName()
        {
            // Arrange 
            AssetsController assetController = new AssetsController(_context, _mapper);

            var sortType = "name";
            // Act 
            var result = await assetController.Get(1, 2, "", "", "", sortType);

            var query = _context.Assets.Include(x => x.Category).OrderBy(x => x.Name);

            var list = StaticFunctions<Asset>.Paging(query, 1, 2);

            var expected = _mapper.Map<List<ViewListAssets_AssetResponse>>(list);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListAssets_ListResponse)okobjectResult.Value;

            var assetsList = resultValue.Assets;

            var isSorted = assetsList.SequenceEqual(expected);
            // Assert
            Assert.Equal(assetsList.Count(), expected.Count());
            Assert.True(isSorted);
        }

        [Fact]
        public async Task GetList_ForDefaultSortedDesc()
        {
            // Arrange 
            AssetsController assetController = new AssetsController(_context, _mapper);

            var sortType = "id";
            // Act 
            var result = await assetController.Get(1, 2, "", "", "", sortType, "DESC");

            var query = _context.Assets.Include(x => x.Category).OrderByDescending(x => x.Id);

            var list = StaticFunctions<Asset>.Paging(query, 1, 2);

            var expected = _mapper.Map<List<ViewListAssets_AssetResponse>>(list);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListAssets_ListResponse)okobjectResult.Value;

            var assetsList = resultValue.Assets;

            var isSorted = assetsList.SequenceEqual(expected);
            // Assert
            Assert.True(isSorted);
            Assert.Equal(assetsList.Count(), expected.Count());
        }

        [Fact]
        public async Task GetList_ForDefault_InvalidPaging()
        {
            // Arrange 
            AssetsController assetController = new AssetsController(_context, _mapper);

            // Act 
            var result = await assetController.Get(-1, 2);

            var query = _context.Assets.Include(x => x.Category).OrderBy(x => x.Name);

            var list = StaticFunctions<Asset>.Paging(query, -1, 2);

            var expected = _mapper.Map<List<ViewListAssets_AssetResponse>>(list);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListAssets_ListResponse)okobjectResult.Value;

            var assetsList = resultValue.Assets;

            var isSorted = assetsList.SequenceEqual(expected);
            // Assert
            Assert.True(isSorted);
            Assert.Equal(assetsList.Count(), expected.Count());
        }
        #endregion
    }
}
