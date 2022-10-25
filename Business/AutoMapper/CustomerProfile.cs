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
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerAddDto, Customer>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<CustomerUpdateDto, Customer>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<Customer, CustomerUpdateDto>();
        }
    }
}
