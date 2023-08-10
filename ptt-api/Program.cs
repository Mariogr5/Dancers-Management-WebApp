using Microsoft.AspNetCore.Mvc;
using NLog.Web;
using ptt_api;
using ptt_api.Entities;
using ptt_api.Middlewares;
using ptt_api.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseNLog();
builder.Services.AddControllers();
builder.Services.AddScoped<IDanceClubService, DanceClubService>();
builder.Services.AddScoped<IDancerService, DancerService>();
builder.Services.AddScoped<IDanceEventService, DanceEventService>();
builder.Services.AddDbContext<DancersDbContext>();
builder.Services.AddScoped<DancersSeeder>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<DancersSeeder>();
seeder.Seed();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ptt api");
});
app.UseAuthorization();

app.MapControllers();

app.Run();
