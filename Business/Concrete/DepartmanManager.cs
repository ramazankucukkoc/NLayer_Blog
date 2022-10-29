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
    public class DepartmanManager : IDepartmanService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmanManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<DepartmanDto>> Add(DepartmanAddDto departmanAddDto, string createdByName)
        {
            var departman = _mapper.Map<Departman>(departmanAddDto);
            departman.CreatedByName = createdByName;
            departman.ModifiedByName = createdByName;
            var addDepartman = await _unitOfWork.Departman.AddAsync(departman);
            await _unitOfWork.SaveAsync();
            return new DataResult<DepartmanDto>(ResultStatus.Success, $"{departmanAddDto.DepartmanName} adlı departman başarıyla eklenmiştir.", new DepartmanDto
            {
                Departman = addDepartman,
                ResultStatus = ResultStatus.Success,
                Message = $"{departmanAddDto.DepartmanName} adlı departman başarıyla eklenmiştir."
            });


        }

        public Task<IDataResult<DepartmanDto>> Delete(int departmanId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DepartmanDto>> Get(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DepartmanListDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<DepartmanListDto>> GetAllByNonDeleted()
        {
            var departmans = await _unitOfWork.Departman.GetAllAsync(d => !d.IsDeleted, d => d.Personels);
            if (departmans.Count > -1)
            {
                return new DataResult<DepartmanListDto>(ResultStatus.Success, new DepartmanListDto
                {
                    Departmens = departmans,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<DepartmanListDto>(ResultStatus.Success, "Hiçbir departman buluınmamadı", new DepartmanListDto
            {
                Departmens = null,
                ResultStatus = ResultStatus.Success
            });
        }

        public Task<IDataResult<DepartmanListDto>> GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DepartmanUpdateDto>> GetDepartmanUpdate(int departmanId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int departmanId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DepartmanDto>> Update(DepartmanUpdateDto departmanUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
