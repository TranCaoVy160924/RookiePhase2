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
    public class AssetControllerTest
    {
        private readonly DbContextOptions _options;
        private readonly AssetManagementDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private List<Asset> _assets;

        public AssetControllerTest()
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
            AssetController assetController = new AssetController(_context, _mapper);
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
            AssetController assetController = new AssetController(_context, _mapper);

            // Act 
            var result = await assetController.DeleteAsset(2);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();

        }
        #endregion
    }
}
