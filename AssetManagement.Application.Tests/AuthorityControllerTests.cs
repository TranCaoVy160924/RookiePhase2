using AssetManagement.Application.Controllers;
using AssetManagement.Contracts.Authority.Request;
using AssetManagement.Contracts.Authority.Response;
using AssetManagement.Contracts.AutoMapper;
using AssetManagement.Contracts.Common;
using AssetManagement.Data.EF;
using AssetManagement.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Security.Principal;

namespace AssetManagement.Application.Tests
{
    public class AuthorityControllerTests : IDisposable
    {
        private readonly DbContextOptions _options;
        private readonly AssetManagementDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly Mock<UserManager<AppUser>> _userManager;
        private List<AppRole>? _roles;
        private List<AppUser>? _users;

        public AuthorityControllerTests()
        {
            //Create InMemory dbcontext options
            _options = new DbContextOptionsBuilder<AssetManagementDbContext>().UseInMemoryDatabase("AuthTestDB").Options;
            //Create InMemory dbcontext with options
            _context = new AssetManagementDbContext(_options);
            //Create mapper using UserProfile
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new UserProfile())).CreateMapper();
            //Create fake config with fake jwt settings
            Dictionary<string, string> inMemorySettings = new()  {
                {"JwtSettings:validIssuer", "issuer"},
                {"JwtSettings:expires", "1"},
                {"JwtSettings:Key", "!^##7w7$3tt!n9Key##^!" }
            };
            _config = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            //Mock UserManager
            //Create UserStore mock to enable user support for UserManager
            Mock<IUserStore<AppUser>> userStoreMoq = new();
            //Create UserManager mock using userStoreMoq
            _userManager = new(userStoreMoq.Object, null, null, null, null, null, null, null, null);
            //Create fake data
            SeedData();
        }

        //Tests
        [Theory]
        [InlineData(0, "binhnv")]
        [InlineData(1, "annv")]
        public void GetUserProfile_Success(int index, string username)
        {
            //ARRANGE
            //Set up UserManager, assume that user is stored
            _userManager.Setup(um => um.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(_users[index]);
            //Create controller
            AuthorityController controller = new AuthorityController(_userManager.Object, _config, _context, _mapper);
            //Create context for controller with fake login
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new GenericPrincipal(new GenericIdentity(username), null)
                }
            };

            //ACT
            //Get current login profile
            IActionResult result = controller.GetUserProfile().Result;

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equivalent(_mapper.Map<UserResponse>(_users[index]) , ((OkObjectResult)result).Value);
        }

        [Fact]
        public void Authenticate_Success()
        {
            //ARRANGE
            //Create login request (no need password)
            LoginRequest request = new() { Username = "binhnv" };
            //Set up UserManager, assume that login request is correct
            _userManager.Setup(um => um.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(_users[0]);
            _userManager.Setup(um => um.CheckPasswordAsync(It.IsAny<AppUser>(), It.IsAny<string>())).ReturnsAsync(true);
            //Create controller
            AuthorityController controller = new AuthorityController(_userManager.Object, _config, _context, _mapper);
            
            //ACT
            IActionResult result = controller.Authenticate(request).Result;

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData(null, "123")]
        [InlineData("binhnv", null)]
        [InlineData(null, null)]
        public void Authenticate_BadRequest_ModelState_Invalid(string username, string password)
        {
            //ARRANGE
            LoginRequest request = new() { Username = username, Password = password };
            //Create controller
            AuthorityController controller = new AuthorityController(_userManager.Object, _config, _context, _mapper);
            if(username == null) controller.ModelState.AddModelError("username", "Please enter username");
            if (password == null) controller.ModelState.AddModelError("password", "Please enter password");

            //ACT
            IActionResult result = controller.Authenticate(request).Result;
            SerializableError? errors = (SerializableError?)((ObjectResult)result).Value;

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);

            if (errors != null && errors.ContainsKey("username"))
            {
                string? message = (errors["username"] as string[])?.FirstOrDefault();
                Assert.Equal("Please enter username", message);
            }
            if (errors != null && errors.ContainsKey("password")) {
                string? message = (errors?["password"] as string[])?.FirstOrDefault();
                Assert.Equal("Please enter password", message);
            }
        }

        [Theory]
        [InlineData("thanhnv")]
        [InlineData("datnv")]
        public void Authenticate_BadRequest_Username(string username)
        {
            // ARRANGE
            //Create login request (no need password)
            LoginRequest request = new() { Username = username };
            //Set up UserManager
            _userManager.Setup(um => um.FindByNameAsync(username))
                        .ReturnsAsync(_users.FirstOrDefault(u => u.UserName == username));

            AuthorityController controller = new AuthorityController(_userManager.Object, _config, _context, _mapper);
            //ACT
            IActionResult result = controller.Authenticate(request).Result;
            string message = ((ErrorResponseResult<string>)((ObjectResult)result).Value).Message;

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Account does not exist.", message);
        }

            //Create InMemory Data
            private void SeedData()
        {
            //Make sure InMemory data is deleted before creating new data
            //To avoid duplicated keys error
            _context.Database.EnsureDeleted();
            _roles = new()
            {
                new AppRole(){
                    Id = new Guid(1, 2, 3, 4, 4, 4, 4, 4, 4, 4, 4),
                    Name = "Admin",
                    Description = "Admin role"
                },

                new AppRole(){
                    Id = new Guid(1, 2, 3, 4, 4, 4, 4, 4, 4, 4, 5),
                    Name = "Staff",
                    Description = "Staff role"
                }
            };
            _users = new()
            {
                new AppUser(){
                    FirstName = "Binh", LastName = "Nguyen Van", UserName = "binhnv", Email = "bnv@gmail.com",
                    Gender = "Male", Location = "HCM", RoleId = _roles[0].Id
                },

                new AppUser(){
                    FirstName = "An", LastName = "Nguyen Van", UserName = "annv", Email = "anv@gmail.com",
                    Gender = "Female", Location = "HCM", RoleId = _roles[0].Id
                }
            };

            //Add roles
            _context.AppRoles.AddRange(_roles);
            //Add users
            _context.AppUsers.AddRange(_users);
            _context.SaveChanges();
        }

        //Clean up after tests
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}