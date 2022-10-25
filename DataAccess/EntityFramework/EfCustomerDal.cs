using Core.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer>, ICustomerDal
    {
        public EfCustomerDal(DbContext context) : base(context)
        {
        }
    }
}
