using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class DepartmanDto : DtoGetBase
    {
        public Departman Departman { get; set; }
    }
}
