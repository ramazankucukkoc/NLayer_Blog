using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<ProductDto>> Add(ProductAddDto productAddDto, string createdByName)
        {
            var product = _mapper.Map<Product>(productAddDto);
            product.CreatedByName = createdByName;
            product.ModifiedByName = createdByName;
            var addedProduct = await _unitOfWork.Product.AddAsync(product);
            await _unitOfWork.SaveAsync();
            return new DataResult<ProductDto>(ResultStatus.Success, $"{productAddDto.ProductName} adlı " +
                $"product başarıyla eklenmiştir. ", new ProductDto
                {
                    Product = addedProduct,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{productAddDto.ProductName} adlı ürün başarıyla eklenmiştir."
                }) ;
        }

        public Task<IDataResult<ProductDto>> Delete(int productId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ProductDto>> Get(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ProductListDto>> GetAll()
        {
            var getAllProducts = await _unitOfWork.Product.GetAllAsync(null, p => p.Category);
            if (getAllProducts.Count>-1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = getAllProducts,
                    ResultStatus = ResultStatus.Success
                });

            }
            return new DataResult<ProductListDto>(ResultStatus.Error, "Hiçbir Bir Ürün bulunamadı", new ProductListDto
            {
                Products = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hiç bir ürün bulunamadı"
            });

        }

        public Task<IDataResult<ProductListDto>> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ProductListDto>> GetAllByNonDeleted()
        {
            var products = await _unitOfWork.Product.GetAllAsync(c => !c.IsDeleted, c => c.Category);
            if (products.Count>-1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products=products,
                    ResultStatus=ResultStatus.Success,
                });

            }
            return new DataResult<ProductListDto>(ResultStatus.Success,"Hiçbir ürün bulunamadı"
                , new ProductListDto
            {
                Products=null,
                ResultStatus=ResultStatus.Error
            });

        }

        public Task<IDataResult<ProductListDto>> GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ProductUpdateDto>> GetProductUpdate(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ProductDto>> Update(ProductUpdateDto productUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
