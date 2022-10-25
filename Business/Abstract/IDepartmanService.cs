using Core.Utilities.Results.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDepartmanService
    {
        Task<IDataResult<DepartmanDto>> Get(int productId);
        Task<IDataResult<DepartmanUpdateDto>> GetDepartmanUpdate(int departmanId);
        Task<IDataResult<DepartmanListDto>> GetAll();
        Task<IDataResult<DepartmanListDto>> GetAllByNonDeleted();
        Task<IDataResult<DepartmanListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<DepartmanDto>> Add(DepartmanAddDto departmanAddDto, string createdByName);
        Task<IDataResult<DepartmanDto>> Update(DepartmanUpdateDto departmanUpdateDto, string modifiedByName);
        Task<IDataResult<DepartmanDto>> Delete(int departmanId, string modifiedByName);
        Task<IResult> HardDelete(int departmanId);
    }
}
