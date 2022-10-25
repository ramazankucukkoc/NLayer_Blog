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
    public class CompanyTransactionManager : ICompanyTransactionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyTransactionManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<IDataResult<CompanyTransactionDto>> Add(CompanyTransactionAddDto companyTransactionAddDto, string createdByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CompanyTransactionDto>> Delete(int companyTransactionId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CompanyTransactionDto>> Get(int companyTransactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CompanyTransactionListDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CompanyTransactionListDto>> GetAllByNonDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CompanyTransactionListDto>> GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CompanyTransactionUpdateDto>> GetCategoryUpdate(int companyTransactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int companyTransactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CompanyTransactionDto>> Update(CompanyTransactionUpdateDto companyTransactionUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
