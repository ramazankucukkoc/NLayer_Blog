using Core.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company>, ICompanyDal
    {
        public EfCompanyDal(DbContext context) : base(context)
        {
        }
    }
}
