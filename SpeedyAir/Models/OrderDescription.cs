using System.Text.Json.Serialization;

namespace SpeedyAir
{
    public class OrderDescription
    {
        [JsonPropertyName("destination")]
        public string Destination { get; set; }
    }
}