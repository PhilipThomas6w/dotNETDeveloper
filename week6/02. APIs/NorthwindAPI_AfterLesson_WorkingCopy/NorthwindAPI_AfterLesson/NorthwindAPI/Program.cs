using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Data.Repositories;
using NorthwindAPI.Models;
using NorthwindAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
var connection = builder.Configuration["DefaultConnection"];
builder.Services.AddDbContext<NorthwindContext>(
    opt => opt.UseSqlServer(connection));


builder.Services.AddControllers()
    .AddNewtonsoftJson(
        opt => opt
            .SerializerSettings
            .ReferenceLoopHandling =
            Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddScoped(typeof(INorthwindRepository<>), typeof(NorthwindRepository<>));
builder.Services.AddScoped(typeof(INorthwindService<>), typeof(NorthwindService<>));
builder.Services.AddScoped<INorthwindRepository<Supplier>, SuppliersRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
