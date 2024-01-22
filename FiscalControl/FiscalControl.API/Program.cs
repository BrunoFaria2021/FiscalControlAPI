using FiscalControl.Application.Interfaces;
using FiscalControl.Application.Services;
using FiscalControl.Infra.Data.Interfaces;
using FiscalControl.Infra.Data.Repositories;
using FiscalControl.Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionLocalBruno"));
});

// Adiciona servi�os ao cont�iner.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application services configuration
builder.Services.AddScoped<IUsuarioAppService, UsuarioAppService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAutenticacaoAppService, AutenticacaoAppService>();
builder.Services.AddScoped<IAutenticacaoRepository, AutenticacaoRepository>();

// JWT authentication configuration
var key = Encoding.ASCII.GetBytes("a62263c508f45182b3d524b33ebc4c9b1652d9c195bbd81f9b0c0e6c312a7775");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// Middleware de Erros
app.UseExceptionHandler("/error");

// Middleware de Roteamento
app.UseRouting();

// Middleware de Autentica��o
app.UseAuthentication();

// Middleware de Autoriza��o
app.UseAuthorization();

// Middleware de HTTPS Redirection
app.UseHttpsRedirection();

// Middleware de CORS (se necess�rio)
// app.UseCors();

// Middleware de Documenta��o Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware de Endpoints de API
app.MapControllers();

app.Run();
