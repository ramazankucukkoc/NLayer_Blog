namespace DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        ICategoryDal Categories { get; }
        ICompanyDal Company { get; }
        ICompanyTransactionDal CompanyTransaction { get; }
        ICustomerDal Customer { get; }
        ICustomerTransactionDal CustomerTransaction { get; }
        IDepartmanDal Departman { get; }
        IPersonelDal Personel { get; }
        IProductDal Product { get; }
        Task<int> SaveAsync();
    }
}
