using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using album_collection.Models;

namespace album_collection
{
    public class MusicApiContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=MusicApiDb;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString)
                          .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        //seed data goes here
    }
}
