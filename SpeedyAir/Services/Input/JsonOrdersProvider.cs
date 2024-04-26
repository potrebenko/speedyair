using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace SpeedyAir
{
    public class JsonOrdersProvider : IOrdersProvider
    {
        private readonly IFlightOrdersConverter _flightOrdersConverter;
        private readonly FileConfiguration _configuration;

        public JsonOrdersProvider(IOptions<FileConfiguration> options, IFlightOrdersConverter flightOrdersConverter)
        {
            _flightOrdersConverter = flightOrdersConverter;
            _configuration = options.Value;
        }

        public Task<FlightOrders> FetchOrdersAsync()
        {
            var fileStream = File.OpenRead(_configuration.OrdersFileName);
            var rawOrders = JsonSerializer.Deserialize<Dictionary<string, OrderDescription>>(fileStream);

            return Task.FromResult(_flightOrdersConverter.Convert(rawOrders!));
        }
    }
}