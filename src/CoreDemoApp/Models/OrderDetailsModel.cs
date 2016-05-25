using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoApp.Models
{
    public class OrderDetailsModel
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public AlbumModel Album { get; set; }
        public int Quantity { get; set; }
    }
}
