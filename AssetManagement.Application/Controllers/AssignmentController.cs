﻿using AssetManagement.Contracts.Assignment.Response;
using AssetManagement.Data.EF;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Application.Controllers
{
    [Route("api")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly AssetManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public AssignmentController(AssetManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //[HttpGet("assignement/{assetCodeId}")]  
        ////[Authorize]
        //public IActionResult GetAssignmentsByAssetCodeId(int assetCodeId)
        //{
        //    var result = _dbContext.Assignments.Where(x => x.AssetId == assetCodeId).ToList();
        //    var assignmentResponse = _mapper.Map<List<AssignmentResponse>>(result);

        //    foreach (var item in assignmentResponse)
        //    {
        //        item.AssignedTo = _dbContext.Users.Find(new Guid(item.AssignedTo)).UserName;
        //        item.AssignedBy = _dbContext.Users.Find(new Guid(item.AssignedBy)).UserName;
        //    }

        //    return Ok(assignmentResponse);
        //}
    }
}
