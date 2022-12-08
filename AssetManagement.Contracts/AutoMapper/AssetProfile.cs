﻿using AssetManagement.Contracts.Asset.Request;
using AssetManagement.Contracts.Asset.Response;
using AutoMapper;

namespace AssetManagement.Contracts.AutoMapper
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<Domain.Models.Asset, ViewListAssetsResponse>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<Domain.Models.Asset, DeleteAssetReponse>();
            CreateMap<CreateAssetRequest, Domain.Models.Asset>()
                .ForMember(dest=>dest.Name, opt => opt.MapFrom(src => src.Name.Trim()))
                .ForMember(dest=>dest.Specification, opt => opt.MapFrom(src => src.Specification.Trim()));
            CreateMap<Domain.Models.Asset, GetAssetByIdResponse>();
            CreateMap<Domain.Models.Asset, UpdateAssetResponse>();
            CreateMap<Domain.Models.Asset, UpdateAssetRequest>();
            CreateMap<Domain.Models.Asset, GetAssetByIdResponse>();
            CreateMap<Domain.Models.Asset, CreateAssetRequest>();

            CreateMap<Domain.Models.Asset, GetAssetByIdResponse>();
            CreateMap<Domain.Models.Asset, ViewListAssetsResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<Domain.Models.Asset, UpdateAssetResponse>();
            CreateMap<Domain.Models.Asset, UpdateAssetRequest>();
            CreateMap<Domain.Models.Asset, DeleteAssetReponse>();
            CreateMap<Domain.Models.Asset, GetAssetByIdResponse>();
            CreateMap<Domain.Models.Asset, CreateAssetRequest>();
        }
    }
}
