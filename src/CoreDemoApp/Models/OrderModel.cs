using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoApp.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public List<OrderDetailsModel> OrderDetails { get; set; }
    }
}
