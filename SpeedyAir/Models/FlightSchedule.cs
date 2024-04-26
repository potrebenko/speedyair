using System.Text.Json.Serialization;

namespace SpeedyAir
{
    public class FlightSchedule
    {
        [JsonPropertyName("schedules")]
        public FlightScheduleRecord[] Schedules { get; set; }
    }
}