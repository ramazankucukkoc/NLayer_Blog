using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class ProductDto : DtoGetBase
    {
        public Product Product { get; set; }
    }
}
