

using FormulaOne.Domain.Interfaces;
using FormulaOne.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ILogger _logger;
    private readonly FormulaOneDbContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(ILogger logger, FormulaOneDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;

        _dbSet = _dbContext.Set<T>();
    }

    public virtual Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> Add(T entity)
    {
        _dbSet.Add(entity);
        return true;
    }

    public virtual Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

}
