

using FormulaOne.Domain.Entities;

namespace FormulaOne.Domain.Interfaces;

public interface IAchievementRepository : IGenericRepository<Achievement>
{
    Task<Achievement> GetDriverAchievementAsync(Guid driverId);
}
