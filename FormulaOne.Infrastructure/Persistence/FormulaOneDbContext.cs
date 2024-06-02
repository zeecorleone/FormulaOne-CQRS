

using FormulaOne.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Infrastructure.Persistence;

public class FormulaOneDbContext : DbContext
{
    //dotnet ef migrations add "initial-migration" --project FormulaOne.Infrastructure --startup-project FormulaOne.Api
    //dotnet ef database update --startup-project FormulaOne.Api

    public FormulaOneDbContext(DbContextOptions<FormulaOneDbContext> options)
        : base(options)
    {
        
    }


    public virtual DbSet<Driver> Drivers { get; set; }
    public virtual DbSet<Achievement> Achievements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasOne(d => d.Driver)
            .WithMany(a => a.Achievements)
            .HasForeignKey(d => d.DriverId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Achievement_Driver");
        });
    }
}
