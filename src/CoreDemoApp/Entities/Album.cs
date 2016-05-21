using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoApp.Entities
{
    public class Album
    {

        public Guid AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public Artist Artist { get; set; }
        public Genre Genre { get; set; }
    }
}
