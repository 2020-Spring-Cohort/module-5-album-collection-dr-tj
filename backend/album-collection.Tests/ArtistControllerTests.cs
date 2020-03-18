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

        [Fact]
        public void Get_By_Id_Returns_Chosen_Artist()
        {
            var id = 2;
            var firstArtist = new Artist(1, "string1", "string2", "string3");
            var secondArtist = new Artist(2, "string4", "string5", "string6");
            var expectedArtist = new List<Artist>();
            expectedArtist.Add(firstArtist);
            expectedArtist.Add(secondArtist);

            artistRepo.GetById(id).Returns(secondArtist);
            var result = underTest.Get(id);

            Assert.Equal(secondArtist, result);
        }

        [Fact]
        public void Post_Creates_New_Artist()
        {
            var newArtist = new Artist(1, "string1", "string2", "string3");
            var artistList = new List<Artist>();
            artistRepo.When(a => a.Create(newArtist))
                .Do(a => artistList.Add(newArtist));

            artistRepo.GetAll().Returns(artistList);

            var result = underTest.Post(newArtist);

            Assert.Contains(newArtist, result);
        }

        [Fact]
        public void Delete_Removes_Artist()
        {
            var artistId = 1;
            var deletedArtist = new Artist(artistId, "string1", "string2", "string3");
            var artistList = new List<Artist>()
            {
                deletedArtist,
                new Artist(2, "string1", "string2", "string3")
            };
            artistRepo.GetById(artistId).Returns(deletedArtist);
            artistRepo.When(d => d.Delete(deletedArtist))
                .Do(d => artistList.Remove(deletedArtist));
            artistRepo.GetAll().Returns(artistList);

            var result = underTest.Delete(artistId);

            Assert.All(result, item => Assert.Contains("string1", item.Name));
        }
    }
}
