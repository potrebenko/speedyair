namespace SpeedyAir
{
    public class AvailableFlight
    {
        public const int MaximumFlightCapacity = 20;
        public int Day { get; private set; }
        public string DepartureId { get; private set; }
        public string ArrivalId { get; private set; }
        public int Capacity { get; private set; }
        public int FlightNumber { get; private set; }

        private AvailableFlight()
        {
            
        }

        public void DecreaseCapacity()
        {
            Capacity--;
        }

        public static AvailableFlight CreateFlight(int day, string departureId, string arrivalId, int flightNumber)
        {
            return new AvailableFlight
            {
                Day = day,
                DepartureId = departureId,
                ArrivalId = arrivalId,
                Capacity = MaximumFlightCapacity,
                FlightNumber = flightNumber
            };
        } 
    }
}