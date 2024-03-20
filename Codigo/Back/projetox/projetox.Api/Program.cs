using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using projetox.Api.Extensoes;
using projetox.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text;

internal class Program
{
    class AuthFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.CustomAttributes().OfType<AuthorizeAttribute>().Any())
            {
                operation.Responses.Add("401", new OpenApiResponse { Description = "Acesso não autorizado." });
                operation.Responses.Add("403", new OpenApiResponse { Description = "Você não tem permissão para acessar este servidor." });
                operation.Responses.Add("500", new OpenApiResponse { Description = "Erro interno ao processar requisição." });

                var k200 = operation.Responses.Where(x => x.Key == "200");
                var k400 = operation.Responses.Where(x => x.Key == "400");

                foreach (var item in k200) item.Value.Description = "Requisição realizada com sucesso.";

                foreach (var item in k400) item.Value.Description = "Requisição inválida.";

                operation.Security.Add(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            }
        }
    }

    static string XmlCommentsFilePath
    {
        get
        {
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            var fileName = typeof(Program).GetTypeInfo().Assembly.GetName().Name + ".xml";
            return Path.Combine(basePath, fileName);
        }
    }

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(name: "v1", new OpenApiInfo()
            {
                Version = "v1",
                Title = "Projeto X",
                Description = "BackEnd Projeto X"

            });

            options.IncludeXmlComments(XmlCommentsFilePath);

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Autorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Insira o token JWT no seguinte formato: Bearer {seu token}"
            });

            options.OperationFilter<AuthFilter>();
        });

        builder.Services.AddAuthentication(x => 
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options => 
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"] ?? String.Empty)),
                };
            });

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

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}