using AssetManagement.Contracts.Asset.Response;
using AssetManagement.Contracts.Authority.Response;
using AssetManagement.Domain.Models;
using AssetManagement.Contracts.Asset.Request;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Contracts.AutoMapper
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserResponse>();
            CreateMap<AssetManagement.Domain.Models.Asset, ViewListAssets_AssetResponse>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<AssetManagement.Domain.Models.Asset, DeleteAssetReponse>();
        }
    }
}
