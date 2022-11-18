using AssetManagement.Application.Controllers;
using AssetManagement.Application.Tests.Mocks;
using AssetManagement.Contracts.AutoMapper;
using AssetManagement.Data.EF;
using AssetManagement.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace AssetManagement.Application.Tests
{
    public class AuthorityControllerTests : IDisposable
    {
        private readonly DbContextOptions _options;
        private readonly AssetManagementDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManagerMoq _userManager;
        private readonly IConfiguration _config;

        public AuthorityControllerTests()
        {
            //Create InMemory dbcontext options
            _options = new DbContextOptionsBuilder<AssetManagementDbContext>().UseInMemoryDatabase("AuthTestDB").Options;
            //Create InMemory dbcontext with options
            _context = new AssetManagementDbContext(_options);
            //Create mapper using UserProfile
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new UserProfile())).CreateMapper();
            //Create fake userManager
            _userManager = new UserManagerMoq();
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
        public void GetUserProfile_Unauthorized()
        {
            AuthorityController controller = new AuthorityController(_userManager, _config, _context, _mapper);
            Thread.CurrentPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>() { new Claim("name", "John Doe") }));
            var result = controller.GetUserProfile();
            Assert.NotNull(result);
        }

        //Create InMemory Data
        public void SeedData()
        {
            //Make sure InMemory data is deleted before creating new data
            //To avoid duplicated keys error
            _context.Database.EnsureDeleted();
            AppUser user = new AppUser() { UserName = "username"};
            _userManager.CreateAsync(user).Wait();
        }

        //Clean up after tests
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}