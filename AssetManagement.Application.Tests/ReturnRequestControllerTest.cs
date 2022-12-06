using AssetManagement.Application.Controllers;
using AssetManagement.Contracts.Assignment.Response;
using AssetManagement.Contracts.Common;
using AssetManagement.Contracts.AutoMapper;
using AssetManagement.Data.EF;
using AssetManagement.Domain.Enums.Asset;
using AssetManagement.Domain.Models;
using AutoMapper;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Xunit;
using Newtonsoft.Json;
using static AssetManagement.Application.Tests.TestHelper.ConverterFromIActionResult;
using FluentAssertions;
using AssetManagement.Contracts.Assignment.Request;
using AssetManagement.Application.Tests.TestHelper;
using Microsoft.AspNetCore.Identity;

namespace AssetManagement.Application.Tests
{
    public class ReturnRequestControllerTest
    {
        private readonly DbContextOptions _options;
        private readonly AssetManagementDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly UserManager<AppUser> _userManager;

        public ReturnRequestControllerTest()
        {
            // Create InMemory dbcontext options
            _options = new DbContextOptionsBuilder<AssetManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "AssignmentTestDb").Options;

            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new AssignmentProfile())).CreateMapper();

            // Create InMemory dbcontext with options
            _context = new AssetManagementDbContext(_options);
            _context.Database.EnsureDeleted();
            //SeedData();
            _context.Database.EnsureCreated();
        }

        #region GetList
        [Fact]
        public async Task GetList_ForDefault()
        {
            // Arrange 
            ReturnRequestController returnRequestController = new ReturnRequestController(_context, _mapper);

            // Act 
            var result = await returnRequestController.Get(1, 2);

            var list = _context.Assignments
                .Where(x => !x.IsDeleted)
                .Select(x => new ViewListAssignmentResponse
                {
                    Id = x.Id,
                    AssetCode = x.Asset.AssetCode,
                    AssetName = x.Asset.Name,
                    AssignedTo = x.AssignedToAppUser.UserName,
                    AssignedBy = x.AssignedByAppUser.UserName,
                    AssignedDate = x.AssignedDate,
                    State = x.State,
                })
                .OrderBy(x => x.Id);

            var expected = StaticFunctions<ViewListAssignmentResponse>.Paging(list, 1, 2);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListPageResult<ViewListAssignmentResponse>)okobjectResult.Value;

            var assignmentsList = resultValue.Data;

            var isSorted = assignmentsList.SequenceEqual(expected);
            // Assert
            Assert.True(isSorted);
            Assert.Equal(assignmentsList.Count(), expected.Count());
        }

        [Fact]
        public async Task GetList_SearchString_WithData()
        {
            // Arrange 
            ReturnRequestController returnRequestController = new ReturnRequestController(_context, _mapper);
            var searchString = "SD";
            // Act 
            var result = await returnRequestController.Get(1, 2, searchString);

            var list = _context.Assignments
                .Where(x => !x.IsDeleted && (x.Asset.Name.Contains(searchString) || x.Asset.AssetCode.Contains(searchString)))
                .Select(x => new ViewListAssignmentResponse
                {
                    Id = x.Id,
                    AssetCode = x.Asset.AssetCode,
                    AssetName = x.Asset.Name,
                    AssignedTo = x.AssignedToAppUser.UserName,
                    AssignedBy = x.AssignedByAppUser.UserName,
                    AssignedDate = x.AssignedDate,
                    State = x.State,
                })
                .OrderBy(x => x.Id);

            var expected = JsonConvert.SerializeObject(StaticFunctions<ViewListAssignmentResponse>.Paging(list, 1, 2));

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListPageResult<ViewListAssignmentResponse>)okobjectResult.Value;

            var assignmentsList = JsonConvert.SerializeObject(resultValue.Data);

            var isSorted = assignmentsList.SequenceEqual(expected);
            // Assert
            Assert.True(isSorted);
            Assert.Equal(assignmentsList.Count(), expected.Count());
        }

        [Fact]
        public async Task GetList_SearchString_WithOutData()
        {
            // Arrange 
            ReturnRequestController returnRequestController = new ReturnRequestController(_context, _mapper);
            var searchString = "top 1";
            // Act 
            var result = await returnRequestController.Get(1, 2, searchString);

            var list = _context.Assignments
                .Where(x => !x.IsDeleted && (x.Asset.Name.Contains(searchString) || x.Asset.AssetCode.Contains(searchString)))
                .Select(x => new ViewListAssignmentResponse
                {
                    Id = x.Id,
                    AssetCode = x.Asset.AssetCode,
                    AssetName = x.Asset.Name,
                    AssignedTo = x.AssignedToAppUser.UserName,
                    AssignedBy = x.AssignedByAppUser.UserName,
                    AssignedDate = x.AssignedDate,
                    State = x.State,
                })
                .OrderBy(x => x.Id);

            var expected = StaticFunctions<ViewListAssignmentResponse>.Paging(list, 1, 2);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListPageResult<ViewListAssignmentResponse>)okobjectResult.Value;

            var assignmentsList = resultValue.Data;

            var isSorted = assignmentsList.SequenceEqual(expected);
            // Assert
            Assert.True(isSorted);
            Assert.Equal(assignmentsList.Count(), expected.Count());
        }

        [Fact]
        public async Task GetList_FilterState()
        {
            // Arrange 
            ReturnRequestController returnRequestController = new ReturnRequestController(_context, _mapper);
            var state = (int)AssetManagement.Domain.Enums.Assignment.State.Accepted;
            // Act 
            var result = await returnRequestController.Get(1, 2, stateFilter: state.ToString());

            var list = _context.Assignments
                .Where(x => !x.IsDeleted && (int)x.State == state)
                .Select(x => new ViewListAssignmentResponse
                {
                    Id = x.Id,
                    NoNumber = x.Id,
                    AssetCode = x.Asset.AssetCode,
                    AssetName = x.Asset.Name,
                    AssignedTo = x.AssignedToAppUser.UserName,
                    AssignedBy = x.AssignedByAppUser.UserName,
                    AssignedDate = x.AssignedDate,
                    State = x.State,
                })
                .OrderBy(x => x.Id);

            var expected = JsonConvert.SerializeObject(
                StaticFunctions<ViewListAssignmentResponse>.Paging(list, 1, 2));

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListPageResult<ViewListAssignmentResponse>)okobjectResult.Value;

            var assignmentsList = JsonConvert.SerializeObject(resultValue.Data);

            Assert.Equal(expected, assignmentsList);
        }

        [Fact]
        public async Task GetList_FilterAssignedDate()
        {
            // Arrange 
            ReturnRequestController returnRequestController = new ReturnRequestController(_context, _mapper);
            var assignedDateFilter = "2022-11-28";
            // Act 
            var result = await returnRequestController.Get(1, 2, assignedDateFilter);

            var list = _context.Assignments
                .Where(x => !x.IsDeleted && x.AssignedDate.Date == DateTime.Parse(assignedDateFilter).Date)
                .Select(x => new ViewListAssignmentResponse
                {
                    Id = x.Id,
                    NoNumber = x.Id,
                    AssetCode = x.Asset.AssetCode,
                    AssetName = x.Asset.Name,
                    AssignedTo = x.AssignedToAppUser.UserName,
                    AssignedBy = x.AssignedByAppUser.UserName,
                    AssignedDate = x.AssignedDate,
                    State = x.State,
                })
                .OrderBy(x => x.Id);
            var expected = JsonConvert.SerializeObject(
                StaticFunctions<ViewListAssignmentResponse>.Paging(list, 1, 2));

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListPageResult<ViewListAssignmentResponse>)okobjectResult.Value;

            var assignmentsList = JsonConvert.SerializeObject(resultValue.Data);

            Assert.Equal(expected, assignmentsList);
        }

        [Fact]
        public async Task GetList_ForDefaultSortedByAssetCode()
        {
            // Arrange 
            ReturnRequestController returnRequestController = new ReturnRequestController(_context, _mapper);
            var sortType = "assetCode";
            // Act 
            var result = await returnRequestController.Get(1, 2, sort: sortType);

            var list = _context.Assignments
                .Where(x => !x.IsDeleted)
                .Select(x => new ViewListAssignmentResponse
                {
                    Id = x.Id,
                    NoNumber = x.Id,
                    AssetCode = x.Asset.AssetCode,
                    AssetName = x.Asset.Name,
                    AssignedTo = x.AssignedToAppUser.UserName,
                    AssignedBy = x.AssignedByAppUser.UserName,
                    AssignedDate = x.AssignedDate,
                    State = x.State,
                }).OrderBy(x => x.AssetCode);

            var expected = JsonConvert.SerializeObject(
                StaticFunctions<ViewListAssignmentResponse>.Paging(list, 1, 2));

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListPageResult<ViewListAssignmentResponse>)okobjectResult.Value;

            var assignmentsList = JsonConvert.SerializeObject(resultValue.Data);

            Assert.Equal(expected, assignmentsList);
        }

        [Fact]
        public async Task GetList_ForDefault_InvalidPaging()
        {
            // Arrange 
            ReturnRequestController returnRequestController = new ReturnRequestController(_context, _mapper);

            // Act 
            var result = await returnRequestController.Get(-1, 2);

            var list = _context.Assignments
                .Where(x => !x.IsDeleted)
                .Select(x => new ViewListAssignmentResponse
                {
                    Id = x.Id,
                    AssetCode = x.Asset.AssetCode,
                    AssetName = x.Asset.Name,
                    AssignedTo = x.AssignedToAppUser.UserName,
                    AssignedBy = x.AssignedByAppUser.UserName,
                    AssignedDate = x.AssignedDate,
                    State = x.State,
                })
                .OrderBy(x => x.Id);

            var expected = StaticFunctions<ViewListAssignmentResponse>.Paging(list, -1, 2);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewListPageResult<ViewListAssignmentResponse>)okobjectResult.Value;

            var assignmentsList = resultValue.Data;

            var isSorted = assignmentsList.SequenceEqual(expected);
            // Assert
            Assert.True(isSorted);
            Assert.Equal(assignmentsList.Count(), expected.Count());
        }
        #endregion
    }
}
