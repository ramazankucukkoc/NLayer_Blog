using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class PersonelProfile:Profile
    {
        public PersonelProfile()
        {
            CreateMap<PersonelAddDto, Personel>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<PersonelUpdateDto, Personel>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<Personel, PersonelUpdateDto>();
        }
    }
}
