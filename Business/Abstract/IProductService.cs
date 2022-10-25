using Core.Utilities.Results.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<ProductDto>> Get(int productId);
        Task<IDataResult<ProductUpdateDto>> GetProductUpdate(int productId);
        Task<IDataResult<ProductListDto>> GetAllByCategory(int categoryId);
        Task<IDataResult<ProductListDto>> GetAll();
        Task<IDataResult<ProductListDto>> GetAllByNonDeleted();
        Task<IDataResult<ProductListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<ProductDto>> Add(ProductAddDto productAddDto, string createdByName);
        Task<IDataResult<ProductDto>> Update(ProductUpdateDto productUpdateDto, string modifiedByName);
        Task<IDataResult<ProductDto>> Delete(int productId, string modifiedByName);
        Task<IResult> HardDelete(int productId);
    }
}
