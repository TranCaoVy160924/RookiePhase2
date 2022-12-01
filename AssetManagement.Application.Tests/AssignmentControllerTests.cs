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
using AssetManagement.Application.Tests.TestHelper;

namespace AssetManagement.Application.Tests
{
    public class AssignmentControllerTests : IDisposable
    {
        private readonly DbContextOptions _options;
        private readonly AssetManagementDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AssignmentControllerTests()
        {
            // Create InMemory dbcontext options
            _options = new DbContextOptionsBuilder<AssetManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "AssignmentTestDb").Options;

            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new AssignmentProfile())).CreateMapper();

            // Create InMemory dbcontext with options
            _context = new AssetManagementDbContext(_options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        // [Fact]
        // public void GetAssignmentListByAssetCodeId_ReturnResults()
        // {
        //     // Arrange 
        //     var assignmentController = new AssignmentController(_context, _mapper);

        //     // Act 
        //     var result = assignmentController.GetAssignmentsByAssetCodeId(1);

        //     var list = _context.Assignments.Where(x => x.AssetId == 1).ToList();

        //     var expected = _mapper.Map<List<AssignmentResponse>>(list);

        //     foreach (var item in expected)
        //     {
        //         item.AssignedTo = _context.Users.Find(new Guid(item.AssignedTo)).UserName;
        //         item.AssignedBy = _context.Users.Find(new Guid(item.AssignedBy)).UserName;
        //     }

        //     var okobjectResult = (OkObjectResult)result;
        //     var resultValue = (List<AssignmentResponse>)okobjectResult.Value;

        //     Assert.IsType<List<AssignmentResponse>>(resultValue);
        //     Assert.NotEmpty(resultValue);
        //     Assert.Equal(resultValue.Count(), expected.Count());
        // }

        // [Fact]
        // public void GetAssignmentListByAssetCodeId_ReturnEmptyResult()
        // {
        //     // Arrange 
        //     var assignmentController = new AssignmentController(_context, _mapper);

        //     // Act 
        //     var result = assignmentController.GetAssignmentsByAssetCodeId(2);

        //     var list = _context.Assignments.Where(x => x.AssetId == 2).ToList();

        //     var expected = _mapper.Map<List<AssignmentResponse>>(list);

        //     foreach (var item in expected)
        //     {
        //         item.AssignedTo = _context.Users.Find(new Guid(item.AssignedTo)).UserName;
        //         item.AssignedBy = _context.Users.Find(new Guid(item.AssignedBy)).UserName;
        //     }

        //     var okobjectResult = (OkObjectResult)result;
        //     var resultValue = (List<AssignmentResponse>)okobjectResult.Value;

        //     Assert.IsType<List<AssignmentResponse>>(resultValue);
        //     Assert.Empty(resultValue);
        //     Assert.Equal(resultValue.Count(), expected.Count());
        // }

        #region GetList
        [Fact]
        public async Task GetList_ForDefault()
        {
            // Arrange 
            AssignmentsController assignmentController = new AssignmentsController(_context, _mapper);

            // Act 
            var result = await assignmentController.Get(1, 2);

            // var listDefault = _context.Assignments
            //     .Include(x => x.Asset)
            //     .Include(x => x.AssignedToAppUser)
            //     .Include(x => x.AssignedByToAppUser)
            //     .Where(x => !x.IsDeleted)
            //     .Select(x => new ViewListAssignmentResponse
            //     {
            //         Id = x.Id,
            //         AssetCode = x.Asset.AssetCode,
            //         AssetName = x.Asset.Name,
            //         AssignedTo = x.AssignedToAppUser.UserName,
            //         AssignedBy = x.AssignedByToAppUser.UserName,
            //         AssignedDate = x.AssignedDate,
            //         State = x.State,
            //     })
            //     .OrderBy(x => x.Id)
            //     .ToList();

            // var list = listDefault.Select((x, index) => new ViewListAssignmentResponse
            // {
            //     Id = x.Id,
            //     NoNumber = index + 1,
            //     AssetCode = x.AssetCode,
            //     AssetName = x.AssetName,
            //     AssignedTo = x.AssignedTo,
            //     AssignedBy = x.AssignedBy,
            //     AssignedDate = x.AssignedDate,
            //     State = x.State,
            // }).AsQueryable<ViewListAssignmentResponse>();

            var list = _context.Assignments
                .Where(x => !x.IsDeleted)
                .Select(x => new ViewListAssignmentResponse
                {
                    Id = x.Id,
                    AssetCode = x.Asset.AssetCode,
                    AssetName = x.Asset.Name,
                    AssignedTo = x.AssignedToAppUser.UserName,
                    AssignedBy = x.AssignedByToAppUser.UserName,
                    AssignedDate = x.AssignedDate,
                    State = x.State,
                })
                .OrderBy(x => x.Id);

            var expected = StaticFunctions<ViewListAssignmentResponse>.Paging(list, 1, 2);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewList_ListResponse<ViewListAssignmentResponse>)okobjectResult.Value;

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
            AssignmentsController assignmentController = new AssignmentsController(_context, _mapper);
            var searchString = "top 1";
            // Act 
            var result = await assignmentController.Get(1, 2, searchString);

            // var listDefault = _context.Assignments
            //     .Include(x => x.Asset)
            //     .Include(x => x.AssignedToAppUser)
            //     .Include(x => x.AssignedByToAppUser)
            //     .Where(x => !x.IsDeleted)
            //     .Select(x => new ViewListAssignmentResponse
            //     {
            //         Id = x.Id,
            //         AssetCode = x.Asset.AssetCode,
            //         AssetName = x.Asset.Name,
            //         AssignedTo = x.AssignedToAppUser.UserName,
            //         AssignedBy = x.AssignedByToAppUser.UserName,
            //         AssignedDate = x.AssignedDate,
            //         State = x.State,
            //     })
            //     .OrderBy(x => x.Id)
            //     .ToList();

            // var list = listDefault
            // .Where(x => (x.AssetName.Contains(searchString) || x.AssetCode.Contains(searchString)))
            // .Select((x, index) => new ViewListAssignmentResponse
            // {
            //     Id = x.Id,
            //     NoNumber = index + 1,
            //     AssetCode = x.AssetCode,
            //     AssetName = x.AssetName,
            //     AssignedTo = x.AssignedTo,
            //     AssignedBy = x.AssignedBy,
            //     AssignedDate = x.AssignedDate,
            //     State = x.State,
            // }).AsQueryable<ViewListAssignmentResponse>();

            var list = _context.Assignments
                .Where(x => !x.IsDeleted && (x.Asset.Name.Contains(searchString) || x.Asset.AssetCode.Contains(searchString)))
                .Select(x => new ViewListAssignmentResponse
                {
                    Id = x.Id,
                    AssetCode = x.Asset.AssetCode,
                    AssetName = x.Asset.Name,
                    AssignedTo = x.AssignedToAppUser.UserName,
                    AssignedBy = x.AssignedByToAppUser.UserName,
                    AssignedDate = x.AssignedDate,
                    State = x.State,
                })
                .OrderBy(x => x.Id);

            var expected = JsonConvert.SerializeObject(StaticFunctions<ViewListAssignmentResponse>.Paging(list, 1, 2));

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewList_ListResponse<ViewListAssignmentResponse>)okobjectResult.Value;

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
            AssignmentsController assignmentController = new AssignmentsController(_context, _mapper);
            var searchString = "top 1";
            // Act 
            var result = await assignmentController.Get(1, 2, searchString);

            // var listDefault = _context.Assignments
            //     .Include(x => x.Asset)
            //     .Include(x => x.AssignedToAppUser)
            //     .Include(x => x.AssignedByToAppUser)
            //     .Where(x => !x.IsDeleted)
            //     .Select(x => new ViewListAssignmentResponse
            //     {
            //         Id = x.Id,
            //         AssetCode = x.Asset.AssetCode,
            //         AssetName = x.Asset.Name,
            //         AssignedTo = x.AssignedToAppUser.UserName,
            //         AssignedBy = x.AssignedByToAppUser.UserName,
            //         AssignedDate = x.AssignedDate,
            //         State = x.State,
            //     })
            //     .OrderBy(x => x.Id)
            //     .ToList();

            // var list = listDefault
            // .Where(x => (x.AssetName.Contains(searchString) || x.AssetCode.Contains(searchString)))
            // .Select((x, index) => new ViewListAssignmentResponse
            // {
            //     Id = x.Id,
            //     NoNumber = index + 1,
            //     AssetCode = x.AssetCode,
            //     AssetName = x.AssetName,
            //     AssignedTo = x.AssignedTo,
            //     AssignedBy = x.AssignedBy,
            //     AssignedDate = x.AssignedDate,
            //     State = x.State,
            // }).AsQueryable<ViewListAssignmentResponse>();

            var list = _context.Assignments
                .Where(x => !x.IsDeleted && (x.Asset.Name.Contains(searchString) ||  x.Asset.AssetCode.Contains(searchString)))
                .Select(x => new ViewListAssignmentResponse
                {
                    Id = x.Id,
                    AssetCode = x.Asset.AssetCode,
                    AssetName = x.Asset.Name,
                    AssignedTo = x.AssignedToAppUser.UserName,
                    AssignedBy = x.AssignedByToAppUser.UserName,
                    AssignedDate = x.AssignedDate,
                    State = x.State,
                })
                .OrderBy(x => x.Id);

            var expected = StaticFunctions<ViewListAssignmentResponse>.Paging(list, 1, 2);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewList_ListResponse<ViewListAssignmentResponse>)okobjectResult.Value;

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
            AssignmentsController assignmentController = new AssignmentsController(_context, _mapper);
            var state = (int)AssetManagement.Domain.Enums.Assignment.State.Accepted;
            // Act 
            var result = await assignmentController.Get(1, 2, state.ToString());

            // var listDefault = _context.Assignments
            //     .Include(x => x.Asset)
            //     .Include(x => x.AssignedToAppUser)
            //     .Include(x => x.AssignedByToAppUser)
            //     .Where(x => !x.IsDeleted)
            //     .Select(x => new ViewListAssignmentResponse
            //     {
            //         Id = x.Id,
            //         AssetCode = x.Asset.AssetCode,
            //         AssetName = x.Asset.Name,
            //         AssignedTo = x.AssignedToAppUser.UserName,
            //         AssignedBy = x.AssignedByToAppUser.UserName,
            //         AssignedDate = x.AssignedDate,
            //         State = x.State,
            //     })
            //     .OrderBy(x => x.Id)
            //     .ToList();

            // var list = listDefault
            // .Where(x => (int)x.State == state)
            // .Select((x, index) => new ViewListAssignmentResponse
            // {
            //     Id = x.Id,
            //     NoNumber = index + 1,
            //     AssetCode = x.AssetCode,
            //     AssetName = x.AssetName,
            //     AssignedTo = x.AssignedTo,
            //     AssignedBy = x.AssignedBy,
            //     AssignedDate = x.AssignedDate,
            //     State = x.State,
            // }).AsQueryable<ViewListAssignmentResponse>();

            var list = _context.Assignments
                .Where(x => !x.IsDeleted && (int)x.State == state)
                .Select(x => new ViewListAssignmentResponse
                {
                    Id = x.Id,
                    AssetCode = x.Asset.AssetCode,
                    AssetName = x.Asset.Name,
                    AssignedTo = x.AssignedToAppUser.UserName,
                    AssignedBy = x.AssignedByToAppUser.UserName,
                    AssignedDate = x.AssignedDate,
                    State = x.State,
                })
                .OrderBy(x => x.Id);

            var expected = StaticFunctions<ViewListAssignmentResponse>.Paging(list, 1, 2);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewList_ListResponse<ViewListAssignmentResponse>)okobjectResult.Value;

            var assignmentsList = resultValue.Data;

            var isSorted = assignmentsList.SequenceEqual(expected);
            // Assert
            Assert.True(isSorted);
            Assert.Equal(assignmentsList.Count(), expected.Count());
        }

        [Fact]
        public async Task GetList_FilterAssignedDate()
        {
            // Arrange 
            AssignmentsController assignmentController = new AssignmentsController(_context, _mapper);
            var assignedDateFilter = "2022-11-28";
            // Act 
            var result = await assignmentController.Get(1, 2, assignedDateFilter);

            // var listDefault = _context.Assignments
            //     .Include(x => x.Asset)
            //     .Include(x => x.AssignedToAppUser)
            //     .Include(x => x.AssignedByToAppUser)
            //     .Where(x => !x.IsDeleted)
            //     .Select(x => new ViewListAssignmentResponse
            //     {
            //         Id = x.Id,
            //         AssetCode = x.Asset.AssetCode,
            //         AssetName = x.Asset.Name,
            //         AssignedTo = x.AssignedToAppUser.UserName,
            //         AssignedBy = x.AssignedByToAppUser.UserName,
            //         AssignedDate = x.AssignedDate,
            //         State = x.State,
            //     })
            //     .OrderBy(x => x.Id)
            //     .ToList();

            // var list = listDefault
            // .Where(x => x.AssignedDate.Date == DateTime.Parse(assignedDateFilter).Date)
            // .Select((x, index) => new ViewListAssignmentResponse
            // {
            //     Id = x.Id,
            //     NoNumber = index + 1,
            //     AssetCode = x.AssetCode,
            //     AssetName = x.AssetName,
            //     AssignedTo = x.AssignedTo,
            //     AssignedBy = x.AssignedBy,
            //     AssignedDate = x.AssignedDate,
            //     State = x.State,
            // }).AsQueryable<ViewListAssignmentResponse>();

            var list = _context.Assignments
                .Where(x => !x.IsDeleted && x.AssignedDate.Date == DateTime.Parse(assignedDateFilter).Date)
                .Select(x => new ViewListAssignmentResponse
                {
                    Id = x.Id,
                    AssetCode = x.Asset.AssetCode,
                    AssetName = x.Asset.Name,
                    AssignedTo = x.AssignedToAppUser.UserName,
                    AssignedBy = x.AssignedByToAppUser.UserName,
                    AssignedDate = x.AssignedDate,
                    State = x.State,
                })
                .OrderBy(x => x.Id);
            var expected = StaticFunctions<ViewListAssignmentResponse>.Paging(list, 1, 2);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewList_ListResponse<ViewListAssignmentResponse>)okobjectResult.Value;

            var assignmentsList = resultValue.Data;

            var isSorted = assignmentsList.SequenceEqual(expected);
            // Assert
            Assert.True(isSorted);
            Assert.Equal(assignmentsList.Count(), expected.Count());
        }

        [Fact]
        public async Task GetList_ForDefaultSortedByAssetCode()
        {
            // Arrange 
            AssignmentsController assignmentController = new AssignmentsController(_context, _mapper);
            var sortType = "assetCode";
            // Act 
            var result = await assignmentController.Get(1, 2, sortType);

            // var listDefault = _context.Assignments
            //     .Include(x => x.Asset)
            //     .Include(x => x.AssignedToAppUser)
            //     .Include(x => x.AssignedByToAppUser)
            //     .Where(x => !x.IsDeleted)
            //     .Select(x => new ViewListAssignmentResponse
            //     {
            //         Id = x.Id,
            //         AssetCode = x.Asset.AssetCode,
            //         AssetName = x.Asset.Name,
            //         AssignedTo = x.AssignedToAppUser.UserName,
            //         AssignedBy = x.AssignedByToAppUser.UserName,
            //         AssignedDate = x.AssignedDate,
            //         State = x.State,
            //     })
            //     .ToList();

            // var list = listDefault
            // .Select((x, index) => new ViewListAssignmentResponse
            // {
            //     Id = x.Id,
            //     NoNumber = index + 1,
            //     AssetCode = x.AssetCode,
            //     AssetName = x.AssetName,
            //     AssignedTo = x.AssignedTo,
            //     AssignedBy = x.AssignedBy,
            //     AssignedDate = x.AssignedDate,
            //     State = x.State,
            // }).OrderBy(x => x.AssetCode)
            // .AsQueryable<ViewListAssignmentResponse>();

            var list = _context.Assignments
                .Where(x => !x.IsDeleted)
                .Select(x => new ViewListAssignmentResponse
                {
                    Id = x.Id,
                    AssetCode = x.Asset.AssetCode,
                    AssetName = x.Asset.Name,
                    AssignedTo = x.AssignedToAppUser.UserName,
                    AssignedBy = x.AssignedByToAppUser.UserName,
                    AssignedDate = x.AssignedDate,
                    State = x.State,
                }).OrderBy(x => x.AssetCode);

            var expected = StaticFunctions<ViewListAssignmentResponse>.Paging(list, 1, 2);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewList_ListResponse<ViewListAssignmentResponse>)okobjectResult.Value;

            var assignmentsList = resultValue.Data;

            var isSorted = assignmentsList.SequenceEqual(expected);
            // Assert
            Assert.True(isSorted);
            Assert.Equal(assignmentsList.Count(), expected.Count());
        }

        [Fact]
        public async Task GetList_ForDefault_InvalidPaging()
        {
            // Arrange 
            AssignmentsController assignmentController = new AssignmentsController(_context, _mapper);

            // Act 
            var result = await assignmentController.Get(-1, 2);

            // var listDefault = _context.Assignments
            //     .Include(x => x.Asset)
            //     .Include(x => x.AssignedToAppUser)
            //     .Include(x => x.AssignedByToAppUser)
            //     .Where(x => !x.IsDeleted)
            //     .Select(x => new ViewListAssignmentResponse
            //     {
            //         Id = x.Id,
            //         AssetCode = x.Asset.AssetCode,
            //         AssetName = x.Asset.Name,
            //         AssignedTo = x.AssignedToAppUser.UserName,
            //         AssignedBy = x.AssignedByToAppUser.UserName,
            //         AssignedDate = x.AssignedDate,
            //         State = x.State,
            //     })
            //     .OrderBy(x => x.Id)
            //     .ToList();

            // var list = listDefault.Select((x, index) => new ViewListAssignmentResponse
            // {
            //     Id = x.Id,
            //     NoNumber = index + 1,
            //     AssetCode = x.AssetCode,
            //     AssetName = x.AssetName,
            //     AssignedTo = x.AssignedTo,
            //     AssignedBy = x.AssignedBy,
            //     AssignedDate = x.AssignedDate,
            //     State = x.State,
            // }).AsQueryable<ViewListAssignmentResponse>();

            var list = _context.Assignments
                .Where(x => !x.IsDeleted)
                .Select(x => new ViewListAssignmentResponse
                {
                    Id = x.Id,
                    AssetCode = x.Asset.AssetCode,
                    AssetName = x.Asset.Name,
                    AssignedTo = x.AssignedToAppUser.UserName,
                    AssignedBy = x.AssignedByToAppUser.UserName,
                    AssignedDate = x.AssignedDate,
                    State = x.State,
                })
                .OrderBy(x => x.Id);

            var expected = StaticFunctions<ViewListAssignmentResponse>.Paging(list, -1, 2);

            var okobjectResult = (OkObjectResult)result.Result;

            var resultValue = (ViewList_ListResponse<ViewListAssignmentResponse>)okobjectResult.Value;

            var assignmentsList = resultValue.Data;

            var isSorted = assignmentsList.SequenceEqual(expected);
            // Assert
            Assert.True(isSorted);
            Assert.Equal(assignmentsList.Count(), expected.Count());
        }
        #endregion

        #region DeleteAssignment
        #nullable disable
        #region DeleteSuccess
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(9)]
        [InlineData(10)]
        public async Task Delete_SuccessAsync(int id)
        {
            //ARRANGE
            AssignmentsController controller = new(_context, _mapper);

            //ACT
            IActionResult result = await controller.DeleteAsync(id);
            string data = ConverterFromIActionResult.ConvertOkObject<AssignmentResponse>(result);
            Assignment deleted = _context.Assignments.Find(id);
            AssignmentResponse expected = _mapper.Map<AssignmentResponse>(deleted);
            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.True(deleted.IsDeleted);
            Assert.Equal(JsonConvert.SerializeObject(expected), data);
        }
        #endregion

        #region Delete_NotFound
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(11)]
        [InlineData(999)]
        public async Task Delete_NotFoundAsync(int id)
        {
            //ARRANGE
            AssignmentsController controller = new(_context, _mapper);

            //ACT
            IActionResult result = await controller.DeleteAsync(id);
            string data = ConverterFromIActionResult.ConvertStatusCode(result);

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result);
            
            Assert.Equal("\"Assignment does not exist\"", data);
        }
        #endregion

        #region DeleteException
        [Fact]
        public async Task Delete_ExceptionAsync()
        {
            //ARRANGE
            //Use null mapper to cause exception
            AssignmentsController controller = new(_context, null);

            //ACT
            IActionResult result = await controller.DeleteAsync(1);
            string data = ConverterFromIActionResult.ConvertStatusCode(result);

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("\"Object reference not set to an instance of an object.\"", data);
        }
        #endregion
        #endregion

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
