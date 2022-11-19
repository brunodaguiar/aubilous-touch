using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Models;
using AubilousTouch.Intra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AubilousTouch.Intra.Repositories.Base
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        protected readonly AubilousTouchDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(AubilousTouchDbContext db)
        {
            Db = db ?? throw new ArgumentNullException(nameof(db));
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int Id)
        {
            DbSet.Remove(new TEntity { Id = Id });
            await SaveChangesAsync();

        }

        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }


        public void Dispose()
        {
            Db?.Dispose();
        }

        public int DeleteMany(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate).DeleteFromQuery<TEntity>();
        }
    }
}
