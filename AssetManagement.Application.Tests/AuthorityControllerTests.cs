using AssetManagement.Application.Controllers;
using AssetManagement.Application.Tests.Mocks;
using AssetManagement.Contracts.Authority.Response;
using AssetManagement.Contracts.AutoMapper;
using AssetManagement.Data.EF;
using AssetManagement.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Security.Claims;
using System.Security.Principal;

namespace AssetManagement.Application.Tests
{
    public class AuthorityControllerTests : IDisposable
    {
        private readonly DbContextOptions _options;
        private readonly AssetManagementDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

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
                {"JwtSettings:validIssuer", "bruh"},
                {"JwtSettings:expires", "1"},
            };
            _config = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            //Create fake data
            SeedData();
        }

        [Fact]
        public void GetUserProfile_SuccessAsync()
        {
            //ARRANGE
            //Create fake user
            AppUser user = new AppUser() { UserName="John" };
            //Create UserStore mock
            Mock<IUserStore<AppUser>> userStoreMoq = new();
            //Create UserManager mock using userStoreMoq
            Mock<UserManager<AppUser>> userManagerMoq = new(userStoreMoq.Object, null, null, null, null, null, null, null, null);
            //Set up
            userManagerMoq.Setup(um => um.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(user);
            //Create controller
            AuthorityController controller = new AuthorityController(userManagerMoq.Object, _config, _context, _mapper);
            //Create context for controller with fake login
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new GenericPrincipal(new GenericIdentity("John"), null)
                }
            };

            //ACT
            IActionResult result = controller.GetUserProfile().Result;

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equivalent(_mapper.Map<UserResponse>(user) , ((OkObjectResult)result).Value);
        }

        //Create InMemory Data
        public void SeedData()
        {
            //Make sure InMemory data is deleted before creating new data
            //To avoid duplicated keys error
            _context.Database.EnsureDeleted();
        }

        //Clean up after tests
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}