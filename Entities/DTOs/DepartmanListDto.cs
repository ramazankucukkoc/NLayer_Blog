using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class DepartmanListDto : DtoGetBase
    {
        public IList<Departman> Departmens { get; set; }

    }
}
