using Microsoft.EntityFrameworkCore;
using AssetManagement.Data.EF;
using AutoMapper;
using AssetManagement.Contracts.AutoMapper;
using AssetManagement.Domain.Models;
using Xunit;
using AssetManagement.Contracts.Category.Response;
using AssetManagement.Contracts.Category.Request;
using Microsoft.AspNetCore.Mvc;

#nullable disable
namespace AssetManagement.Application.Controllers.Tests
{

    public class CategoryControllerTests : IDisposable
    {
        private readonly DbContextOptions _options;
        private readonly AssetManagementDbContext _context;
        private readonly IMapper _mapper;
        private List<Category>? _categories;
        public CategoryControllerTests()
        {
            //Create InMemory dbcontext
            _options = new DbContextOptionsBuilder<AssetManagementDbContext>().UseInMemoryDatabase("AuthTestDB").Options;
            _context = new AssetManagementDbContext(_options);
            //Create mapper using CategoryProfile
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new CategoryProfile())).CreateMapper();

            SeedData();
        }

        [Fact]
        public async Task Get_SuccessAsync()
        {
            //ARRANGE
            CategoryController controller = new(_mapper, _context);

            //ACT
            List<GetCategoryResponse> result = await controller.GetAsync();

            //ASSERT
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equivalent(_mapper.Map<List<GetCategoryResponse>>(_categories), result);
        }

        [Theory]
        [InlineData("Mouse", "Ms")]
        public async Task Create_SuccessAsync(string name, string prefix)
        {
            //ARRANGE
            CreateCategoryRequest request = new() { Name = name, Prefix = prefix };
            CategoryController controller = new(_mapper, _context);

            //ACT
            var result = await controller.CreateAsync(request);
            Category? newCat = _context.Categories.LastOrDefault();

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
            Assert.NotNull(newCat);
            Assert.Equal(newCat.Name.ToLower(), request.Name.ToLower());
            Assert.Equal(newCat.Prefix.ToLower(), request.Prefix.ToLower());
        }

        [Theory]
        [InlineData(null, "KY")]
        [InlineData("Kettle", null)]
        [InlineData(null, null)]
        public async Task Create_Badrequest_ModelState_InvalidAsync(string name, string prefix)
        {
            //ARRANGE
            CreateCategoryRequest request = new() { Name = name, Prefix = prefix };
            CategoryController controller = new(_mapper, _context);
            //Assume controller has modelstate errors to simulate data annotations
            if (name == null) controller.ModelState.AddModelError("name", "Please enter Category Name");
            if (prefix == null) controller.ModelState.AddModelError("prefix", "Please enter Category Prefix");

            //ACT
            IActionResult result = await controller.CreateAsync(request);
            SerializableError error = (SerializableError)((ObjectResult)result).Value;

            //ASSERT
            Assert.IsType<BadRequestObjectResult>(result);
            if (error.ContainsKey("name"))
            {
                Assert.Equal("Please enter Category Name", ((string[])error["name"])[0]);
            }

            if (error.ContainsKey("prefix"))
            {
                Assert.Equal("Please enter Category Prefix", ((string[])error["prefix"])[0]);
            }
        }

        [Theory]
        [InlineData("KeyBoard", "KY")]
        [InlineData("laptop", "LA")]
        [InlineData("mOnitoR", "Mn")]
        public async Task Create_Badrequest_UniqueNameAsync(string name, string prefix)
        {
            //ARRANGE
            CreateCategoryRequest request = new() { Name = name, Prefix = prefix };
            CategoryController controller = new(_mapper, _context);

            //ACT
            IActionResult result = await controller.CreateAsync(request);
            string message = ((ObjectResult)result).Value.ToString();
            //ASSERT
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Category is already existed. Please enter a different category", message);
        }

        [Theory]
        [InlineData("Mouse", "MO")]
        [InlineData("Lube Tube", "lT")]
        [InlineData("Kibble", "kb")]
        public async Task Create_Badrequest_UniquePrefixAsync(string name, string prefix)
        {
            //ARRANGE
            CreateCategoryRequest request = new() { Name = name, Prefix = prefix };
            CategoryController controller = new(_mapper, _context);

            //ACT
            IActionResult result = await controller.CreateAsync(request);
            string message = ((ObjectResult)result).Value.ToString();
            //ASSERT
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Prefix is already existed. Please enter a different prefix", message);
        }
        private void SeedData()
        {
            _context.Database.EnsureDeleted();
            _categories = new()
            {
                new (){Name = "Laptop", Prefix = "LT", IsDeleted = false },
                new (){Name = "Monitor", Prefix = "MO", IsDeleted = false },
                new (){Name = "Keyboard", Prefix = "KB", IsDeleted = false },
            };

            _context.Categories.AddRange(_categories);
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