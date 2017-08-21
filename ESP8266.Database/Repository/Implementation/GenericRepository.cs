using ESP8266.Database.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using log4net;

namespace ESP8266.Database.Repository.Implementation
{
    public class GenericRepository<TType> : IGenericRepository<TType> where TType : class
    {
        protected readonly DbContext DbContext;
        protected readonly DbSet<TType> Table;
	    private readonly ILog _log;

        public GenericRepository(ESP8266.Database.Database.esp8266Entities dbContext, ILog log)
        {
	        try
	        {
		        DbContext = dbContext;
		        Table = DbContext.Set<TType>();
		        _log = log;
			}
	        catch (Exception e)
	        {
		        _log.Error(e);
		        throw;
	        }
            
        }

        public async Task<TType> Add(TType entity)
        {
	        try
	        {
		        entity = Table.Add(entity);
		        await DbContext.SaveChangesAsync();
		        return entity;
			}
	        catch (Exception e)
	        {
		        _log.Error(e);
		        throw;
	        }
            
        }

        public async Task Add(IEnumerable<TType> entities)
        {
	        try
	        {
		        Table.AddRange(entities);
		        await DbContext.SaveChangesAsync();
			}
	        catch (Exception e)
	        {
		        _log.Error(e);
		        throw;
	        }
            
        }

        public async Task<bool> Update(TType entity)
        {
	        try
	        {
		        Table.Attach(entity);
		        DbContext.Entry(entity).State = EntityState.Modified;
		        return await DbContext.SaveChangesAsync() > 0;
			}
	        catch (Exception e)
	        {
		        _log.Error(e);
		        throw;
	        }
        }

        public async Task<bool> Delete(TType entity)
        {
	        try
	        {
		        var entry = DbContext.Entry(entity);
		        entry.State = EntityState.Detached;
		        await DbContext.SaveChangesAsync();
		        entry.State = EntityState.Deleted;
		        Table.Remove(entity);
		        return await DbContext.SaveChangesAsync() > 0;
			}
	        catch (Exception e)
	        {
		        _log.Error(e);
			#if DEBUG
				throw;
#endif
				return false;
			}
            
        }

        public async Task<bool> Delete(Expression<Func<TType, bool>> filter)
        {
	        try
	        {
				var entryList = Table.AsNoTracking().Where(filter).ToList();
				foreach (var entry in entryList)
				{
					Table.Attach(entry);
					DbContext.Entry(entry).State = EntityState.Deleted;
				}

				return await DbContext.SaveChangesAsync() > 0;

	        }
	        catch (Exception e)
	        {
		        _log.Error(e);
		        throw;
	        }
        }

        public virtual async Task<TType> Get(Expression<Func<TType, bool>> filter)
        {
	        try
	        {
				return await Table.AsNoTracking().FirstOrDefaultAsync(filter);
	        }
	        catch (Exception e)
	        {
		        _log.Error(e);
		        throw;
	        }
        }

        public virtual async Task<IEnumerable<TType>> GetAll()
        {
	        try
	        {
	            return await Table.AsNoTracking().ToListAsync();
	        }
	        catch (Exception e)
	        {
		        _log.Error(e);
		        throw;
	        }
        }

        public virtual async Task<IList<TType>> GetAny(Expression<Func<TType, bool>> filter)
        {
	        try
	        {
		        return await Table.AsNoTracking().Where(filter).ToListAsync();
			}
	        catch (Exception e)
	        {
		        _log.Error(e);
		        throw;
	        }
            
        }

        public virtual IList<TType> GetAnyNotAsync(Expression<Func<TType, bool>> filter)
        {
	        try
	        {
		        return Table.AsNoTracking().Where(filter).ToList();
			}
	        catch (Exception e)
	        {
		        _log.Error(e);
		        throw;
	        }
        }

        public IQueryable<TType> GetQueryable()
        {
	        try
	        {
		        return Table.AsNoTracking().AsQueryable();
			}
	        catch (Exception e)
	        {
		        _log.Error(e);
		        throw;
	        }
        }
    }
}
