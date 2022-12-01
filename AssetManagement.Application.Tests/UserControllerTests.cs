using AssetManagement.Application.Controllers;
using static AssetManagement.Application.Tests.TestHelper.ConverterFromIActionResult;
using AssetManagement.Contracts.AutoMapper;
using AssetManagement.Contracts.User.Request;
using AssetManagement.Data.EF;
using AssetManagement.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using AssetManagement.Contracts.User.Response;
using AssetManagement.Contracts.Common;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;
using AutoMapper.Internal;
using Newtonsoft.Json;

namespace AssetManagement.Application.Tests
{
    public class UserControllerTests : IDisposable
    {
        private readonly Mock<UserManager<AppUser>> _userManager;
        private readonly DbContextOptions _options;
        private readonly AssetManagementDbContext _context;
        private readonly IMapper _mapper;

        public UserControllerTests()
        {
            // Create InMemory dbcontext options
            _options = new DbContextOptionsBuilder<AssetManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "UserTestDb").Options;

            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new UserProfile())).CreateMapper();

            //Mock UserManager
            //Create UserStore mock to enable user support for UserManager
            Mock<IUserStore<AppUser>> userStoreMoq = new();
            //Create UserManager mock using userStoreMoq
            _userManager = new(userStoreMoq.Object, null, null, null, null, null, null, null, null);
            // Create InMemory dbcontext options
            _options = new DbContextOptionsBuilder<AssetManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "AssetTestDb").Options;

            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new UserProfile())).CreateMapper();

            // Create InMemory dbcontext with options
            _context = new AssetManagementDbContext(_options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }


        #region GetUser
        [Fact]
        public async Task GetList_ForDefault_Ok()
        {
            // Arrange 
            #region Arrange
            UserController userController = new UserController(_context, _userManager.Object, _mapper);
            List<AppUser> listUsers = _context.AppUsers.ToList();
            AppUser currentUser = listUsers.ElementAt(0);
            //Create context for controller with fake login
            userController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new GenericPrincipal(new GenericIdentity(currentUser.UserName), null)
                }
            };

            List<AppUser> addminRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("admin"))
               .ToListAsync();
            List<AppUser> staffRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("staff"))
               .ToListAsync();
            foreach(AppUser user in listUsers)
            {
                if (addminRole.Contains(user))
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Admin"});
                else
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Staff" });
            }
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Admin").Result).Returns(addminRole);
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Staff").Result).Returns(staffRole);
            #endregion

            // Act 
            #region Act
            List<AppUser> expectedResult = await _context.AppUsers
                .Where(
                    x => !x.IsDeleted && 
                    x.Location == currentUser.Location &&
                    (addminRole.Contains(x) || staffRole.Contains(x)))
                .OrderBy(x => x.StaffCode)
                .ToListAsync();

            var result = await userController.GetAllUser(0, 2, "", "", "staffCode", "ASC");
            var okobjectResult = result.Result as OkObjectResult;
            ViewList_ListResponse<ViewListUser_UserResponse> actualResult = 
                okobjectResult.Value as ViewList_ListResponse<ViewListUser_UserResponse>;
            #endregion

            // Assert
            #region Assert
            Assert.NotNull(actualResult);
            Assert.Equal(actualResult.Total, expectedResult.Count);
            for(int i=0; i<expectedResult.Count; i++)
            {
                Assert.Equal(actualResult.Data.ElementAt(i).UserName, expectedResult.ElementAt(i).UserName);
            }
            #endregion
        }

        [Fact]
        public async Task GetList_SearchString_Ok()
        {
            // Arrange 
            #region Arrange
            string searchString = "SD";
            UserController userController = new UserController(_context, _userManager.Object, _mapper);
            List<AppUser> listUsers = _context.AppUsers.ToList();
            AppUser currentUser = listUsers.ElementAt(0);
            //Create context for controller with fake login
            userController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new GenericPrincipal(new GenericIdentity(currentUser.UserName), null)
                }
            };

            List<AppUser> addminRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("admin"))
               .ToListAsync();
            List<AppUser> staffRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("staff"))
               .ToListAsync();
            foreach (AppUser user in listUsers)
            {
                if (addminRole.Contains(user))
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Admin" });
                else
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Staff" });
            }
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Admin").Result).Returns(addminRole);
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Staff").Result).Returns(staffRole);
            #endregion

            // Act 
            #region Act
            List<AppUser> expectedResult = await _context.AppUsers
                .Where(x => 
                    !x.IsDeleted && 
                    x.Location == currentUser.Location && 
                    (x.StaffCode.Contains(searchString) || $"{x.FirstName} {x.LastName}".Contains(searchString)) &&
                    (addminRole.Contains(x) || staffRole.Contains(x)))
                .OrderBy(x => x.StaffCode)
                .ToListAsync();

            var result = await userController.GetAllUser(0, 2, "", searchString, "staffCode", "ASC");
            var okobjectResult = result.Result as OkObjectResult;
            ViewList_ListResponse<ViewListUser_UserResponse> actualResult =
                okobjectResult.Value as ViewList_ListResponse<ViewListUser_UserResponse>;
            #endregion

            // Assert
            #region Assert
            Assert.NotNull(actualResult);
            Assert.Equal(actualResult.Total, expectedResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(actualResult.Data.ElementAt(i).UserName, expectedResult.ElementAt(i).UserName);
            }
            #endregion
        }

        [Fact]
        public async Task GetList_FilterState_Ok()
        {
            // Arrange 
            #region Arrange
            string filterState = "Admin&Staff&";
            var listType = filterState.Split("&").ToArray();

            UserController userController = new UserController(_context, _userManager.Object, _mapper);
            List<AppUser> listUsers = _context.AppUsers.ToList();
            AppUser currentUser = listUsers.ElementAt(0);
            //Create context for controller with fake login
            userController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new GenericPrincipal(new GenericIdentity(currentUser.UserName), null)
                }
            };

            List<AppUser> addminRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("admin"))
               .ToListAsync();
            List<AppUser> staffRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("staff"))
               .ToListAsync();
            foreach (AppUser user in listUsers)
            {
                if (addminRole.Contains(user))
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Admin" });
                else
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Staff" });
            }
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Admin").Result).Returns(addminRole);
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Staff").Result).Returns(staffRole);
            #endregion

            // Act 
            #region Act
            List<AppUser> tempData = new List<AppUser>();
            for (int i = 0; i < listType.Length - 1; i++)
            {
                List<AppUser> tempUser = (listType[i] == "Admin") ? addminRole : staffRole;
                tempData.AddRange(tempUser);
            }
            List<AppUser> expectedResult = await _context.AppUsers
                .Where(x =>
                    !x.IsDeleted &&
                    x.Location == currentUser.Location &&
                    tempData.Contains(x))
                .OrderBy(x => x.StaffCode)
                .ToListAsync();

            var result = await userController.GetAllUser(0, 2, filterState, "", "staffCode", "ASC");
            var okobjectResult = result.Result as OkObjectResult;
            ViewList_ListResponse<ViewListUser_UserResponse> actualResult =
                okobjectResult.Value as ViewList_ListResponse<ViewListUser_UserResponse>;
            #endregion

            // Assert
            #region Assert
            Assert.NotNull(actualResult);
            Assert.Equal(actualResult.Total, expectedResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(actualResult.Data.ElementAt(i).UserName, expectedResult.ElementAt(i).UserName);
            }
            #endregion
        }

        [Fact]
        public async Task GetList_SortByUserName_Ok()
        {
            // Arrange 
            #region Arrange
            string sort = "userName";

            UserController userController = new UserController(_context, _userManager.Object, _mapper);
            List<AppUser> listUsers = _context.AppUsers.ToList();
            AppUser currentUser = listUsers.ElementAt(0);
            //Create context for controller with fake login
            userController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new GenericPrincipal(new GenericIdentity(currentUser.UserName), null)
                }
            };

            List<AppUser> addminRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("admin"))
               .ToListAsync();
            List<AppUser> staffRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("staff"))
               .ToListAsync();
            foreach (AppUser user in listUsers)
            {
                if (addminRole.Contains(user))
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Admin" });
                else
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Staff" });
            }
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Admin").Result).Returns(addminRole);
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Staff").Result).Returns(staffRole);
            #endregion

            // Act 
            #region Act
            List<AppUser> expectedResult = await _context.AppUsers
                .Where(x =>
                    !x.IsDeleted &&
                    x.Location == currentUser.Location)
                .OrderBy(x => x.UserName)
                .ToListAsync();

            var result = await userController.GetAllUser(0, 2, "", "", sort, "ASC");
            var okobjectResult = result.Result as OkObjectResult;
            ViewList_ListResponse<ViewListUser_UserResponse> actualResult =
                okobjectResult.Value as ViewList_ListResponse<ViewListUser_UserResponse>;
            #endregion

            // Assert
            #region Assert
            Assert.NotNull(actualResult);
            Assert.Equal(actualResult.Total, expectedResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(actualResult.Data.ElementAt(i).UserName, expectedResult.ElementAt(i).UserName);
            }
            #endregion
        }

        [Fact]
        public async Task GetList_SortByFullName_Ok()
        {
            // Arrange 
            #region Arrange
            string sort = "fullName";

            UserController userController = new UserController(_context, _userManager.Object, _mapper);
            List<AppUser> listUsers = _context.AppUsers.ToList();
            AppUser currentUser = listUsers.ElementAt(0);
            //Create context for controller with fake login
            userController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new GenericPrincipal(new GenericIdentity(currentUser.UserName), null)
                }
            };

            List<AppUser> addminRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("admin"))
               .ToListAsync();
            List<AppUser> staffRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("staff"))
               .ToListAsync();
            foreach (AppUser user in listUsers)
            {
                if (addminRole.Contains(user))
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Admin" });
                else
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Staff" });
            }
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Admin").Result).Returns(addminRole);
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Staff").Result).Returns(staffRole);
            #endregion

            // Act 
            #region Act
            List<AppUser> expectedResult = await _context.AppUsers
                .Where(x =>
                    !x.IsDeleted &&
                    x.Location == currentUser.Location)
                .OrderBy(x => x.FirstName + ' ' + x.LastName)
                .ToListAsync();

            var result = await userController.GetAllUser(0, 2, "", "", sort, "ASC");
            var okobjectResult = result.Result as OkObjectResult;
            ViewList_ListResponse<ViewListUser_UserResponse> actualResult =
                okobjectResult.Value as ViewList_ListResponse<ViewListUser_UserResponse>;
            #endregion

            // Assert
            #region Assert
            Assert.NotNull(actualResult);
            Assert.Equal(actualResult.Total, expectedResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(actualResult.Data.ElementAt(i).UserName, expectedResult.ElementAt(i).UserName);
            }
            #endregion
        }

        [Fact]
        public async Task GetList_SortByJoinedDate_Ok()
        {
            // Arrange 
            #region Arrange
            string sort = "joinedDate";

            UserController userController = new UserController(_context, _userManager.Object, _mapper);
            List<AppUser> listUsers = _context.AppUsers.ToList();
            AppUser currentUser = listUsers.ElementAt(0);
            //Create context for controller with fake login
            userController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new GenericPrincipal(new GenericIdentity(currentUser.UserName), null)
                }
            };

            List<AppUser> addminRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("admin"))
               .ToListAsync();
            List<AppUser> staffRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("staff"))
               .ToListAsync();
            foreach (AppUser user in listUsers)
            {
                if (addminRole.Contains(user))
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Admin" });
                else
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Staff" });
            }
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Admin").Result).Returns(addminRole);
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Staff").Result).Returns(staffRole);
            #endregion

            // Act 
            #region Act
            List<AppUser> expectedResult = await _context.AppUsers
                .Where(x =>
                    !x.IsDeleted &&
                    x.Location == currentUser.Location)
                .OrderBy(x => x.CreatedDate)
                .ToListAsync();

            var result = await userController.GetAllUser(0, 2, "", "", sort, "ASC");
            var okobjectResult = result.Result as OkObjectResult;
            ViewList_ListResponse<ViewListUser_UserResponse> actualResult =
                okobjectResult.Value as ViewList_ListResponse<ViewListUser_UserResponse>;
            #endregion

            // Assert
            #region Assert
            Assert.NotNull(actualResult);
            Assert.Equal(actualResult.Total, expectedResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(actualResult.Data.ElementAt(i).UserName, expectedResult.ElementAt(i).UserName);
            }
            #endregion
        }

        [Fact]
        public async Task GetList_SortByType_Ok()
        {
            // Arrange 
            #region Arrange
            string sort = "type";

            UserController userController = new UserController(_context, _userManager.Object, _mapper);
            List<AppUser> listUsers = _context.AppUsers.ToList();
            AppUser currentUser = listUsers.ElementAt(0);
            //Create context for controller with fake login
            userController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new GenericPrincipal(new GenericIdentity(currentUser.UserName), null)
                }
            };

            List<AppUser> addminRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("admin"))
               .ToListAsync();
            List<AppUser> staffRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("staff"))
               .ToListAsync();
            foreach (AppUser user in listUsers)
            {
                if (addminRole.Contains(user))
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Admin" });
                else
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Staff" });
            }
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Admin").Result).Returns(addminRole);
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Staff").Result).Returns(staffRole);
            #endregion

            // Act 
            #region Act
            IQueryable<AppUser> adminAccount = _context.AppUsers
                .Where(x =>
                    !x.IsDeleted &&
                    x.Location == currentUser.Location &&
                    addminRole.Contains(x));
            IQueryable<AppUser> staffAccount = _context.AppUsers
                .Where(x =>
                    !x.IsDeleted &&
                    x.Location == currentUser.Location &&
                    staffRole.Contains(x));
            List<AppUser> expectedResult = await adminAccount.Concat(staffAccount).ToListAsync();

            var result = await userController.GetAllUser(0, 2, "", "", sort, "ASC");
            var okobjectResult = result.Result as OkObjectResult;
            ViewList_ListResponse<ViewListUser_UserResponse> actualResult =
                okobjectResult.Value as ViewList_ListResponse<ViewListUser_UserResponse>;
            #endregion

            // Assert
            #region Assert
            Assert.NotNull(actualResult);
            Assert.Equal(actualResult.Total, expectedResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(actualResult.Data.ElementAt(i).UserName, expectedResult.ElementAt(i).UserName);
            }
            #endregion
        }

        [Fact]
        public async Task GetList_InvalidPaging_Ok()
        {
            // Arrange 
            #region Arrange
            int start = -1;
            int end = 20;

            UserController userController = new UserController(_context, _userManager.Object, _mapper);
            List<AppUser> listUsers = _context.AppUsers.ToList();
            AppUser currentUser = listUsers.ElementAt(0);
            //Create context for controller with fake login
            userController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new GenericPrincipal(new GenericIdentity(currentUser.UserName), null)
                }
            };

            List<AppUser> addminRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("admin"))
               .ToListAsync();
            List<AppUser> staffRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("staff"))
               .ToListAsync();
            foreach (AppUser user in listUsers)
            {
                if (addminRole.Contains(user))
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Admin" });
                else
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Staff" });
            }
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Admin").Result).Returns(addminRole);
            _userManager.Setup(_ => _.GetUsersInRoleAsync("Staff").Result).Returns(staffRole);
            #endregion

            // Act 
            #region Act
            IQueryable<AppUser> sortedListUser = _context.AppUsers
                .Where(x =>
                    !x.IsDeleted &&
                    x.Location == currentUser.Location)
                .OrderBy(x => x.UserName)
                .AsQueryable();
            List<AppUser> expectedResult = await sortedListUser
                .Skip(start < 0 || start > end ? 1 : start)
                .Take(end>sortedListUser.Count() ? sortedListUser.Count()-start : end-start)
                .ToListAsync();


            var result = await userController.GetAllUser(start, end, "", "", "staffCode", "ASC");
            var okobjectResult = result.Result as OkObjectResult;
            ViewList_ListResponse<ViewListUser_UserResponse> actualResult =
                okobjectResult.Value as ViewList_ListResponse<ViewListUser_UserResponse>;
            #endregion

            // Assert
            #region Assert
            Assert.NotNull(actualResult);
            Assert.Equal(actualResult.Total, expectedResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(actualResult.Data.ElementAt(i).UserName, expectedResult.ElementAt(i).UserName);
            }
            #endregion
        }
        #endregion

        #region GetSingleUser
        [Fact]
        public async Task GetSingleUser_Ok()
        {
            // Arrange 
            #region Arrange
            AppUser expectedUser = _context.AppUsers.ToList().ElementAt(1);
            string staffCode = expectedUser.StaffCode;

            UserController userController = new UserController(_context, _userManager.Object, _mapper);
            List<AppUser> listUsers = _context.AppUsers.ToList();
            AppUser currentUser = listUsers.ElementAt(0);
            List<AppUser> addminRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("admin"))
               .ToListAsync();
            List<AppUser> staffRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("staff"))
               .ToListAsync();
            foreach (AppUser user in listUsers)
            {
                if (addminRole.Contains(user))
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Admin" });
                else
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Staff" });
            }
            #endregion

            // Act 
            #region Act
            var result = await userController.GetSingleUser(staffCode);
            var okobjectResult = result.Result as OkObjectResult;
            SuccessResponseResult<ViewDetailUser_UserResponse> actualResult =
                okobjectResult.Value as SuccessResponseResult<ViewDetailUser_UserResponse>;
            ViewDetailUser_UserResponse resultData = actualResult?.Result;
            #endregion

            // Assert
            #region Assert
            Assert.NotNull(resultData);
            Assert.Equal(resultData.StaffCode, staffCode);
            Assert.Equal(resultData.UserName, expectedUser.UserName);
            Assert.Equal(resultData.Location, expectedUser.Location.ToString());
            #endregion
        }

        [Fact]
        public async Task GetSingleUser_InvalidStaffCode_BadRequest()
        {
            // Arrange 
            #region Arrange
            string staffCode = "Invalid";

            UserController userController = new UserController(_context, _userManager.Object, _mapper);
            List<AppUser> listUsers = _context.AppUsers.ToList();
            AppUser currentUser = listUsers.ElementAt(0);
            List<AppUser> addminRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("admin"))
               .ToListAsync();
            List<AppUser> staffRole = await _context.AppUsers
               .Where(x => !x.IsDeleted && x.UserName.Contains("staff"))
               .ToListAsync();
            foreach (AppUser user in listUsers)
            {
                if (addminRole.Contains(user))
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Admin" });
                else
                    _userManager.Setup(_ => _.GetRolesAsync(user).Result).Returns(new List<string> { "Staff" });
            }
            #endregion

            // Act 
            #region Act
            var result = await userController.GetSingleUser(staffCode);
            var badrequestResult = result.Result as BadRequestObjectResult;
            ErrorResponseResult<string> actualResult = badrequestResult?.Value as ErrorResponseResult<string>;
            #endregion

            // Assert
            #region Assert
            Assert.NotNull(actualResult);
            Assert.Equal(400, badrequestResult.StatusCode);
            #endregion
        }
        #endregion

        #region EditUser
        #nullable disable
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task EditUser_SuccessAsync(int index)
        {
            //ARRANGE
            UpdateUserRequest request = new()
            {
                Dob = new(2000, 11, 28),
                Gender = (byte)Domain.Enums.AppUser.UserGender.Female,
                JoinedDate = new(2022, 11, 28),
                Type = "Admin"
            };

            string staffCode = _context.AppUsers.ToList()[index].StaffCode;

            UserController controller = new UserController(_context, _userManager.Object, _mapper);

            //ACT
            IActionResult result = await controller.UpdateUserAsync(staffCode, request);
            string data = ConvertOkObject<UpdateUserResponse>(result);
            UpdateUserResponse expected = _mapper.Map<UpdateUserResponse>(_context.AppUsers.ToList()[index]);
            expected.Type = "Admin";

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(data);
            Assert.Equal(JsonConvert.SerializeObject(expected), data);
        }

        [Fact]
        public async Task EditUser_BadRequest_UnderAgeAsync()
        {
            //ARRANGE
            UpdateUserRequest request = new()
            {
                Dob = DateTime.Now.AddYears(-18).AddSeconds(1),
                Gender = (byte)Domain.Enums.AppUser.UserGender.Female,
                JoinedDate = new(2022, 11, 28),
                Type = "Admin"
            };

            UserController controller = new UserController(_context, _userManager.Object, _mapper);

            //ACT
            IActionResult result = await controller.UpdateUserAsync("SD0001", request);
            string data = ConvertStatusCode(result);

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("\"User is under 18. Please select a different date\"", data);
        }

        [Fact]
        public async Task EditUser_BadRequest_JoinedAgeAsync()
        {
            //ARRANGE
            UpdateUserRequest request = new()
            {
                Dob = new(2000, 11, 29),
                Gender = (byte)Domain.Enums.AppUser.UserGender.Female,
                JoinedDate = new(2018, 11, 28),
                Type = "Admin"
            };

            UserController controller = new UserController(_context, _userManager.Object, _mapper);

            //ACT
            IActionResult result = await controller.UpdateUserAsync("SD0001", request);
            string data = ConvertStatusCode(result);

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("\"User under the age 18 may not join the company. Please select a different date\"", data);
        }

        [Theory]
        [InlineData(2022, 11, 27)]
        [InlineData(2022, 11, 26)]
        public async Task EditUser_BadRequest_JoinedWeekendAsync(int jyear, int jmonth, int jday)
        {
            //ARRANGE
            UpdateUserRequest request = new()
            {
                Dob = new(2000, 11, 20),
                Gender = (byte)Domain.Enums.AppUser.UserGender.Female,
                JoinedDate = new(jyear, jmonth, jday),
                Type = "Admin"
            };

            UserController controller = new UserController(_context, _userManager.Object, _mapper);

            //ACT
            IActionResult result = await controller.UpdateUserAsync("SD0001", request);
            string data = ConvertStatusCode(result);

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("\"Joined date is Saturday or Sunday. Please select a different date\"", data);
        }

        [Fact]
        public async Task EditUser_BadRequest_NotFoundAsync()
        {
            //ARRANGE
            UpdateUserRequest request = new()
            {
                Dob = new(2000, 11, 29),
                Gender = (byte)Domain.Enums.AppUser.UserGender.Female,
                JoinedDate = new(2022, 11, 28),
                Type = "Admin"
            };

            UserController controller = new UserController(_context, _userManager.Object, _mapper);

            //ACT
            IActionResult result = await controller.UpdateUserAsync("INVAUR", request);

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
