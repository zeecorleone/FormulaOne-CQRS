

using FormulaOne.Domain.Interfaces;
using FormulaOne.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace FormulaOne.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    public IDriverRepository Drivers { get; }
    public IAchievementRepository Achievements { get;}
    private readonly FormulaOneDbContext _context;

    public UnitOfWork(FormulaOneDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        var logger = loggerFactory.CreateLogger("logs");

        Drivers = new DriverRepository(logger, _context);
        Achievements = new AchievementsRepository(logger, _context);
    }


    public async Task<bool> CompleteAsync()
    {
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}
