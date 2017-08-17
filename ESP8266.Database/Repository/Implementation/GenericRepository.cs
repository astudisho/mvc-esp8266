using ESP8266.Database.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ESP8266.Database.Repository.Implementation
{
    public class GenericRepository<TType> : IGenericRepository<TType> where TType : class
    {
        protected readonly DbContext DbContext;
        protected readonly DbSet<TType> Table;

        public GenericRepository(ESP8266.Database.Database.esp8266Entities dbContext)
        {
            DbContext = dbContext;
            Table = DbContext.Set<TType>();
        }

        public async Task<TType> Add(TType entity)
        {
            entity = Table.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Add(IEnumerable<TType> entities)
        {
            Table.AddRange(entities);
            await DbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(TType entity)
        {
            Table.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            return await DbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(TType entity)
        {
            var entry = DbContext.Entry(entity);
            entry.State = EntityState.Detached;
            await DbContext.SaveChangesAsync();
            entry.State = EntityState.Deleted;
            Table.Remove(entity);
            return await DbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Expression<Func<TType, bool>> filter)
        {
            var entryList = Table.AsNoTracking().Where(filter).ToList();
            foreach (var entry in entryList)
            {
                Table.Attach(entry);
                DbContext.Entry(entry).State = EntityState.Deleted;
            }

            return await DbContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<TType> Get(Expression<Func<TType, bool>> filter)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public virtual async Task<IList<TType>> GetAll()
        {
            return await Table.AsNoTracking().ToListAsync();
        }

        public virtual async Task<IList<TType>> GetAny(Expression<Func<TType, bool>> filter)
        {
            return await Table.AsNoTracking().Where(filter).ToListAsync();
        }

        public virtual IList<TType> GetAnyNotAsync(Expression<Func<TType, bool>> filter)
        {
            return Table.AsNoTracking().Where(filter).ToList();
        }

        public IQueryable<TType> GetQueryable()
        {
            return Table.AsNoTracking().AsQueryable();
        }
    }
}
