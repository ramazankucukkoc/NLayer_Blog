using Core.Utilities.Results.Abstract;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        Task<IDataResult<CompanyDto>> Get(int companyId);
        Task<IDataResult<CompanyUpdateDto>> GetCategoryUpdate(int companyId);
        Task<IDataResult<CompanyLisDto>> GetAll();
        Task<IDataResult<CompanyLisDto>> GetAllByNonDeleted();
        Task<IDataResult<CompanyLisDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<CompanyDto>> Add(CompanyAddDto companyAddDto, string createdByName);
        Task<IDataResult<CompanyDto>> Update(CompanyUpdateDto companyUpdateDto, string modifiedByName);
        Task<IDataResult<CompanyDto>> Delete(int companyId, string modifiedByName);
        Task<IResult> HardDelete(int companyId);
    }
}
