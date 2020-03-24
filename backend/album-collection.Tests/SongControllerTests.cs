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
    public class SongControllerTests
    {
        private SongController underTest;
        IRepository<Song> songRepo;

        public SongControllerTests()
        {
            songRepo = Substitute.For<IRepository<Song>>();
            underTest = new SongController(songRepo);
        }

        [Fact]
        public void Get_Returns_Two_Songs()
        {
            var expectedSongs = new List<Song>()
            {new Song(1, "string1", "string2"),
            new Song(2, "string3", "string4")};
            songRepo.GetAll().Returns(expectedSongs);

            var result = underTest.Get();
            var countOfSong = result.Count();

            Assert.Equal(2, countOfSong);

        }

        [Fact]
        public void Get_By_Id_Returns_Chosen_Song()
        {
            var id = 2;
            var firstSong = new Song(1, "string1", "string2");
            var secondSong = new Song(2, "string3", "string4");
            var expectedSong = new List<Song>();
            expectedSong.Add(firstSong);
            expectedSong.Add(secondSong);

            songRepo.GetById(id).Returns(secondSong);
            var result = underTest.Get(id);

            Assert.Equal(secondSong, result);
        }

        [Fact]
        public void Post_Creates_New_Song()
        {
            var newSong = new Song(1, "string1", "string2");
            var SongList = new List<Song>();
            songRepo.When(a => a.Create(newSong))
                .Do(a => SongList.Add(newSong));

            songRepo.GetAll().Returns(SongList);

            var result = underTest.Post(newSong);

            Assert.Contains(newSong, result);
        }

        [Fact]
        public void Delete_Removes_Song()
        {
            var SongId = 1;
            var deletedSong = new Song(SongId, "string1", "string2");
            var SongList = new List<Song>()
            {
                deletedSong,
                new Song(2, "string1", "string2")
            };
            songRepo.GetById(SongId).Returns(deletedSong);
            songRepo.When(d => d.Delete(deletedSong))
                .Do(d => SongList.Remove(deletedSong));
            songRepo.GetAll().Returns(SongList);

            var result = underTest.Delete(SongId);

            Assert.All(result, item => Assert.Contains("string1", item.Title));
        }

        [Fact]
        public void Put_Updates_Song()
        {
            var originalSong = new Song(1, "title", "string2");
            var expectedSongs = new List<Song>()
            {
                originalSong
            };
            var updatedSong = new Song(1, "new title", "string2");

            songRepo.When(a => songRepo.Update(updatedSong))
                .Do(Callback.First(a => expectedSongs.Remove(originalSong))
                .Then(a => expectedSongs.Add(updatedSong)));

            songRepo.GetAll().Returns(expectedSongs);

            var result = underTest.Put(updatedSong);

            Assert.All(result, item => Assert.Contains("new title", item.Title));
        }
    }
}
