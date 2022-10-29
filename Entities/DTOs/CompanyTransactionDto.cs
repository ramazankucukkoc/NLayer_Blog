using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CompanyTransactionDto : DtoGetBase
    {
        public CompanyTransaction CompanyTransaction { get; set; }
    }
}
