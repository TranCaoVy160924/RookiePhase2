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
using AssetManagement.Contracts.Asset.Request;
using AssetManagement.Application.Tests.TestHelper;
using AssetManagement.Contracts.Common;

#nullable disable
namespace AssetManagement.Application.Tests
{
    public class AssetsControllerTest : IDisposable
    {
        private readonly DbContextOptions _options;
        private readonly AssetManagementDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private List<Asset> _assets;
        private List<Category> _categories;

        public AssetsControllerTest()
        {
            // Create InMemory dbcontext options
            _options = new DbContextOptionsBuilder<AssetManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "AssetTestDb").Options;

            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new AssetProfile())).CreateMapper();

            // Create InMemory dbcontext with options
            _context = new AssetManagementDbContext(_options);
            _context.Database.EnsureDeleted();
            SeedData();
        }

        #region CreateAsset
        //[Fact]
        //public async Task CreateAsset_SuccessAsync()
        //{
        //    //ARRANGE
        //    CreateAssetRequest request = new()
        //    {
        //        CategoryId = 1,
        //        Name = "Laptop 21",
        //        Specification = "This is laptop #21",
        //        InstalledDate = DateTime.Now,
        //        State = Domain.Enums.Asset.State.Available
        //    };

        //    AssetsController controller = new(_context, _mapper);

        //    //ACT
        //    IActionResult response = await controller.CreateAssetAsync(request);
        //    object result = ((ObjectResult)response).Value;
        //    Asset newAsset = _context.Assets.LastOrDefault();

        //    //ASSERT
        //    Assert.NotNull(response);
        //    Assert.IsType<SuccessResponseResult<string>>(result);
        //    Assert.Equal("Create Asset sucessfully", ((SuccessResponseResult<string>)result).Result);
        //    Assert.Equal(newAsset.Name, request.Name);
        //    Assert.Equal("LT000005", newAsset.AssetCode);
        //    Assert.Equivalent(newAsset.Category, _categories[0]);
        //}

        //[Fact]
        //public async Task CreateAsset_BadRequest_InvalidCategoryAsync()
        //{
        //    //ARRANGE
        //    CreateAssetRequest request = new()
        //    {
        //        CategoryId = -1,
        //        Name = "Laptop 21",
        //        Specification = "This is laptop #21",
        //        InstalledDate = DateTime.Now,
        //        State = Domain.Enums.Asset.State.Available
        //    };

        //    AssetsController controller = new(_context, _mapper);

        //    //ACT
        //    IActionResult response = await controller.CreateAssetAsync(request);
        //    var result = (response as ObjectResult).Value;

        //    //ASSERT
        //    Assert.NotNull(response);
        //    Assert.IsType<ErrorResponseResult<string>>(result);
        //    Assert.False(((ErrorResponseResult<string>)result).IsSuccessed);
        //    Assert.Equal("Invalid Category", ((ErrorResponseResult<string>)result).Message);
        //}
        #endregion

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
            var result = await assetController.DeleteAsset(_assets.Count + 99);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();

        }
        #endregion

        #region DataSeed
        private void SeedData()
        {
            _context.Database.EnsureDeleted();
            #region Create some Categories
            _categories = new()
            {
                new (){Name = "Laptop", Prefix = "LT", IsDeleted = false },
                new (){Name = "Monitor", Prefix = "MO", IsDeleted = false },
                new (){Name = "Keyboard", Prefix = "KB", IsDeleted = false },
            };
            #endregion
            #region Create some Laptops
            _assets = new();
            //Create some laptops
            for (int i = 0; i < 4; i++)
            {
                _assets.Add(new()
                {
                    Name = $"Laptop {i}",
                    AssetCode = $"LT00000{i}",
                    Specification = $"This is laptop #{i}",
                    InstalledDate = DateTime.Now.AddDays(-i),
                    Category = _categories[0],
                    State = Domain.Enums.Asset.State.Available,
                    IsDeleted = false
                });
            }
            //Create some Monitor
            for (int i = 0; i < 4; i++)
            {
                _assets.Add(new()
                {
                    Name = $"Monitor {i}",
                    AssetCode = $"MO00000{i}",
                    Specification = $"This is monitor #{i}",
                    InstalledDate = DateTime.Now.AddDays(-i),
                    Category = _categories[1],
                    State = Domain.Enums.Asset.State.Available,
                    IsDeleted = false
                });
            }
            //Create some Keyboards
            for (int i = 0; i < 4; i++)
            {
                _assets.Add(new()
                {
                    Name = $"Keyboard {i}",
                    AssetCode = $"KB00000{i}",
                    Specification = $"This is keyboard #{i}",
                    InstalledDate = DateTime.Now.AddDays(-i),
                    Category = _categories[0],
                    State = Domain.Enums.Asset.State.Available,
                    IsDeleted = false
                });
            }
            #endregion
            _context.Categories.AddRange(_categories);
            _context.Assets.AddRange(_assets);
            _context.SaveChanges();
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

            var query = _context.Assets
                .Include(x => x.Category)
                .Where(x=>!x.IsDeleted)
                .OrderBy(x => x.Name);

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

            var query = _context.Assets.Include(x => x.Category)
                .Where(x=>(x.Name.Contains(searchString) || x.AssetCode.Contains(searchString))
                    && !x.IsDeleted)
                .OrderBy(x => x.Name);

            var list = StaticFunctions<Asset>.Paging(query, 1, 2);

            var expected = JsonConvert.SerializeObject(_mapper.Map<List<ViewListAssets_AssetResponse>>(list));

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListAssets_ListResponse)okobjectResult.Value;

            var assetsList = JsonConvert.SerializeObject(resultValue.Assets);

            var isSorted = assetsList.SequenceEqual(expected);
            Assert.True(isSorted);
            //Assert.Equal(expected, assetsList);
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

            var query = _context.Assets
                .Include(x => x.Category)
                .Where(x => (x.Name.Contains(searchString) || x.AssetCode.Contains(searchString))
                    && !x.IsDeleted)
                .OrderBy(x => x.Name);

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

            var query = _context.Assets
                .Include(x => x.Category)
                .Where(x=>(int)x.State == state && !x.IsDeleted)
                .OrderBy(x => x.Name);

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

            var query = _context.Assets
                .Include(x => x.Category)
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.Id);

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

            var query = _context.Assets
                .Include(x => x.Category)
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.AssetCode);

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

            var query = _context.Assets
                .Include(x => x.Category)
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.State);

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

            var query = _context.Assets
                .Include(x => x.Category)
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.Name);

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

            var query = _context.Assets
                .Include(x => x.Category)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.Id);

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

            var query = _context.Assets
                .Include(x => x.Category)
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.Name);

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

        //Clean up after tests
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
