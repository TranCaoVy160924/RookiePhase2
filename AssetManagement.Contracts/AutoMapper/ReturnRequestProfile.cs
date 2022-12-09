using AutoMapper;

namespace AssetManagement.Contracts.AutoMapper
{
    public class ReturnRequestProfile : Profile
    {
        public ReturnRequestProfile()
        {
            CreateMap<Domain.Models.Assignment, Domain.Models.ReturnRequest>()
                .ForMember(src => src.AssignmentId, opt => opt.MapFrom(act => act.Id))
                .ForMember(src => src.AssignedDate, opt => opt.MapFrom(act => act.AssignedDate));

        }
    }
}
