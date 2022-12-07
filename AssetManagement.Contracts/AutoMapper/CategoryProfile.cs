using AssetManagement.Contracts.Category.Request;
using AssetManagement.Contracts.Category.Response;
using AssetManagement.Domain.Enums.Asset;
using AutoMapper;

namespace AssetManagement.Contracts.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Domain.Models.Category, GetCategoryResponse>();
            CreateMap<CreateCategoryRequest, Domain.Models.Category>();
            CreateMap<Domain.Models.Category, ReportResponse>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Available, opt => opt.MapFrom(src => src.Assets.Count(a => a.State == State.Available)))
                .ForMember(dest => dest.Assigned, opt => opt.MapFrom(src => src.Assets.Count(a => a.State == State.Assigned)))
                .ForMember(dest => dest.WaitingForRecycling, opt => opt.MapFrom(src => src.Assets.Count(a => a.State == State.WaitingForRecycling)))
                .ForMember(dest => dest.Recycled, opt => opt.MapFrom(src => src.Assets.Count(a => a.State == State.Recycled)))
                .ForMember(dest => dest.NotAvailable, opt => opt.MapFrom(src => src.Assets.Count(a => a.State == State.NotAvailable)))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Assets.Count));
        }
    }
}
