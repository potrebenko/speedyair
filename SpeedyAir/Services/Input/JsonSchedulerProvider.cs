using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace SpeedyAir
{
    public class JsonSchedulerProvider : ISchedulerProvider
    {
        private readonly FileConfiguration _configuration;

        public JsonSchedulerProvider(IOptions<FileConfiguration> options)
        {
            _configuration = options.Value;
        }

        public async Task<FlightSchedule> FetchScheduleAsync()
        {
            var fileName = _configuration.ScheduleFileName;
            var scheduleJson = await File.ReadAllTextAsync(fileName);
            return JsonSerializer.Deserialize<FlightSchedule>(scheduleJson)!;
        }
    }
}