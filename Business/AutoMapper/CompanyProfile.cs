using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.AutoMapper
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyAddDto, Company>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<CompanyUpdateDto, Company>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<Company, CompanyUpdateDto>();
        }
    }
}
