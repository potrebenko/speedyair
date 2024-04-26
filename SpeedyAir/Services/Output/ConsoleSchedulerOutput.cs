using System;

namespace SpeedyAir
{
    public class ConsoleSchedulerOutput : ISchedulerOutput
    {
        private const string OutputTemplate = "Flight: {0}, departure: {1}, arrival: {2}, day: {3}";

        public void WriteOutput(FlightSchedule flightSchedule)
        {
            foreach (var flightRecord in flightSchedule.Schedules)
            {
                Write(flightRecord);
            }
        }

        private void Write(FlightScheduleRecord flightRecord)
        {
            Console.WriteLine(OutputTemplate, flightRecord.FlightNumber, flightRecord.DepartueId,
                flightRecord.ArrivalId, flightRecord.Day);
        }
    }
}