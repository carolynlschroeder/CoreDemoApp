using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Threading.Tasks;

namespace CoreDemoApp.Models
{
    public class AlbumModel
    {

        public Guid AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public GenreModel Genre { get; set; }
        public ArtistModel Artist { get; set; }
    }
}
