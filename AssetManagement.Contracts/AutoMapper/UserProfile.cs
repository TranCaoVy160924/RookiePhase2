using AssetManagement.Contracts.Authority.Response;
using AssetManagement.Contracts.User.Response;
using AssetManagement.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Contracts.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserResponse>();
            CreateMap<AppUser, UpdateUserResponse>();

            CreateMap<AppUser, ViewDetailUser_UserResponse>().ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.Dob))
                                                             .ForMember(dest => dest.JoinedDate, opt => opt.MapFrom(src => src.CreatedDate));
            
            CreateMap<AppUser, ViewListUser_UserResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StaffCode))
                                                           .ForMember(dest => dest.JoinedDate, opt => opt.MapFrom(src => src.CreatedDate));
        }
    }
}
