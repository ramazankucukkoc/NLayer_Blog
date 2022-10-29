using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class PersonelDto : DtoGetBase
    {
        public Personel Personel { get; set; }
    }
}
