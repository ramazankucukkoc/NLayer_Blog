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
    public class DepartmanProfile:Profile
    {
        public DepartmanProfile()
        {
            CreateMap<DepartmanAddDto, Departman>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<DepartmanUpdateDto, Departman>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<Departman, DepartmanUpdateDto>();
        }
    }
}
