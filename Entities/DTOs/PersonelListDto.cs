using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class PersonelListDto : DtoGetBase
    {
        public IList<Personel> Personels { get; set; }

    }
}
