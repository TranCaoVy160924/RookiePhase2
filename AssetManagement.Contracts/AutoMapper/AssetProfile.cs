using AssetManagement.Contracts.Asset.Request;
using AutoMapper;

namespace AssetManagement.Contracts.AutoMapper
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<CreateAssetRequest, AssetManagement.Domain.Models.Asset>();
        }
    }
}
