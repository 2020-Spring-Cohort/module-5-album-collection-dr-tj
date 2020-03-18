using album_collection.Controllers;
using album_collection.Models;
using album_collection.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace album_collection.Tests
{
    class AlbumControllerTests
    {
        private AlbumController underTest;
        IRepository<Album> albumRepo;

        public AlbumControllerTests()
        {
            albumRepo = Substitute.For<IRepository<Album>>();
            underTest = new AlbumController(albumRepo);
        }
    }
}
