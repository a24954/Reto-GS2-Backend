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

builder.Services.AddDbContext<ObraContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IObraRepository, ObraEFRepository>();
builder.Services.AddScoped<IObraService, ObraService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
});

app.UseAuthorization();
app.MapControllers();
app.Run();
