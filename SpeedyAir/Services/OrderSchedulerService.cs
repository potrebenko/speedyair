using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeedyAir
{
    public class OrderSchedulerService : ISchedulerService
    {
        private readonly ISchedulerProvider _schedulerProvider;
        private readonly IOrdersProvider _ordersProvider;
        private readonly IOrdersOutputProvider _ordersOutputProvider;
        private readonly ISchedulerOutput _schedulerOutput;

        public OrderSchedulerService(ISchedulerOutput schedulerOutput, ISchedulerProvider schedulerProvider,
            IOrdersProvider ordersProvider, IOrdersOutputProvider ordersOutputProvider)
        {
            _schedulerOutput = schedulerOutput;
            _schedulerProvider = schedulerProvider;
            _ordersProvider = ordersProvider;
            _ordersOutputProvider = ordersOutputProvider;
        }

        public async Task ScheduleOrdersAsync()
        {
            var schedule = await _schedulerProvider.FetchScheduleAsync();
            var orders = await _ordersProvider.FetchOrdersAsync();

            _schedulerOutput.WriteOutput(schedule);
            var calculatedOrders = CalculateOrders(schedule, orders);
            Console.WriteLine();
            _ordersOutputProvider.WriteOutput(calculatedOrders);
        }

        private List<OrderViewModel> CalculateOrders(FlightSchedule schedule, FlightOrders flightOrders)
        {
            var availableFlights = InitializeAvailableFlights(schedule);
            var scheduledOrders = ScheduleOrders(flightOrders, availableFlights);
            return scheduledOrders;
        }

        private static List<OrderViewModel> ScheduleOrders(FlightOrders flightOrders,
            Dictionary<string, List<AvailableFlight>> availableFlights)
        {
            var scheduleOrders = new List<OrderViewModel>(flightOrders.Orders.Count);

            foreach (var order in flightOrders.Orders)
            {
                var flightAvailable = false;
                if (availableFlights.TryGetValue(order.Destination, out var flights))
                {
                    foreach (var availableFlight in flights)
                    {
                        if (availableFlight.Capacity > 0)
                        {
                            // Scheduled
                            scheduleOrders.Add(new OrderViewModel
                            {
                                FlightNumber = availableFlight.FlightNumber,
                                Day = availableFlight.Day,
                                ArrivalId = availableFlight.ArrivalId,
                                DepartureId = availableFlight.DepartureId,
                                OrderId = order.OrderId
                            });
                            availableFlight.DecreaseCapacity();
                            flightAvailable = true;
                            break;
                        }
                    }
                }

                // Not scheduled
                if (!flightAvailable)
                {
                    scheduleOrders.Add(new OrderViewModel
                    {
                        OrderId = order.OrderId
                    });
                }
            }

            return scheduleOrders;
        }

        private static Dictionary<string, List<AvailableFlight>> InitializeAvailableFlights(FlightSchedule schedule)
        {
            var availableFlights = new Dictionary<string, List<AvailableFlight>>(StringComparer.Ordinal);
            foreach (var flight in schedule.Schedules)
            {
                if (!availableFlights.ContainsKey(flight.ArrivalId))
                {
                    availableFlights[flight.ArrivalId] = new List<AvailableFlight>();
                }

                var availableFlight = AvailableFlight.CreateFlight(flight.Day, flight.DepartueId, flight.ArrivalId,
                    flight.FlightNumber);
                availableFlights[flight.ArrivalId].Add(availableFlight);
            }

            return availableFlights;
        }
    }
}