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
                    Image = "./img/Rush.jpg",
                    Genre = "Rock"
                },
                new Artist
                {
                    Id = 2,
                    Name = "Queen",
                    Image = "./img/Queen.jpg",
                    Genre = "Rock"
                },
                new Artist
                {
                    Id = 3,
                    Name = "Ace of Base",
                    Image = "./img/Aceofbase.jpg",
                    Genre = "Pop"
                },
                new Artist
                {
                    Id = 4,
                    Name = "Reel Big Fish",
                    Image = "./img/Reelbigfish.jpg",
                    Genre = "Ska"
                }
                );

            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    Id = 1,
                    Title = "Moving Pictures",
                    RecordLabel = "Anthem",
                    Image = "./img/Movingpictures.jpg",
                    ArtistId = 1
                },
                new Album
                {
                    Id = 2,
                    Title = "A Night at the Opera",
                    RecordLabel = "EMI Records",
                    Image = "./img/QueenANightAtTheOpera.png",
                    ArtistId = 2
                },
                new Album
                {
                    Id = 3,
                    Title = "The Sign",
                    RecordLabel = "Arista",
                    Image = "./img/TheSign.jpg",
                    ArtistId = 3
                },
                new Album
                {
                    Id = 4,
                    Title = "Turn the Radio Off",
                    RecordLabel = "Mojo",
                    Image = "./img/Turntheradiooff.jpg",
                    ArtistId = 4
                }
                );

            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id = 1,
                    Title = "Tom Sawyer",
                    Duration = "4:34",
                    AlbumId = 1
                },
                new Song
                {
                    Id = 2,
                    Title = "YYZ",
                    Duration = "4:26",
                    AlbumId = 1
                },
                new Song
                {
                    Id = 3,
                    Title = "Behemian Rhapsody",
                    Duration = "5:55",
                    AlbumId = 2
                },
                new Song
                {
                    Id = 4,
                    Title = "You're My Best Friend",
                    Duration = "2:52",
                    AlbumId = 2
                },
                new Song
                {
                    Id = 5,
                    Title = "All That She Wants",
                    Duration = "3:30",
                    AlbumId = 3
                },
                new Song
                {
                    Id = 6,
                    Title = "The Sign",
                    Duration = "3:08",
                    AlbumId = 3
                },
                new Song
                {
                    Id = 7,
                    Title = "Sell Out",
                    Duration = "3:47",
                    AlbumId = 4
                },
                new Song
                {
                    Id = 8,
                    Title = "Beer",
                    Duration = "3:30",
                    AlbumId = 4
                }
                );
        }
    }
}
