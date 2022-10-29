using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CustomerTransactionListDto : DtoGetBase
    {
        public IList<CustomerTransaction> CustomerTransactions { get; set; }
    }
}
