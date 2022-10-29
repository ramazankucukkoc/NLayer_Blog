using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CustomerTransactionDto : DtoGetBase
    {
        public CustomerTransaction CustomerTransaction { get; set; }
    }
}
