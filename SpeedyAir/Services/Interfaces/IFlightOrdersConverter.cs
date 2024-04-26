using System.Collections.Generic;

namespace SpeedyAir
{
    public interface IFlightOrdersConverter
    {
        FlightOrders Convert(Dictionary<string, OrderDescription> rawOrders);
    }
}