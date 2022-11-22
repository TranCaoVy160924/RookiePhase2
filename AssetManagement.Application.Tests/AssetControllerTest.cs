using AssetManagement.Application.Controllers;
using AssetManagement.Contracts.Asset.Request;
using AssetManagement.Data.EF;
using AssetManagement.Domain.Enums.Asset;
using AssetManagement.Domain.Models;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // Create InMemory dbcontext with options
            _context = new AssetManagementDbContext(_options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        #region DeleteAsset
        [Fact]
        public async Task DeleteAsset_Success_ReturnOkResult()
        {
            // Arrange 
            DeleteAssetRequest request = new DeleteAssetRequest
            {
                Id = 1,
            };
            AssetController assetController = new AssetController(_context);

            // Act 
            StatusCodeResult result = (StatusCodeResult)await assetController.DeleteAsset(request);
            int expectedResult = 200;

            // Assert
            Assert.Equal(expectedResult, result.StatusCode);

        }

        [Fact]
        public async Task DeleteAsset_Invalid_ReturnBadRequest()
        {
            // Arrange 
            DeleteAssetRequest request = new DeleteAssetRequest
            {
                Id = 2,
            };
            AssetController assetController = new AssetController(_context);

            // Act 
            var result = await assetController.DeleteAsset(request);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();

        }
        #endregion
    }
}
