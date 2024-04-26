using System.Threading.Tasks;

namespace SpeedyAir
{
    public interface ISchedulerService
    {
        Task ScheduleOrdersAsync();
    }
}