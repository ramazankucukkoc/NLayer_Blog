using Core.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class EfCompanyTransactionDal : EfEntityRepositoryBase<CompanyTransaction>, ICompanyTransactionDal
    {
        public EfCompanyTransactionDal(DbContext context) : base(context)
        {
        }
    }
}
