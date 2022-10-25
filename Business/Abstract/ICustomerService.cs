using Core.Utilities.Results.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        Task<IDataResult<CustomerDto>> Get(int customerId);
        Task<IDataResult<CustomerUpdateDto>> GetCustomerUpdate(int customerId);
        Task<IDataResult<CustomerListDto>> GetAll();
        Task<IDataResult<CustomerListDto>> GetAllByNonDeleted();
        Task<IDataResult<CustomerListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<CustomerDto>> Add(CustomerAddDto customerAddDto, string createdByName);
        Task<IDataResult<CustomerDto>> Update(CustomerUpdateDto customerUpdateDto, string modifiedByName);
        Task<IDataResult<CustomerDto>> Delete(int customerId, string modifiedByName);
        Task<IResult> HardDelete(int customerId);
    }
}
