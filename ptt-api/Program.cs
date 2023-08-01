using Microsoft.AspNetCore.Mvc;
using ptt_api;
using ptt_api.Entities;
using ptt_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IDanceClubService, DanceClubService>();
builder.Services.AddDbContext<DancersDbContext>();
builder.Services.AddScoped<DancersSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<DancersSeeder>();
seeder.Seed();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
