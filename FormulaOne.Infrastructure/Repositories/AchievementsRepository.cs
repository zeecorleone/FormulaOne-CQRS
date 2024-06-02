

using FormulaOne.Domain.Entities;
using FormulaOne.Domain.Interfaces;
using FormulaOne.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.Infrastructure.Repositories;

public class AchievementsRepository : GenericRepository<Achievement>, IAchievementRepository
{
    public AchievementsRepository(ILogger logger, FormulaOneDbContext dbContext) 
        : base(logger, dbContext)
    {
    }

    public async Task<Achievement> GetDriverAchievementAsync(Guid driverId)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{repo} - error occurred in GetDriverAchievementsAsync function", typeof(AchievementsRepository));
            throw;
        }
    }

    public override async Task<IEnumerable<Achievement>> All()
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
            _logger.LogError(ex, "{repo} - error occurred in All function", typeof(AchievementsRepository));
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "{repo} - error occurred in Delete function", typeof(AchievementsRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Achievement achievement)
    {
        var item = await _dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);

        if (item == null)
            return false;

        item.UpdatedDate = DateTime.UtcNow;
        item.FastestLap = achievement.FastestLap;
        item.PolePosition = achievement.PolePosition;
        item.RaceWins = achievement.RaceWins;
        item.WorldChampionship = achievement.WorldChampionship;

        return true;
    }

}
