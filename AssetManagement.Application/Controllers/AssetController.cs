using AssetManagement.Contracts.Asset.Request;
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
    public class AssetController : ControllerBase
    {
        private readonly AssetManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public AssetController(AssetManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost("asset/create")]
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


        [HttpDelete("asset/delete")]
        [Authorize]
        public async Task<IActionResult> DeleteAsset(DeleteAssetRequest deleteAssetRequest)
        {
            Asset deletingAsset = await _dbContext.Assets
                .Where(a => !a.IsDeleted && a.Id == deleteAssetRequest.Id)
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

            return Ok();
        }
    }
}
