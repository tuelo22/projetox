using Microsoft.EntityFrameworkCore;
using projetox.Api.Extensoes;
using projetox.Repository;
using System.Security.Claims;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddJWTConfiguration();
        builder.Services.AddInjecaoDependencia();
        builder.Services.AddDbContext<XContext>(c =>
        {
            c.UseSqlServer(builder.Configuration.GetConnectionString("ProjetoXConnection"));

        });

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