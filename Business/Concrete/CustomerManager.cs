using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<IDataResult<CustomerDto>> Add(CustomerAddDto customerAddDto, string createdByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerDto>> Delete(int customerId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerDto>> Get(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerListDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerListDto>> GetAllByNonDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerListDto>> GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerUpdateDto>> GetCustomerUpdate(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerDto>> Update(CustomerUpdateDto customerUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
