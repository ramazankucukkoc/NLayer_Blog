using Core.Utilities.Results.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerTrasanctionService
    {
        Task<IDataResult<CustomerTransactionDto>> Get(int customerTransactionId);
        Task<IDataResult<CustomerTransactionUpdateDto>> GetCustomerTransactionUpdate(int customerTransactionId);
        Task<IDataResult<CustomerTransactionList>> GetAllByCustomer(int customerId);
        Task<IDataResult<CustomerTransactionList>> GetAllByProduct(int productId);
        Task<IDataResult<CustomerTransactionList>> GetAllByPersonel(int personelId);
        Task<IDataResult<CustomerTransactionList>> GetAll();
        Task<IDataResult<CustomerTransactionList>> GetAllByNonDeleted();
        Task<IDataResult<CustomerTransactionList>> GetAllByNonDeletedAndActive();
        Task<IDataResult<CustomerTransactionDto>> Add(CustomerTransactionAddDto customerTransactionAddDto, string createdByName);
        Task<IDataResult<CustomerTransactionDto>> Update(CustomerTransactionUpdateDto customerTransactionUpdateDto, string modifiedByName);
        Task<IDataResult<CustomerTransactionDto>> Delete(int customerTransactionId, string modifiedByName);
        Task<IResult> HardDelete(int customerTransactionId);
    }
}
