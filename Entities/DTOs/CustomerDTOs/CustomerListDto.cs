using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CustomerListDto : DtoGetBase
    {
        public IList<Customer> Customers { get; set; }
    }
}
