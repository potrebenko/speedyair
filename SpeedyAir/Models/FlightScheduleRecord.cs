using System.Text.Json.Serialization;

namespace SpeedyAir
{
    public class FlightScheduleRecord
    {
        [JsonPropertyName("flight")]
        public int FlightNumber { get; set; }

        [JsonPropertyName("departureId")]
        public string DepartueId { get; set; }

        [JsonPropertyName("arrivalId")]
        public string ArrivalId { get; set; }
    
        [JsonPropertyName("day")]
        public int Day { get; set; }
    }
}