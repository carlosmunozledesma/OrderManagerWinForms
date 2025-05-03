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
        public string Status { get; set; } = "Pending";
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();
        public int Progress { get; set; } = 0;  // 0 to 100
    }
}
