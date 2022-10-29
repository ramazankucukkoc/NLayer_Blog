using Core.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICompanyTransactionDal : IEntityRepository<CompanyTransaction>
    {
    }
}
