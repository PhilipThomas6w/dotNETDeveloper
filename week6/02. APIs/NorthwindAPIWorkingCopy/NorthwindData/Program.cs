
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Models;


namespace NorthwindData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);   // Initializes a new instance of the WebApplicationBuilder class with preconfigured defaults

            var dbConnection = builder.Configuration["DefaultConnection"];

            // Add services to the container.

            builder.Services.AddControllers()
                .AddNewtonsoftJson((opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore))
                // This (.AddNewtonsoftJson...) prevents a circular reference when serializing

            builder.Services.AddDbContext<NorthwindContext>(opt => opt.UseSqlServer(dbConnection)); // Registering our database

            // All the services must be added before we build the WebApplication. 

            var app = builder.Build();  // Builds a WebApplication called app

            // Configure the HTTP request pipeline.  ###THIS IS KNOWN AS MIDDLEWARE###
            //  When we make a request to the WebApplication via the API, it passes through this pipeline, from the top to the bottom.
            //  The order is extremely important. This is a small selection; other middleware that can be added, such as app.use for authentication (must be added before authorization, for example).

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();  // Runs the app WebApplication
        }
    }
}