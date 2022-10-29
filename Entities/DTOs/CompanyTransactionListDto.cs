using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CompanyTransactionListDto : DtoGetBase
    {
        public IList<CompanyTransaction> CompanyTransactions { get; set; }
    }
}
