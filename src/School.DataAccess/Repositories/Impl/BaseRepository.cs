using Microsoft.EntityFrameworkCore;
using School.Core.Common;
using School.Core.Exceptions;
using School.DataAccess.Persistence;
using System.Linq.Expressions;

namespace School.DataAccess.Repositories.Impl;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DatabaseContext _context;
    protected readonly DbSet<TEntity> DbSet;

    protected BaseRepository(DatabaseContext context)
    {
        _context = context;
        DbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        try
        {
            
            var addedEntity = await DbSet.AddAsync(entity);

            
            await _context.SaveChangesAsync();

            
            return addedEntity.Entity;
        }
        catch (DbUpdateException dbEx)
        {
         
            throw new Exception("Database update failed. " + dbEx.Message, dbEx);
        }
        catch (Exception ex)
        {
         
            throw new Exception("An error occurred while adding the entity. " + ex.Message, ex);
        }
    }



    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        var removedEntity = DbSet.Remove(entity).Entity;
        await _context.SaveChangesAsync();

        return removedEntity;
    }

    public IEnumerable<TEntity> GetAllAsEnumurable()
    {
        return DbSet.AsEnumerable(); //DbSet-table
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.Where(predicate).ToListAsync();
    }
    public IQueryable<TEntity> GetAll() =>
        DbSet.AsQueryable();

    public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await DbSet.Where(predicate).FirstOrDefaultAsync();

        if (entity == null) throw new ResourceNotFoundException(typeof(TEntity));

        return await DbSet.Where(predicate).FirstOrDefaultAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}
