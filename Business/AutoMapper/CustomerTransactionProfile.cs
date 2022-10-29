using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.AutoMapper
{
    public class CustomerTransactionProfile : Profile
    {
        public CustomerTransactionProfile()
        {
            CreateMap<CustomerTransactionAddDto, CustomerTransaction>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<CustomerTransactionUpdateDto, CustomerTransaction>().ForMember(dest => dest.CreatedDate, p => p.MapFrom(x => DateTime.Now));
            CreateMap<CustomerTransaction, CustomerTransactionUpdateDto>();
        }
    }
}
