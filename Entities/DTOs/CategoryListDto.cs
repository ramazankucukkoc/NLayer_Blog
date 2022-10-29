using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CategoryListDto : DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}
