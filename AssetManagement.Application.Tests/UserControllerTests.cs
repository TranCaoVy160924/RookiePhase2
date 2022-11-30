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
using AssetManagement.Contracts.Asset.Response;
using AssetManagement.Contracts.User.Response;
using Newtonsoft.Json;
using AssetManagement.Application.Tests.TestHelper;

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
                Gender = Domain.Enums.AppUser.UserGender.Female,
                JoinedDate = new(2022, 11, 28),
                Type = "Admin"
            };

            string staffCode = _context.AppUsers.ToList()[index].StaffCode;

            UserController controller = new UserController(_context, _userManager.Object, _mapper);

            //ACT
            IActionResult result = await controller.UpdateUserAsync(staffCode, request);
            string data = ConvertOkObject<UpdateUserResponse>(result);
            string expected = JsonConvert.SerializeObject(
                _mapper.Map<UpdateUserResponse>(_context.AppUsers.ToList()[index])
            );

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(data);
            Assert.Equal(expected, data);
        }

        [Fact]
        public async Task EditUser_BadRequest_UnderAgeAsync()
        {
            //ARRANGE
            UpdateUserRequest request = new()
            {
                Dob = DateTime.Now.AddYears(-18).AddSeconds(1),
                Gender = Domain.Enums.AppUser.UserGender.Female,
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
                Gender = Domain.Enums.AppUser.UserGender.Female,
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
                Gender = Domain.Enums.AppUser.UserGender.Female,
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
                Gender = Domain.Enums.AppUser.UserGender.Female,
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
