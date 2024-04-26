using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SpeedyAir
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var configurationBuilder =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(Configurations.FileConfiguration, false, false)
                    .Build();

            var provider = ConfigureServices(configurationBuilder);
            
            var service = provider.GetRequiredService<ISchedulerService>();
            await service.ScheduleOrdersAsync();
            
            Console.WriteLine("Finished. Press any key to continue...");
            Console.ReadKey();
        }

        private static IServiceProvider ConfigureServices(IConfigurationRoot configurationBuilder)
        {
            var serviceCollection = new ServiceCollection()
                .AddSingleton<ISchedulerService, OrderSchedulerService>()
                .AddSingleton<ISchedulerProvider, JsonSchedulerProvider>()
                .AddSingleton<IOrdersProvider, JsonOrdersProvider>()
                .AddSingleton<IOrdersOutputProvider, ConsoleOrdersOutputProvider>()
                .AddSingleton<ISchedulerOutput, ConsoleSchedulerOutput>()
                .AddSingleton<IFlightOrdersConverter, FlightOrdersConverter>();

            serviceCollection.Configure<FileConfiguration>(
                configurationBuilder.GetSection(FileConfiguration.Configuration));
            return serviceCollection.BuildServiceProvider();
        }
    }
}