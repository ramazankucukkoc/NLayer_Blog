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
    public class CustomerTransactionManager : ICustomerTrasanctionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerTransactionManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<IDataResult<CustomerTransactionDto>> Add(CustomerTransactionAddDto customerTransactionAddDto, string createdByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerTransactionDto>> Delete(int customerTransactionId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerTransactionDto>> Get(int customerTransactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerTransactionList>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerTransactionList>> GetAllByCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerTransactionList>> GetAllByNonDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerTransactionList>> GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerTransactionList>> GetAllByPersonel(int personelId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerTransactionList>> GetAllByProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerTransactionUpdateDto>> GetCustomerTransactionUpdate(int customerTransactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int customerTransactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerTransactionDto>> Update(CustomerTransactionUpdateDto customerTransactionUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
