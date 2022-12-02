﻿// using AssetManagement.Contracts.Assignment.Request;
using AssetManagement.Contracts.Assignment.Response;
using AssetManagement.Contracts.Common;
using AssetManagement.Data.EF;
using AssetManagement.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Http;
using AssetManagement.Domain.Enums.Assignment;
using AssetManagement.Contracts.Assignment.Request;
// using System;
// using System.Globalization;

namespace AssetManagement.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly AssetManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public AssignmentsController(
            AssetManagementDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("assets/{assetCodeId}")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetAssignmentsByAssetCodeId(int assetCodeId)
        {
            var result = _dbContext.Assignments.Where(x => x.AssetId == assetCodeId).ToList();
            var assignmentResponse = _mapper.Map<List<AssignmentResponse>>(result);

            foreach (var item in assignmentResponse)
            {
                item.AssignedTo = _dbContext.Users.Find(new Guid(item.AssignedTo)).UserName;
                item.AssignedBy = _dbContext.Users.Find(new Guid(item.AssignedBy)).UserName;
            }

            return Ok(assignmentResponse);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignmentDetail(int id)
        {
            var assignment = await _dbContext.Assignments
                .Include(x => x.Asset)
                .Include(x => x.AssignedToAppUser)
                .Include(x => x.AssignedByAppUser)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            if (assignment != null)
            {
                return Ok(_mapper.Map<AssignmentDetailResponse>(assignment));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAssignment(int id, UpdateAssignmentRequest request)
        {
            Assignment updatingAssignment = await _dbContext.Assignments
                .Include(a => a.Asset)
                .Include(a => a.AssignedToAppUser)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            try
            {
                if (updatingAssignment != null && updatingAssignment.State == State.WaitingForAcceptance)
                {
                    if (AssignmentChanged(updatingAssignment, request))
                    {
                        AppUser assignedToUser = await _dbContext.AppUsers
                            .Where(u => u.StaffCode.Equals(request.AssignToAppUserStaffCode))
                            .FirstOrDefaultAsync();

                        Asset asset = await _dbContext.Assets
                            .Where(a => a.AssetCode.Equals(request.AssetCode))
                            .FirstOrDefaultAsync();

                        if (assignedToUser != null && asset != null)
                        {
                            updatingAssignment.AssignedTo = assignedToUser.Id;
                            updatingAssignment.AssetId = asset.Id;
                            updatingAssignment.AssignedDate = request.AssignedDate;
                            updatingAssignment.Note = request.Note;
                            await _dbContext.SaveChangesAsync();
                        }
                        else
                        {
                            throw new Exception("User or asset is invalid");
                        }
                    }
                }
                else
                {
                    throw new Exception($"Cannot find an assignment with id: {id}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponseResult<string>(ex.Message));
            }

            return Ok(_mapper.Map<UpdateAssignmentResponse>(updatingAssignment));
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ViewList_ListResponse<ViewListAssignmentResponse>>> Get(
            [FromQuery] int start,
            [FromQuery] int end,
            [FromQuery] string? searchString = "",
            [FromQuery] string? assignedDateFilter = "",
            [FromQuery] string? stateFilter = "",
            [FromQuery] string? sort = "name",
            [FromQuery] string? order = "ASC",
            [FromQuery] string? createdId = "")
        {
            // var listDefault = _dbContext.Assignments
            //     .Include(x => x.Asset)
            //     .Include(x => x.AssignedToAppUser)
            //     .Include(x => x.AssignedByToAppUser)
            //     .Where(x => !x.IsDeleted)
            //     .Select(x => new ViewListAssignmentResponse
            //     {
            //         Id = x.Id,
            //         AssetCode = x.Asset.AssetCode,
            //         AssetName = x.Asset.Name,
            //         AssignedTo = x.AssignedToAppUser.UserName,
            //         AssignedBy = x.AssignedByToAppUser.UserName,
            //         AssignedDate = x.AssignedDate,
            //         State = x.State,
            //     }).ToList();



            // var list = listDefault.Select((x, index) => new ViewListAssignmentResponse
            // {
            //     Id = x.Id,
            //     NoNumber = index + 1,
            //     AssetCode = x.AssetCode,
            //     AssetName = x.AssetName,
            //     AssignedTo = x.AssignedTo,
            //     AssignedBy = x.AssignedBy,
            //     AssignedDate = x.AssignedDate,
            //     State = x.State,
            // }).AsQueryable<ViewListAssignmentResponse>();

            var list = _dbContext.Assignments
                // .Include(x => x.Asset)
                // .Include(x => x.AssignedToAppUser)
                // .Include(x => x.AssignedByToAppUser)
                .Where(x => !x.IsDeleted)
                .Select(x => new ViewListAssignmentResponse
                {
                    Id = x.Id,
                    NoNumber = x.Id,
                    AssetCode = x.Asset.AssetCode,
                    AssetName = x.Asset.Name,
                    AssignedTo = x.AssignedToAppUser.UserName,
                    AssignedBy = x.AssignedByAppUser.UserName,
                    AssignedDate = x.AssignedDate,
                    State = x.State,
                });

            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.AssetName.ToUpper().Contains(searchString.ToUpper()) || x.AssetCode.ToUpper().Contains(searchString.ToUpper()));
            }
            if (!string.IsNullOrEmpty(assignedDateFilter))
            {
                list = list.Where(x => x.AssignedDate.Date == DateTime.Parse(assignedDateFilter).Date);
            }
            if (!string.IsNullOrEmpty(stateFilter))
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
                list = list.Where(x => arrNumberChar.Contains((int)x.State));
            }
            switch (sort)
            {
                case "id":
                    {
                        list = list.OrderBy(x => x.Id);
                        break;
                    }
                case "noNumber":
                    {
                        list = list.OrderBy(x => x.NoNumber);
                        break;
                    }
                case "assetCode":
                    {
                        list = list.OrderBy(x => x.AssetCode);
                        break;
                    }
                case "assetName":
                    {
                        list = list.OrderBy(x => x.AssetName);
                        break;
                    }
                case "assignedTo":
                    {
                        list = list.OrderBy(x => x.AssignedTo);
                        break;
                    }
                case "assignedBy":
                    {
                        list = list.OrderBy(x => x.AssignedBy);
                        break;
                    }
                case "assignedDate":
                    {
                        list = list.OrderBy(x => x.AssignedDate);
                        break;
                    }
                case "state":
                    {
                        list = list.OrderBy(x => x.State);
                        break;
                    }
            }

            if (order == "DESC")
            {
                list = list.Reverse();
            }

            if (!string.IsNullOrEmpty(createdId))
            {
                var newList = list.Where(item => item.Id == int.Parse(createdId));
                list = list.Where(item => item.Id != int.Parse(createdId));
                list = newList.Concat(list);
            }

            var sortedResult = StaticFunctions<ViewListAssignmentResponse>.Paging(list, start, end);

            // var mappedResult = _mapper.Map<List<ViewListAssignmentResponse>>(list);

            return Ok(new ViewListPageResult<ViewListAssignmentResponse> { Data = sortedResult, Total = list.Count() });
            // return Ok(listWithIndex);
        }

        private bool AssignmentChanged(Assignment updatingAssignment, UpdateAssignmentRequest updateRequest)
        {
            if (updatingAssignment.AssignedToAppUser.StaffCode == updateRequest.AssignToAppUserStaffCode
                && updatingAssignment.Asset.AssetCode == updateRequest.AssetCode
                && updatingAssignment.AssignedDate.Equals(updateRequest.AssignedDate)
                && updatingAssignment.Note.Equals(updateRequest.Note))
            {
                return false;
            }
            return true;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Assignment? assignment = await _dbContext.Assignments.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            if(assignment != null)
            {
                try
                {
                    assignment.IsDeleted = true;
                    await _dbContext.SaveChangesAsync();
                    return Ok(_mapper.Map<AssignmentResponse>(assignment));
                }
                catch (Exception e) { return BadRequest(e.Message); }
            }
            return NotFound("Assignment does not exist");
        }
    }
}
