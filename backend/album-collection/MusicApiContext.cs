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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(
                new Artist
                {
                    Id = 1,
                    Name = "Rush",
                    Image = "",
                    Genre = "Rock"
                },
                new Artist
                {
                    Id = 2,
                    Name = "Queen",
                    Image = "",
                    Genre = "Rock"
                },
                new Artist
                {
                    Id = 3,
                    Name = "Ace of Base",
                    Image = "",
                    Genre = "Pop"
                },
                new Artist
                {
                    Id = 4,
                    Name = "Reel Big Fish",
                    Image = "",
                    Genre = "Ska"
                }
                );

            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    Id = 1,
                    Title = "Moving Pictures",
                    RecordLabel = "Anthem",
                    Image = "",
                    ArtistId = 1
                },
                new Album
                {
                    Id = 2,
                    Title = "A Night at the Opera",
                    RecordLabel = "EMI Records",
                    Image = "",
                    ArtistId = 2
                }
                );
        }
    }
}
