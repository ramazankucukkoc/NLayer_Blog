using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class ProductListDto : DtoGetBase
    {
        public IList<Product> Products { get; set; }
    }
}
