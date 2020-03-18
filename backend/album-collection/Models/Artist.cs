using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace album_collection.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Genre { get; set; }
        public virtual ICollection<Album> Albums { get; set; }

        public Artist(int id, string name, string image, string genre)
        {
            Id = id;
            Name = name;
            Image = image;
            Genre = genre;
        }
        public Artist()
        {
        }
    }   
}
