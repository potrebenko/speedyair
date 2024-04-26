using System.Collections.Generic;

namespace SpeedyAir
{
    public class FlightOrdersConverter : IFlightOrdersConverter
    {
        public FlightOrders Convert(Dictionary<string, OrderDescription> rawOrders)
        {
            var flightOrders = new FlightOrders();
            flightOrders.Orders = new List<Order>(rawOrders.Count);

            foreach (var keyValuePair in rawOrders)
            {
                flightOrders.Orders.Add(new Order
                {
                    OrderId = keyValuePair.Key,
                    Destination = keyValuePair.Value.Destination
                });
            }

            return flightOrders;
        }
    }
}