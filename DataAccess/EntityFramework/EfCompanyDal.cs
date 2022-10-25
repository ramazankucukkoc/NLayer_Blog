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
    public class EfCompanyDal : EfEntityRepositoryBase<Company>, ICompanyDal
    {
        public EfCompanyDal(DbContext context) : base(context)
        {
        }
    }
}
