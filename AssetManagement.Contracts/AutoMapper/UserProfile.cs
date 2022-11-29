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
            CreateMap<AppUser, ViewListUser_UserResponse>().ForMember(dest => dest.Id, opt => opt.Ignore())
                                                           .ForMember(dest => dest.JoinedDate, opt => opt.MapFrom(src => src.CreatedDate));
        }
    }
}
