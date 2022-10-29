using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.AutoMapper
{
    public class DepartmanProfile : Profile
    {
        public DepartmanProfile()
        {
            CreateMap<DepartmanAddDto, Departman>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<DepartmanUpdateDto, Departman>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<Departman, DepartmanUpdateDto>();
        }
    }
}
