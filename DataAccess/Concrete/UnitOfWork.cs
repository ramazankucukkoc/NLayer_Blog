using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private EfCategoryDal _efCategoryDal;
        private EfArticleDal _efArticleDal;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ICategoryDal Categories => _efCategoryDal ?? new EfCategoryDal(_appDbContext);
        public IArticleDal Article => _efArticleDal ?? new EfArticleDal(_appDbContext);
        public async Task<int> SaveAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _appDbContext.DisposeAsync();
        }

    }
}
