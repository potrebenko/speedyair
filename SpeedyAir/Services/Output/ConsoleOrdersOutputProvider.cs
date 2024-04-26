using System;
using System.Collections.Generic;

namespace SpeedyAir
{
    public class ConsoleOrdersOutputProvider : IOrdersOutputProvider
    {
        private const string SuccessOrder = "order: {0}, flightNumber: {1}, departure: {2}, arrival: {3}, day: {4}";
        private const string NotScheduled = "order: {0}, flightNumber: not scheduled";

        public void WriteOutput(List<OrderViewModel> orders)
        {
            foreach (var flightResult in orders)
            {
                if (!string.IsNullOrEmpty(flightResult.ArrivalId))
                {
                    Console.WriteLine(SuccessOrder, flightResult.OrderId, flightResult.FlightNumber,
                        flightResult.DepartureId, flightResult.ArrivalId, flightResult.Day);
                }
                else
                {
                    Console.WriteLine(NotScheduled, flightResult.OrderId);
                }
            }
        }
    }
}