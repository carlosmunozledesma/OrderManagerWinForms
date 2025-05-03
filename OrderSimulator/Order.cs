using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSimulator
{
    public class Order
    {
        public string Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int DurationInSeconds { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();
        public int Progress { get; set; } = 0;  // 0 to 100

        private static Random random = new Random();

        public Order()
        {
            Id = Guid.NewGuid().ToString().Substring(0, 8);
            Status = OrderStatus.Pending;
            Progress = 0;
            DurationInSeconds = random.Next(3, 10); // Random between 3 and 10 seconds
        }
    }
}
