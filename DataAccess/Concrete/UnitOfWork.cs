using DataAccess.Abstract;
using DataAccess.EntityFramework;

namespace DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private EfCategoryDal _efCategoryDal;
        private EfCompanyDal _efCompanyDal;
        private EfCompanyTransactionDal _efCompanyTransactionDal;
        private EfCustomerTransactionDal _efCustomerTransactionDal;
        private EfProductDal _efProductDal;
        private EfCustomerDal _efCustomerDal;
        private EfDepartmanDal _efDepartmanDal;
        private EfPersonelDal _efPersonelDal;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ICategoryDal Categories => _efCategoryDal ?? new EfCategoryDal(_appDbContext);
        public ICompanyDal Company => _efCompanyDal ?? new EfCompanyDal(_appDbContext);
        public IProductDal Product => _efProductDal ?? new EfProductDal(_appDbContext);
        public ICustomerDal Customer => _efCustomerDal ?? new EfCustomerDal(_appDbContext);
        public ICompanyTransactionDal CompanyTransaction => _efCompanyTransactionDal ?? new EfCompanyTransactionDal(_appDbContext);
        public ICustomerTransactionDal CustomerTransaction => _efCustomerTransactionDal ?? new EfCustomerTransactionDal(_appDbContext);
        public IDepartmanDal Departman => _efDepartmanDal ?? new EfDepartmanDal(_appDbContext);
        public IPersonelDal Personel => _efPersonelDal ?? new EfPersonelDal(_appDbContext);

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
