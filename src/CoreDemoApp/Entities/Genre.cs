using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoApp.Entities
{
    public class Genre
    {
        public Genre()
        {
            this.Albums = new HashSet<Album>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
