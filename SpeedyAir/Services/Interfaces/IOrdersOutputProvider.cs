using System.Collections.Generic;

namespace SpeedyAir
{
    public interface IOrdersOutputProvider
    {
        public void WriteOutput(List<OrderViewModel> orders);

    }
}