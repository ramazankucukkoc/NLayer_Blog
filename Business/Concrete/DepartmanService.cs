using AutoMapper;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DepartmanService : IDepartmanDal
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmanService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<Departman> AddAsync(Departman entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<Departman, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<Departman, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Departman entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Departman>> GetAllAsync(Expression<Func<Departman, bool>> predicate = null, params Expression<Func<Departman, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<Departman> GetAsync(Expression<Func<Departman, bool>> predicate, params Expression<Func<Departman, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<Departman> UpdateAsync(Departman entity)
        {
            throw new NotImplementedException();
        }
    }
}
