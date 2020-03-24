using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using album_collection.Models;
using album_collection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace album_collection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        IRepository<Song> songRepo;

        public SongController(IRepository<Song> songRepo)
        {
            this.songRepo = songRepo;
        }

        // GET: api/Album
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return songRepo.GetAll();
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public Song Get(int id)
        {
            return songRepo.GetById(id);
        }

        // POST: api/Album
        [HttpPost]
        public IEnumerable<Song> Post([FromBody] Song value)
        {
            songRepo.Create(value);
            return songRepo.GetAll();
        }

        // PUT: api/Album/5
        [HttpPut("{id}")]
        public IEnumerable<Song> Put([FromBody] Song value)
        {
            songRepo.Update(value);
            return songRepo.GetAll();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IEnumerable<Song> Delete(int id)
        {
            var album = songRepo.GetById(id);
            songRepo.Delete(album);
            return songRepo.GetAll();
        }
    }
}
