using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CustomerDto : DtoGetBase
    {
        public Customer Customer { get; set; }
    }
}
