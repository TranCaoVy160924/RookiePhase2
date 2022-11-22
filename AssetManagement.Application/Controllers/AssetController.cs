﻿using AssetManagement.Contracts.Asset.Request;
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
        //private readonly IMapper _mapper;

        public AssetController(
            AssetManagementDbContext dbContext
            //IMapper mapper
            )
        {
            _dbContext = dbContext;
            //_mapper = mapper;
        }

        [HttpPut("{id}")]
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
                    updatingAsset.InstalledDate = request.InstalledDate ;
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

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
