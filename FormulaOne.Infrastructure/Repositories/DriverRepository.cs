

using FormulaOne.Domain.Entities;
using FormulaOne.Domain.Interfaces;
using FormulaOne.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SQLitePCL;

namespace FormulaOne.Infrastructure.Repositories;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(ILogger logger, FormulaOneDbContext dbContext) 
        : base(logger, dbContext)
    {
    }

    public override async Task<IEnumerable<Driver>> All()
    {
        try
        {
            return await _dbSet.Where(x => x.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.CreatedDate)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{repo} - error occurred in All function", typeof(DriverRepository));
            throw;
        }
    }


    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var item = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (item is null)
                return false;

            item.Status = 0; //Deleted
            item.UpdatedDate = DateTime.UtcNow;

            return true;
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "{repo} - error occurred in Delete function", typeof(DriverRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Driver driver)
    {
        var item = await _dbSet.FirstOrDefaultAsync(x => x.Id == driver.Id);

        if(item == null)
            return false;

        item.UpdatedDate = DateTime.UtcNow;
        item.DriverNumber = driver.DriverNumber;
        item.FirstName = driver.FirstName;
        item.LastName = driver.LastName;
        item.DateOfBirth = driver.DateOfBirth;

        return true;
    }

}

