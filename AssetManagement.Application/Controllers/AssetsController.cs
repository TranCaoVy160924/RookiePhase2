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
        public async Task<ActionResult<ViewListAssets_ListResponse>> Get([FromQuery]int end, [FromQuery]int start, [FromQuery]string? searchString="", [FromQuery]string? categoryFilter="", [FromQuery]string? stateFilter="", [FromQuery]string? sort="Name", [FromQuery]string? order="ASC")
        {
<<<<<<< Updated upstream
            var list = _dbContext.Assets.Include(x=>x.Category).AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.Name.Contains(searchString) || x.AssetCode.Contains(searchString));
            }
=======
            var list = _dbContext.Assets
                .Include(x=>x.Category)
                .Where(x=>!x.IsDeleted)
                .AsQueryable();
>>>>>>> Stashed changes
            if(categoryFilter != "")
            {
                list = list.Where(x => x.CategoryId == int.Parse(categoryFilter));
            }
            if(!string.IsNullOrEmpty(stateFilter))
            {
                var arrayChar = stateFilter.Split("&");
                var arrNumberChar = new List<int>();
                for (int i = 0; i < arrayChar.Length; i++)
                {
                    var temp = 0;
                    if (int.TryParse(arrayChar[i], out temp))
                    {
                        arrNumberChar.Add(int.Parse(arrayChar[i]));
                    }
                }
                list = list.Where(x=> arrNumberChar.Contains((int)x.State));
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

            return Ok(new ViewListAssets_ListResponse { Assets = mappedResult, Total=list.Count()});
        }
    }
}
