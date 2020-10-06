using Codeizi.Infra.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Codeizi.Infra.Data.DAO
{
    public interface IGenericDAO<T, TKey>
        where T : Entity<TKey>
    {
        IQueryable<T> Get();

        Task Update(T entity);

        Task Remove(T entity);

        Task AddAsync(T entity);

        Task<T> GetById(TKey id);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetByFilter(Expression<Func<T, bool>> filter);

        Task<IEnumerable<T>> GetAllByFilter(Expression<Func<T, bool>> filter);
    }
}