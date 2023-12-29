using HotelListing.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace HotelListing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // -> This is used to configure the logging builder
            //builder.Host.ConfigureLogging(logging =>
            //{
            //    logging.ClearProviders().AddConsole();

            //});


            //builder.Logging.ClearProviders().AddConsole(); -> This is the modern approach


            // Adding the Serilog to read from the configuration settings
            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));

            // Adding the SQL Provider
            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString(
                        "sqlConnection"));
            });


            // Adding the policy to the cors
            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllowAllOriginPolicy", builder => 
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
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

            // adding the cors middleware configured in the services to the app
            app.UseCors("AllowAllOriginPolicy");
        

            // log all HTTO request
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
