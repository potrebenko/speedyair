using System.Threading.Tasks;

namespace SpeedyAir
{
    public class MongoDbSchedulerProvider : ISchedulerProvider
    {
        public Task<FlightSchedule> FetchScheduleAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}