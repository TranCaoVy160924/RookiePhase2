using AssetManagement.Contracts.User.Request;
using AssetManagement.Contracts.User.Response;
using AssetManagement.Data.EF;
using AssetManagement.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AssetManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserController(AssetManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(string staffCode, UpdateUserRequest request)
        {
            if (ModelState.IsValid)
            {
                if(request.Dob < DateTime.Now.AddYears(-18))
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
                
                if (user != null || role != null)
                {
                    try
                    {
                        IdentityUserRole<Guid>? roleKey = _dbContext.UserRoles.FirstOrDefault(ur => ur.UserId == user.Id);

                        user.Dob = request.Dob;
                        user.CreatedDate = request.JoinedDate;
                        user.Gender = request.Gender;
                        roleKey.UserId = user.Id;
                        roleKey.RoleId = role.Id;

                        await _dbContext.SaveChangesAsync();
                        return Ok(_mapper.Map<UpdateUserResponse>(user));
                    }

                    catch (Exception e) { return BadRequest(e.Message); }
                }

                return NotFound();
            }

            return BadRequest(ModelState);
        }
    }
}
