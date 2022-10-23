using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category=_mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            var addedCategory = await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success,$"{categoryAddDto.Name} adlı kategori başarıyla eklenmiştir.", new CategoryDto
            {
                Category=addedCategory,
                ResultStatus=ResultStatus.Success,
                 Message=$"{categoryAddDto.Name} adlı kategori başarıyla eklenmiştir."
            }); 
        }

        public Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId, c => c.Articles);
            if (category!=null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı", new CategoryDto
            {
                Category = null,
                ResultStatus = ResultStatus.Error,
                Message="Böyle bir kategori bulunamadı."
            }) ;

        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, c => c.Articles);
            if (categories.Count>-1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hiçbir Bir kategori bulunamadı", new CategoryListDto
            {
                Categories= null,
                ResultStatus = ResultStatus.Error,
                Message="Hiç bir kategori bulunamadı"
            });

        }

        public Task<IDataResult<CategoryListDto>> GetAllByNonDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            category.ModifiedByName = modifiedByName;
            var updatedCategory=  await _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, $"{categoryUpdateDto.Name} adlı kategori başarıyla güncellenmiştir.", new CategoryDto
            {
                Category = updatedCategory,
                ResultStatus = ResultStatus.Success,
                Message = $"{categoryUpdateDto.Name} adlı kategori başarıyla güncellenmiştir."
            }) ;
        }
    }
}
