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

        // Rota para autentica��o
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapPost("/login", async context =>
            {
                var username = context.Request.Form["username"];
                var password = context.Request.Form["password"];

                // Verifica��o de usu�rio e senha (implementa��o de exemplo)
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
                // Aqui voc� pode acessar o contexto do usu�rio autenticado
                var user = context.User;
                if (user.Identity.IsAuthenticated)
                {
                    // Obter informa��es do usu�rio
                    var userId = user.FindFirst(ClaimTypes.Name)?.Value;
                    await context.Response.WriteAsync($"Usu�rio autenticado com ID: {userId}");
                }
                else
                {
                    await context.Response.WriteAsync("Usu�rio n�o autenticado");
                }
            });
        });

        app.Run();
    }
}