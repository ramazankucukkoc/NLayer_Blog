using Core.Utilities.Results.Abstract;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IPersonelService
    {
        Task<IDataResult<PersonelDto>> Get(int personelId);
        Task<IDataResult<PersonelUpdateDto>> GetPersonelUpdate(int personelId);
        Task<IDataResult<PersonelListDto>> GetAllByDepartman(int departmanId);
        Task<IDataResult<PersonelListDto>> GetAll();
        Task<IDataResult<PersonelListDto>> GetAllByNonDeleted();
        Task<IDataResult<PersonelListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<PersonelDto>> Add(PersonelAddDto personelAddDto, string createdByName);
        Task<IDataResult<PersonelDto>> Update(PersonelUpdateDto personelUpdateDto, string modifiedByName);
        Task<IDataResult<PersonelDto>> Delete(int personelId, string modifiedByName);
        Task<IResult> HardDelete(int personelId);

    }
}
