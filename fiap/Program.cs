using System.Text;
using AutoMapper;
using fiap.Data;
using fiap.Data.Repository;
using fiap.Models;
using fiap.Services;
using fiap.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region INICIALIZANDO O BANCO DE DADOS
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DataBaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);
#endregion

#region Repositorios
builder.Services.AddScoped<IsemaforoRepository, SemaforoRepository>();

#endregion

#region Services
builder.Services.AddScoped<ISemaforoService, SemaforoService>();
//builder.Services.AddScoped<IAuthService, AuthService>();
#endregion

#region AutoMapper
var mapperConfig = new AutoMapper.MapperConfiguration(c =>
{

    c.AllowNullCollections = true;
    c.AllowNullDestinationValues = true;

    c.CreateMap<SemaforoModel, SemaforoViewModel>();
    c.CreateMap<SemaforoViewModel, SemaforoModel>();
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
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
