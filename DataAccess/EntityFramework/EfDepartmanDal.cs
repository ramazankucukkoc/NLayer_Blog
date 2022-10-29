using Core.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class EfDepartmanDal : EfEntityRepositoryBase<Departman>, IDepartmanDal
    {
        public EfDepartmanDal(DbContext context) : base(context)
        {
        }
    }
}
