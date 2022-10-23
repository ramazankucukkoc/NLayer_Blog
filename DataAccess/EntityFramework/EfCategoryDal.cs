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
    public class EfCategoryDal : EfEntityRepositoryBase<Category>, ICategoryDal
    {
        public EfCategoryDal(DbContext context) : base(context)
        {
        }
    }
}
