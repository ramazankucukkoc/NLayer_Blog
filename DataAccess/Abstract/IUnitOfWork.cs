using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        ICategoryDal Categories { get; }
        IArticleDal Article { get; }
        Task<int> SaveAsync();
    }
}
