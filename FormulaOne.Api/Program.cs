
using FormulaOne.Application;
using FormulaOne.Application.MappingProfiles;
using FormulaOne.Domain.Interfaces;
using FormulaOne.Infrastructure.Persistence;
using FormulaOne.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<FormulaOneDbContext>(options => options.UseSqlite(connectionString));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //var test = typeof(RequestToDomain).Assembly;
            //var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            //var assem = loadedAssemblies.Where(x => x.GetName().Name.Contains("FormulaOne")).ToList();

            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var applicationAssembly = typeof(ApplicationAssemblyMarker).Assembly;
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
