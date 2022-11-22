using AssetManagement.Contracts.Category.Request;
using AssetManagement.Contracts.Category.Response;
using AssetManagement.Data.EF;
using AssetManagement.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManagement.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AssetManagementDbContext _dbContext;

        public CategoryController(IMapper mapper, AssetManagementDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<List<GetCategoryResponse>> GetAsync()
        {
            List<Category> categories = await _dbContext.Categories.Where(c => !c.IsDeleted).ToListAsync();
            return _mapper.Map<List<GetCategoryResponse>>(categories);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                Category? category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == request.Name.ToLower()
                                                                                          || c.Prefix.ToLower() == request.Prefix.ToLower());
                if (category != null)
                {
                    if (category.Name.ToLower() == request.Name.ToLower()) return BadRequest("Category is already existed. Please enter a different category");
                    return BadRequest("Prefix is already existed. Please enter a different prefix");
                }

                try
                {
                    request.Prefix = request.Prefix.ToUpper();
                    await _dbContext.Categories.AddAsync(_mapper.Map<Category>(request));
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception error) { return BadRequest(error.Message); }
            }

            return BadRequest(ModelState);
        }

    }
}
