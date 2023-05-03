
using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        //builder.Services.AddEndpointsApiExplorer();  // commented this out
        //builder.Services.AddSwaggerGen(); // commented this out

        builder.Services.AddDbContext<ToDoContext>(opt => opt.UseInMemoryDatabase("ToDoList"));

        var app = builder.Build();

        // Configure the HTTP request pipeline. -- (middleware) -- 
        if (app.Environment.IsDevelopment())
        {
            //app.UseSwagger();   // commented this out
            //app.UseSwaggerUI();  // commented this out
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}