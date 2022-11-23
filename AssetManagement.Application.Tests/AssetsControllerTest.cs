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

        #region UpdateAsset
        [Fact]
        public async Task UpdateAsset_NotFound_ReturnBadRequest()
        {
            // Arrange 
            DateTime now = DateTime.Now;
            UpdateAssetRequest request = new UpdateAssetRequest
            {
                Name = "Laptop Asus Rog Strix",
                Specification = "Core 100, 1000 GB RAM, 200 50 GB HDD, Window 200",
                InstalledDate = now,
                State = State.NotAvailable
            };

            AssetsController assetController = new AssetsController(_context, _mapper);

            // Act 
            var result = await assetController.Update(0, request);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task Update_Success_ReturnUpdatedAsset()
        {
            // Arrange 
            DateTime now = DateTime.Now;
            UpdateAssetRequest request = new UpdateAssetRequest
            {
                Name = "Laptop Asus Rog Strix",
                Specification = "Core 100, 1000 GB RAM, 200 50 GB HDD, Window 200",
                InstalledDate = now,
                State = State.NotAvailable
            };

            AssetsController assetController = new AssetsController(_context, _mapper);

            // Act 
            var response = await assetController.Update(1, request);
            var result = ConvertOkObject<UpdateAssetResponse>(response);
            var expected = JsonConvert.SerializeObject(new UpdateAssetResponse
            {
                Id = 1,
                AssetCode = "LA10000" + 1,
                Name = "Laptop Asus Rog Strix",
                Specification = "Core 100, 1000 GB RAM, 200 50 GB HDD, Window 200",
                InstalledDate = now,
                State = State.NotAvailable,
                IsDeleted = false,
            });

            // Assert
            Assert.Equal(expected, result);
        }
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
            var result = await assetController.DeleteAsset(2);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();

        }
        #endregion
    }
}
