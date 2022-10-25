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
    public class PersonelManager : IPersonelService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PersonelManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<IDataResult<PersonelDto>> Add(PersonelAddDto personelAddDto, string createdByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<PersonelDto>> Delete(int personelId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<PersonelDto>> Get(int personelId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<PersonelListDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<PersonelListDto>> GetAllByDepartman(int departmanId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<PersonelListDto>> GetAllByNonDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<PersonelListDto>> GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<PersonelUpdateDto>> GetPersonelUpdate(int personelId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int personelId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<PersonelDto>> Update(PersonelUpdateDto personelUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
