using Core.Utilities.Results.Abstract;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICompanyTransactionService
    {
        Task<IDataResult<CompanyTransactionDto>> Get(int companyTransactionId);
        Task<IDataResult<CompanyTransactionUpdateDto>> GetCompanyTransactionUpdate(int companyTransactionId);
        Task<IDataResult<CompanyTransactionListDto>> GetAll();
        Task<IDataResult<CompanyTransactionListDto>> GetAllByNonDeleted();
        Task<IDataResult<CompanyTransactionListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<CompanyTransactionDto>> Add(CompanyTransactionAddDto companyTransactionAddDto, string createdByName);
        Task<IDataResult<CompanyTransactionDto>> Update(CompanyTransactionUpdateDto companyTransactionUpdateDto, string modifiedByName);
        Task<IDataResult<CompanyTransactionDto>> Delete(int companyTransactionId, string modifiedByName);
        Task<IResult> HardDelete(int companyTransactionId);
    }
}
