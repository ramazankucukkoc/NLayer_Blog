using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CategoryDto : DtoGetBase
    {
        public Category Category { get; set; }
    }
}
