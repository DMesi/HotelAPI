using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                path: "c:\\hotelAPI\\log\\log-.txt",
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}]{Message:lj}{NewLine}{Exception}",
rollingInterval: RollingInterval.Day,
restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
).CreateLogger();

            try
            {
                Log.Information("Aplikacija pocinje sa radom");
                CreateHostBuilder(args).Build().Run();  // ovo je samo po defaultu
            }

            catch (Exception ex)
            {
                Log.Fatal(ex, "Neka greska");


            }

            finally
            {
                Log.CloseAndFlush();
            }


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog() // dodato za LOG
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
