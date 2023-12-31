using GoAestheticApi.Repositories;
using GoAestheticEntidades;
using GoAestheticNegocio.Helpers;
using GoAetheticApi;
using GoAetheticApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var key = Encoding.ASCII.GetBytes(EnvironmentHelper.BuscaStringSegredoToken().Result);

builder.Services.AddDbContext<GoAestheticDbContext>(options =>
{
    options.UseSqlServer(EnvironmentHelper.BuscaStringConexaoDb().Result);
});

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddScoped<TokenService>();

//Repositories
builder.Services.AddTransient<AuthRepository>();
builder.Services.AddTransient<BalancaRepository>();
builder.Services.AddTransient<MarcoEvolucaoRepository>();
builder.Services.AddTransient<UsuarioRepository>();
builder.Services.AddTransient<LogRepository>();
builder.Services.AddTransient<DicionarioRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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