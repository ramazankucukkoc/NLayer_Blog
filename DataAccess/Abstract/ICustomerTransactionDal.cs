using Core.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICustomerTransactionDal : IEntityRepository<CustomerTransaction>
    {
        //Task<List<CustomerTransaction>> GetCustomerTransactionWithProduct();

    }
}
