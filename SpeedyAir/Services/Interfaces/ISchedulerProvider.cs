using System.Threading.Tasks;

namespace SpeedyAir
{
    public interface ISchedulerProvider
    {
        public Task<FlightSchedule> FetchScheduleAsync();
    }
}