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
            CreateMap<UpdateAssetRequest, AssetManagement.Domain.Models.Asset>();
        }
    }
}
