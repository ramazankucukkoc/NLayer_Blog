using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.AutoMapper
{
    public class PersonelProfile : Profile
    {
        public PersonelProfile()
        {
            CreateMap<PersonelAddDto, Personel>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<PersonelUpdateDto, Personel>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<Personel, PersonelUpdateDto>();
        }
    }
}
