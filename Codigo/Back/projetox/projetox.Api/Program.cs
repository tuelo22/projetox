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

        // Rota para autenticação
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapPost("/login", async context =>
            {
                var username = context.Request.Form["username"];
                var password = context.Request.Form["password"];

                // Verificação de usuário e senha (implementação de exemplo)
                if (username == "usuario" && password == "senha")
                {
                    var token = JWTConfiguration.GenerateJwtToken(username);
                    await context.Response.WriteAsJsonAsync(new { token });
                }
                else
                {
                    context.Response.StatusCode = 401; // Unauthorized
                }
            });

            endpoints.MapGet("/test", async context =>
            {
                // Aqui você pode acessar o contexto do usuário autenticado
                var user = context.User;
                if (user.Identity.IsAuthenticated)
                {
                    // Obter informações do usuário
                    var userId = user.FindFirst(ClaimTypes.Name)?.Value;
                    await context.Response.WriteAsync($"Usuário autenticado com ID: {userId}");
                }
                else
                {
                    await context.Response.WriteAsync("Usuário não autenticado");
                }
            });
        });

        app.Run();
    }
}