﻿using AssetManagement.Application.Controllers;
using AssetManagement.Contracts.Common;
using AssetManagement.Contracts.Report.Response;
using AssetManagement.Data.EF;
using AssetManagement.Domain.Models;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AssetManagement.Application.Tests
{
    public class ReportControllerTest : IAsyncDisposable
    {
        private readonly DbContextOptions _options;
        private readonly AssetManagementDbContext _context;
        private List<Asset> _assets;
        private List<Category> _categories;

        public ReportControllerTest()
        {
            // Create InMemory dbcontext options
            _options = new DbContextOptionsBuilder<AssetManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "AssetTestDb").Options;

            // Create InMemory dbcontext with options
            _context = new AssetManagementDbContext(_options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        #region Get Report
        [Fact]
        public async Task GetReport_Ok()
        {
            // Arrange
            ReportController reportController = new ReportController(_context);
            IQueryable<Category> categories = _context.Categories;

            // Act
            var result = await reportController.GetReport();
            var okResult = result.Result as OkObjectResult;
            SuccessResponseResult<ViewListPageResult< ViewReportResponse>> data = okResult.Value 
                as SuccessResponseResult<ViewListPageResult<ViewReportResponse>>;


            // Assert
            Assert.NotNull(data);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(5, data.Result.Data.Where(x => x.Category == "Laptop")
                    .ToList().ElementAt(0).Total);
            Assert.Equal(5, data.Result.Data.Where(x => x.Category == "Monitor")
                    .ToList().ElementAt(0).Total);
        }

        [Fact]
        public async Task GetReport_SortDESC_Ok()
        {
            // Arrange
            string sortType = "category";
            ReportController reportController = new ReportController(_context);
            IQueryable<Category> categories = _context.Categories;

            // Act
            var result = await reportController.GetReport(sortType, "DESC");
            var okResult = result.Result as OkObjectResult;
            SuccessResponseResult<ViewListPageResult<ViewReportResponse>> data = okResult.Value
                as SuccessResponseResult<ViewListPageResult<ViewReportResponse>>;
            var sortedData = data.Result.Data.ToList();


            // Assert
            Assert.NotNull(data);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(sortedData.ElementAt(2).Category, "Laptop");
            Assert.Equal(sortedData.ElementAt(1).Category, "Monitor");
            Assert.Equal(sortedData.ElementAt(0).Category, "Personal Computer");
        }

        [Fact]
        public async Task GetReport_SortByCategory_Ok()
        {
            // Arrange
            string sortType = "category";
            ReportController reportController = new ReportController(_context);
            IQueryable<Category> categories = _context.Categories;

            // Act
            var result = await reportController.GetReport(sortType, "ASC");
            var okResult = result.Result as OkObjectResult;
            SuccessResponseResult<ViewListPageResult<ViewReportResponse>> data = okResult.Value
                as SuccessResponseResult<ViewListPageResult<ViewReportResponse>>;
            var sortedData = data.Result.Data.ToList();


            // Assert
            Assert.NotNull(data);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(sortedData.ElementAt(0).Category, "Laptop");
            Assert.Equal(sortedData.ElementAt(1).Category, "Monitor");
            Assert.Equal(sortedData.ElementAt(2).Category, "Personal Computer");
        }

        [Fact]
        public async Task GetReport_SortByTotal_Ok()
        {
            // Arrange
            string sortType = "total";
            ReportController reportController = new ReportController(_context);

            // Act
            var result = await reportController.GetReport(sortType, "ASC");
            var okResult = result.Result as OkObjectResult;
            SuccessResponseResult<ViewListPageResult<ViewReportResponse>> data = okResult.Value
                as SuccessResponseResult<ViewListPageResult<ViewReportResponse>>;
            var sortedData = data.Result.Data.ToList();


            // Assert
            Assert.NotNull(data);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(sortedData.ElementAt(0).Category, "Personal Computer");
            Assert.Equal(sortedData.ElementAt(1).Category, "Monitor");
            Assert.Equal(sortedData.ElementAt(2).Category, "Laptop");
        }

        [Fact]
        public async Task GetReport_SortByAssigned_Ok()
        {
            // Arrange
            string sortType = "assigned";
            ReportController reportController = new ReportController(_context);

            // Act
            var result = await reportController.GetReport(sortType, "ASC");
            var okResult = result.Result as OkObjectResult;
            SuccessResponseResult<ViewListPageResult<ViewReportResponse>> data = okResult.Value
                as SuccessResponseResult<ViewListPageResult<ViewReportResponse>>;
            var sortedData = data.Result.Data.ToList();


            // Assert
            Assert.NotNull(data);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(sortedData.ElementAt(0).Category, "Monitor");
            Assert.Equal(sortedData.ElementAt(1).Category, "Laptop");
            Assert.Equal(sortedData.ElementAt(2).Category, "Personal Computer");
        }

        [Fact]
        public async Task GetReport_SortByAvailable_Ok()
        {
            // Arrange
            string sortType = "available";
            ReportController reportController = new ReportController(_context);

            // Act
            var result = await reportController.GetReport(sortType, "ASC");
            var okResult = result.Result as OkObjectResult;
            SuccessResponseResult<ViewListPageResult<ViewReportResponse>> data = okResult.Value
                as SuccessResponseResult<ViewListPageResult<ViewReportResponse>>;
            var sortedData = data.Result.Data.ToList();


            // Assert
            Assert.NotNull(data);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(sortedData.ElementAt(0).Category, "Monitor");
            Assert.Equal(sortedData.ElementAt(1).Category, "Personal Computer");
            Assert.Equal(sortedData.ElementAt(2).Category, "Laptop");
        }

        [Fact]
        public async Task GetReport_SortByNotAvailable_Ok()
        {
            // Arrange
            string sortType = "notAvailable";
            ReportController reportController = new ReportController(_context);

            // Act
            var result = await reportController.GetReport(sortType, "ASC");
            var okResult = result.Result as OkObjectResult;
            SuccessResponseResult<ViewListPageResult<ViewReportResponse>> data = okResult.Value
                as SuccessResponseResult<ViewListPageResult<ViewReportResponse>>;
            var sortedData = data.Result.Data.ToList();


            // Assert
            Assert.NotNull(data);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(sortedData.ElementAt(0).Category, "Laptop");
            Assert.Equal(sortedData.ElementAt(1).Category, "Personal Computer");
            Assert.Equal(sortedData.ElementAt(2).Category, "Monitor");
        }

        [Fact]
        public async Task GetReport_SortByWaitingForRecycling_Ok()
        {
            // Arrange
            string sortType = "waitingForRecycling";
            ReportController reportController = new ReportController(_context);

            // Act
            var result = await reportController.GetReport(sortType, "ASC");
            var okResult = result.Result as OkObjectResult;
            SuccessResponseResult<ViewListPageResult<ViewReportResponse>> data = okResult.Value
                as SuccessResponseResult<ViewListPageResult<ViewReportResponse>>;
            var sortedData = data.Result.Data.ToList();


            // Assert
            Assert.NotNull(data);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(sortedData.ElementAt(0).Category, "Monitor");
            Assert.Equal(sortedData.ElementAt(1).Category, "Laptop");
            Assert.Equal(sortedData.ElementAt(2).Category, "Personal Computer");
        }

        [Fact]
        public async Task GetReport_SortByRecycled_Ok()
        {
            // Arrange
            string sortType = "recycled";
            ReportController reportController = new ReportController(_context);

            // Act
            var result = await reportController.GetReport(sortType, "ASC");
            var okResult = result.Result as OkObjectResult;
            SuccessResponseResult<ViewListPageResult<ViewReportResponse>> data = okResult.Value
                as SuccessResponseResult<ViewListPageResult<ViewReportResponse>>;
            var sortedData = data.Result.Data.ToList();


            // Assert
            Assert.NotNull(data);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(sortedData.ElementAt(0).Category, "Monitor");
            Assert.Equal(sortedData.ElementAt(1).Category, "Laptop");
            Assert.Equal(sortedData.ElementAt(2).Category, "Personal Computer");
        }
        #endregion

        async ValueTask IAsyncDisposable.DisposeAsync()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.DisposeAsync();
        }
    }
}
