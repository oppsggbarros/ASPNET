// Comando para colcoar os migrations no banco de dados
// dotnet ef migrations add InitialCreate
// dotnet ef database update
// using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using FluentValidation.AspNetCore;
using System.Text;
using SistemaEscolarAPI.DB;
using SistemaEscolarAPI.Models;
using SistemaEscolarAPI.DTOs;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext com PostgreSQL (usando appsettings.json)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// Adicionar serviços ao contêiner
builder.Services.AddControllers(); // Adiciona suporte a controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => // para gerar a documentação lá em baixar, que é o Schemas
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema Escolar API", Version = "v1" }); // Define o título e a versão da API na documentação do Swagger
});
// var jwtKey = builder.Configuration["Jwt:Key"];
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        Options.TokenValidationParameters = new TokenValidationParameters {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("my_secret_key")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// Configurar middlewares
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseAuthorization();

app.


app.MapControllers(); // Mapeia os controladores
app.Run();

// Link para Swagger: http://localhost:5164/swagger/index.html