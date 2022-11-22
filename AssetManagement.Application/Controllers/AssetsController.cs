using AssetManagement.Contracts.Asset.Request;
using AssetManagement.Contracts.Asset.Response;
using AssetManagement.Contracts.Common;
using AssetManagement.Data.EF;
using AssetManagement.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly AssetManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public AssetsController(AssetManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpPost()]
        [Authorize]
        public async Task<IActionResult> CreateAsset(CreateAssetRequest createAssetRequest)
        {
            Category category = await _dbContext.Categories.FindAsync(createAssetRequest.CategoryId);
            if (category == null)
            {
                return BadRequest(new ErrorResponseResult<string>("Invalid Category"));
            }
            Asset asset = _mapper.Map<Asset>(createAssetRequest);

            int countAsset = await _dbContext.Assets.Where(_ => _.AssetCode.StartsWith(category.Prefix)).CountAsync();
            asset.AssetCode = category.Prefix + Convert.ToDecimal((countAsset + 1) / 1000000.0).ToString().Split('.')[1];
            asset.Category = category;

            await _dbContext.Assets.AddAsync(asset);
            await _dbContext.SaveChangesAsync();
            return Ok(new SuccessResponseResult<string>("Create Asset sucessfully"));
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateAssetRequest request)
        {
            Asset updatingAsset = await _dbContext.Assets
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            try
            {
                if (updatingAsset != null)
                {
                    updatingAsset.Name = request.Name;
                    updatingAsset.Specification = request.Specification;
                    updatingAsset.InstalledDate = request.InstalledDate;
                    updatingAsset.State = request.State;
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Cannot find a asset with id: {id}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponseResult<string>(ex.Message));
            }

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            Asset deletingAsset = await _dbContext.Assets
                .Where(a => !a.IsDeleted && a.Id == id)
                .FirstOrDefaultAsync();

            try
            {
                if (deletingAsset != null)
                {
                    deletingAsset.IsDeleted = true;
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("The asset does not exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponseResult<string>(ex.Message));
            }

            return Ok(_mapper.Map<DeleteAssetReponse>(deletingAsset));
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<ViewListAssets_ListResponse>> Get([FromQuery] int end, [FromQuery] int start, [FromQuery] string? categoryFilter = "", [FromQuery] string? stateFilter = "", [FromQuery] string? sort = "Name", [FromQuery] string? order = "ASC")
        {
            var list = _dbContext.Assets.Include(x => x.Category).AsQueryable();
            if (categoryFilter != "")
            {
                list = list.Where(x => x.CategoryId == int.Parse(categoryFilter));
            }
            if (stateFilter != "")
            {
                list = list.Where(x => (int)x.State == int.Parse(stateFilter));
            }
            switch (sort)
            {
                case "assetCode":
                    {
                        list = list.OrderBy(x => x.AssetCode);
                        break;
                    }
                case "name":
                    {
                        list = list.OrderBy(x => x.Name);
                        break;
                    }
                case "category":
                    {
                        list = list.OrderBy(x => x.Category.Name);
                        break;
                    }
                case "state":
                    {
                        list = list.OrderBy(x => x.State);
                        break;
                    }
                case "id":
                    {
                        list = list.OrderBy(x => x.Id);
                        break;
                    }
            }

            if (order == "DESC")
            {
                list = list.Reverse();
            }
            //var result = StaticFunctions<Asset>.Sort(list, sort, order);
            var sortedResult = StaticFunctions<Asset>.Paging(list, start, end);

            var mappedResult = _mapper.Map<List<ViewListAssets_AssetResponse>>(sortedResult);

            return Ok(new ViewListAssets_ListResponse { Assets = mappedResult, Total = list.Count() });
        }
    }
}
