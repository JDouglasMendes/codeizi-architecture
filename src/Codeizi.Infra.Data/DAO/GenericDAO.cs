using Codeizi.Infra.Core.Entities;
using Codeizi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Codeizi.Infra.Data.DAO
{
    public abstract class GenericDAO<T, TKey> :
        IGenericDAO<T, TKey>
        where T : Entity<TKey>
    {
        protected readonly CodeiziContext Db;
        protected readonly DbSet<T> DbSet;

        protected GenericDAO(CodeiziContext context)
            => (Db, DbSet) = (context, context.Set<T>());

        public IQueryable<T> Get()
            => DbSet.AsQueryable();

        public async Task<IEnumerable<T>> GetAll()
            => await DbSet.ToListAsync();

        public async Task<IEnumerable<T>> GetAllByFilter(Expression<Func<T, bool>> filter)
            => await DbSet.Where(filter).ToListAsync();

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter)
            => await DbSet.FirstOrDefaultAsync(filter);

        public async Task<T> GetById(TKey id)
            => await DbSet.FindAsync(id);

        public async Task AddAsync(T entity)
            => await DbSet.AddAsync(entity);

        public Task Remove(T entity)
            => Task.Run(() => DbSet.Remove(entity));

        public Task Update(T entity)
            => Task.Run(() => DbSet.Update(entity));

    }
}