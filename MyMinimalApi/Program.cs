using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyMinimalApi;
using MyMinimalApi.Data;
using MyMinimalApi.Services;
using MyMinimalApi.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("PetsDb");
builder.Services.AddDbContext<PetContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IPetService, PetService>();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapEndpoints();

app.Run();
