using Core.Utilities.Results.Abstract;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerTrasanctionService
    {
        Task<IDataResult<CustomerTransactionDto>> Get(int customerTransactionId);
        Task<IDataResult<CustomerTransactionUpdateDto>> GetCustomerTransactionUpdate(int customerTransactionId);
        Task<IDataResult<CustomerTransactionListDto>> GetAllByCustomer(int customerId);
        Task<IDataResult<CustomerTransactionListDto>> GetAllByProduct(int productId);
        Task<IDataResult<CustomerTransactionListDto>> GetAllByPersonel(int personelId);
        Task<IDataResult<CustomerTransactionListDto>> GetAll();
        Task<IDataResult<CustomerTransactionListDto>> GetAllByNonDeleted();
        Task<IDataResult<CustomerTransactionListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<CustomerTransactionDto>> Add(CustomerTransactionAddDto customerTransactionAddDto, string createdByName);
        Task<IDataResult<CustomerTransactionDto>> Update(CustomerTransactionUpdateDto customerTransactionUpdateDto, string modifiedByName);
        Task<IDataResult<CustomerTransactionDto>> Delete(int customerTransactionId, string modifiedByName);
        Task<IResult> HardDelete(int customerTransactionId);
    }
}
