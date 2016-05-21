using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreDemoApp.Entities
{
    public class EntitiesDbContext : DbContext
    {
        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Genre> Genre { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetails> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=LAPTOP-6RLIUI13\SQLSERVEREXPRESS;Database=MVCMusicStore;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

    }
}
