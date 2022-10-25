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
    public class CompanyTransactionProfile:Profile
    {
        public CompanyTransactionProfile()
        {
            CreateMap<CompanyTransactionAddDto, Company>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<CompanyTransactionUpdateDto, Company>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<Company, CompanyTransactionUpdateDto>();
        }
    }
}
