using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

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
                });
        }

        public async Task<IDataResult<ProductDto>> Delete(int productId, string modifiedByName)
        {
            var productFind = await _unitOfWork.Product.GetAsync(p => p.Id == productId);
            if (productFind != null)
            {
                productFind.IsDeleted = true;
                productFind.ModifiedByName = modifiedByName;
                productFind.ModifiedDate = DateTime.Now;
                var deleteProduct = await _unitOfWork.Product.UpdateAsync(productFind);
                await _unitOfWork.SaveAsync();
                return new DataResult<ProductDto>(ResultStatus.Success, $"{deleteProduct.ProductName} adlı ürün silinmiştir.", new ProductDto
                {
                    Product = deleteProduct,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{deleteProduct.ProductName} aslı ürün silindi"
                });
            }
            return new DataResult<ProductDto>(ResultStatus.Success, "Böyle bir ürün bulunamamıştır.", new ProductDto
            {
                Product = null,
                ResultStatus = ResultStatus.Error,
                Message = $"Böyle bir ürün bulunamadı"
            });

        }

        public Task<IDataResult<ProductDto>> Get(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ProductListDto>> GetAll()
        {
            var getAllProducts = await _unitOfWork.Product.GetAllAsync(null, p => p.Category);
            if (getAllProducts.Count > -1)
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
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success,
                });

            }
            return new DataResult<ProductListDto>(ResultStatus.Success, "Hiçbir ürün bulunamadı"
                , new ProductListDto
                {
                    Products = null,
                    ResultStatus = ResultStatus.Error
                });

        }

        public Task<IDataResult<ProductListDto>> GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ProductUpdateDto>> GetProductUpdate(int productId)
        {
            var result = await _unitOfWork.Product.AnyAsync(x => x.Id == productId);
            if (result)
            {
                var product = await _unitOfWork.Product.GetAsync(x => x.Id == productId);
                var updateProduct = _mapper.Map<ProductUpdateDto>(product);
                return new DataResult<ProductUpdateDto>(ResultStatus.Success, updateProduct);
            }
            else
            {
                return new DataResult<ProductUpdateDto>(ResultStatus.Error, "Böyle bir kategori Bulunamadı", null);
            }

        }

        public Task<IResult> HardDelete(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ProductDto>> Update(ProductUpdateDto productUpdateDto, string modifiedByName)
        {
            var oldProduct = await _unitOfWork.Product.GetAsync(c => c.Id == productUpdateDto.Id);
            var product = _mapper.Map<ProductUpdateDto, Product>(productUpdateDto, oldProduct);
            product.ModifiedByName = modifiedByName;
            var updatedProduct = await _unitOfWork.Product.UpdateAsync(product);
            await _unitOfWork.SaveAsync();
            return new DataResult<ProductDto>(ResultStatus.Success,
                $"{productUpdateDto.ProductName} adlı ürün başarıyla güncellendi", new ProductDto
                {
                    Product = updatedProduct,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{productUpdateDto.ProductName} adlı ürün başarıyla güncellendi"
                });

        }
    }
}
