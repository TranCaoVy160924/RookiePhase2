using AssetManagement.Contracts.Authority.Response;
using AssetManagement.Domain.Models;
using AutoMapper;
using AssetManagement.Contracts.User.Response;

namespace AssetManagement.Contracts.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserResponse>();
            CreateMap<AppUser, UpdateUserResponse>();
        }
    }
}
