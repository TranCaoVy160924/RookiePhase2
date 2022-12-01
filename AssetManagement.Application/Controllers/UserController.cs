﻿using AssetManagement.Contracts.User.Request;
using AssetManagement.Contracts.User.Response;
using AssetManagement.Data.EF;
using AssetManagement.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AssetManagement.Contracts.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AssetManagement.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AssetManagementDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserController(AssetManagementDbContext dbContext, UserManager<AppUser> userManager, IMapper mapper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<ViewList_ListResponse<ViewListUser_UserResponse>>> GetAllUser(
            [FromQuery] int start,
            [FromQuery] int end,
            [FromQuery] string? stateFilter = "",
            [FromQuery] string? searchString = "",
            [FromQuery] string? sort = "staffCode",
            [FromQuery] string? order = "ASC")
        {
            string userName = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name)?.Value;
            AppUser currentUser = await _dbContext.AppUsers.FirstAsync(x => x.UserName == userName);
            IQueryable<AppUser> users = _dbContext.AppUsers
                                            .Where(x => x.IsDeleted==false && x.Location==currentUser.Location);

            if (!string.IsNullOrEmpty(stateFilter))
            {
                var listType = stateFilter.Split("&");
                List<AppUser> tempData = new List<AppUser>();
                for (int i=0; i<listType.Length-1; i++)
                {
                    string roleName = listType[i] == "Admin" ? "Admin" : "Staff";
                    IQueryable<AppUser> tempUser = _userManager.GetUsersInRoleAsync(roleName).Result.AsQueryable<AppUser>();
                    tempData.AddRange(tempUser);
                }
                users = users.Where(x => tempData.Contains(x));
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(x => (x.FirstName + ' ' + x.LastName).Contains(searchString)
                                        || x.StaffCode.Contains(searchString));
            }

            switch (sort)
            {
                case "staffCode":
                    {
                        users = users.OrderBy(x => x.StaffCode);
                        break;
                    }
                case "fullName":
                    {
                        users = users.OrderBy(x => x.FirstName + ' ' + x.LastName);
                        break;
                    }
                case "userName":
                    {
                        users = users.OrderBy(x => x.UserName);
                        break;
                    }
                case "joinedDate":
                    {
                        users = users.OrderBy(x => x.CreatedDate);
                        break;
                    }
                case "type":
                    {
                        var userWithRole = from user in users
                                           join userRole in _dbContext.UserRoles
                                           on user.Id equals userRole.UserId
                                           join role in _dbContext.Roles
                                           on userRole.RoleId equals role.Id
                                           orderby role.NormalizedName
                                           select user;
                        users = userWithRole;
                        break;
                    }
                default:
                    {
                        users = users.OrderBy(x => x.StaffCode);
                        break;
                    }
            }

            if (order == "DESC")
            {
                users = users.Reverse();
            }

            List<AppUser> sortedUsers = StaticFunctions<AppUser>.Paging(users, start, end);

            List<ViewListUser_UserResponse> mapResult = new List<ViewListUser_UserResponse>();

            //int tempCount = 0;
            foreach (AppUser user in sortedUsers)
            {
                ViewListUser_UserResponse userData = _mapper.Map<ViewListUser_UserResponse>(user);
                //userData.Id = tempCount;
                string userRole = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
                if (string.IsNullOrEmpty(userRole))
                {
                    continue;
                }
                userData.Type = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
                mapResult.Insert(0, userData);
                //tempCount += 1;
            }

            return Ok(new ViewList_ListResponse<ViewListUser_UserResponse>
            {
                Data = mapResult,
                Total = mapResult.Count
            });
        }

        [HttpGet("{staffCode}")]
        public async Task<ActionResult<SuccessResponseResult<ViewDetailUser_UserResponse>>> GetSingleUser([FromRoute] string staffCode)
        {
            AppUser user = _dbContext.AppUsers.Where(x => x.StaffCode.Trim()==staffCode.Trim()).FirstOrDefault();

            if (user == null)
            {
                return BadRequest(new ErrorResponseResult<string>("Invalid StaffCode"));
            }

            ViewDetailUser_UserResponse result = _mapper.Map<ViewDetailUser_UserResponse>(user);
            result.Type = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
            return Ok(new SuccessResponseResult<ViewDetailUser_UserResponse>
            {
                Result = result,
                IsSuccessed = true
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{StaffCode}")]
        public async Task<IActionResult> UpdateUserAsync(string staffCode, UpdateUserRequest request)
        {
            if (ModelState.IsValid)
            {
                if(request.Dob > DateTime.Now.AddYears(-18))
                {
                    return BadRequest("User is under 18. Please select a different date");
                }

                if(request.JoinedDate < request.Dob.AddYears(18))
                {
                    return BadRequest("User under the age 18 may not join the company. Please select a different date");
                }

                if(request.JoinedDate.DayOfWeek == DayOfWeek.Saturday || request.JoinedDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    return BadRequest("Joined date is Saturday or Sunday. Please select a different date");
                }

                AppUser? user = _dbContext.AppUsers.FirstOrDefault(u => u.StaffCode == staffCode && !u.IsDeleted);
                AppRole? role = _dbContext.AppRoles.FirstOrDefault(r => r.Name == request.Type);
                
                if (user != null && role != null)
                {
                    try
                    {
                        IdentityUserRole<Guid>? roleKey = _dbContext.UserRoles.FirstOrDefault(ur => ur.UserId == user.Id);

                        user.Dob = request.Dob;
                        user.CreatedDate = request.JoinedDate;
                        user.Gender = (Domain.Enums.AppUser.UserGender)request.Gender;
                        user.ModifiedDate = DateTime.Now;
                        roleKey.UserId = user.Id;
                        roleKey.RoleId = role.Id;

                        await _dbContext.SaveChangesAsync();
                        UpdateUserResponse response = _mapper.Map<UpdateUserResponse>(user);
                        response.Type = request.Type;
                        return Ok(response);
                    }

                    catch (Exception e) { return BadRequest(e.Message); }
                }

                return NotFound();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletingUser = await _dbContext.AppUsers.FirstOrDefaultAsync(x => x.Id == id);
            var userName = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            if (deletingUser != null)
            {
                if (deletingUser.UserName == userName)
                {
                    return BadRequest(new ErrorResponseResult<string>("You can't delete yourself"));
                }
                deletingUser.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                return BadRequest(new ErrorResponseResult<string>("Can't find this user"));
            }

            return Ok(_mapper.Map<DeleteUserResponse>(deletingUser));
        }
    }
}
