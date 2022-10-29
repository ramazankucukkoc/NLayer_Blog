using Core.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class EfPersonelDal : EfEntityRepositoryBase<Personel>, IPersonelDal
    {
        public EfPersonelDal(DbContext context) : base(context)
        {
        }
    }
}
