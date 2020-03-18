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
    public class ArtistControllerTests
    {
        private ArtistController underTest;
        IRepository<Artist> artistRepo;

        public ArtistControllerTests()
        {
            artistRepo = Substitute.For<IRepository<Artist>>();
            underTest = new ArtistController(artistRepo);
        }

        [Fact]
        public void Get_Returns_Two_Artists()
        {
            var expectedArtists = new List<Artist>()
            {new Artist(1, "string1", "string2", "string3"),
            new Artist(2, "string4", "string5", "string6")};
            artistRepo.GetAll().Returns(expectedArtists);

            var result = underTest.Get();
            var countOfArtist = result.Count();

            Assert.Equal(2, countOfArtist);

        }
    }
}
