using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemoApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreDemoApp.Repositories
{
    public class AlbumRepository
    {
        EntitiesDbContext _entities = new EntitiesDbContext();

        public Album GetAlbum(Guid albumId)
        {
            return _entities.Album.FirstOrDefault(a => a.AlbumId == albumId);
        }

        public List<Album> GetAlbums()
        {

            return _entities.Album.Include(a => a.Genre).ToList();
        }
    }
}
