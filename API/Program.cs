using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TeatroApi.Data;
using TeatroApi.Business;
using TeatroApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ServerDB");

builder.Services.AddDbContext<TeatroContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IObraRepository, ObraEFRepository>();
builder.Services.AddScoped<IObraService, ObraService>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioEFRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IAsientosRepository, AsientosEFRepository>();
builder.Services.AddScoped<IAsientosService, AsientosService>();

builder.Services.AddScoped<IReservaRepository, ReservaEFRepository>();
builder.Services.AddScoped<IReservaService, ReservaService>();

builder.Services.AddScoped<ISesionRepository, SesionEFRepository>();
builder.Services.AddScoped<ISesionService, SesionService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
});

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:5224")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
});

app.UseAuthorization();
app.MapControllers();
app.Run();

