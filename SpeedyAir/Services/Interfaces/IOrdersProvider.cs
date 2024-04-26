using System.Threading.Tasks;

namespace SpeedyAir
{
    public interface IOrdersProvider
    {
        public Task<FlightOrders> FetchOrdersAsync();
    }
}