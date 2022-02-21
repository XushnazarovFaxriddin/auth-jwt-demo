using Contracts;
using Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }
        public virtual void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T entity)
        {
            throw new NotImplementedException();
        }
        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> FindAll(bool tracking) => !tracking
            ? _repositoryContext.Set<T>().AsNoTracking()
            : _repositoryContext.Set<T>();

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool tracking) => !tracking
            ? _repositoryContext.Set<T>().Where(expression).AsNoTracking()
            : _repositoryContext.Set<T>().Where(expression);
    }
}
