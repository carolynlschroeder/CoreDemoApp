using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoApp.Models
{
    public class CartItem
    {

        public Guid CartId { get; set; }
        public Guid AlbumId { get; set; }
        public int Quantity { get; set; }
    }
}
