using Core.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class EfCustomerTransactionDal : EfEntityRepositoryBase<CustomerTransaction>, ICustomerTransactionDal
    {
        public EfCustomerTransactionDal(DbContext context) : base(context)
        {
        }

        //public async Task<List<CustomerTransaction>> GetCustomerTransactionWithProduct()
        //{
        //    return await _context
        //}
    }
}
