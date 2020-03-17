using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace album_collection.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string RecordLabel { get; set; }
        public string Image { get; set; }

        [JsonIgnore]
        public virtual Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public virtual ICollection<Song> Songs { get; set; }

        public Album(int id, string title, string recordLabel, string image)
        {
            Id = id;
            Title = title;
            RecordLabel = recordLabel;
            Image = image;
        }

        public Album()
        {

        }
    }
}
