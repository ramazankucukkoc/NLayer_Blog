using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<IDataResult<CompanyDto>> Add(CompanyAddDto companyAddDto, string createdByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CompanyDto>> Delete(int companyId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CompanyDto>> Get(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CompanyLisDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CompanyLisDto>> GetAllByNonDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CompanyLisDto>> GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CompanyUpdateDto>> GetCategoryUpdate(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CompanyDto>> Update(CompanyUpdateDto companyUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
