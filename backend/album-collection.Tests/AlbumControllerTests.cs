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
    public class AlbumControllerTests
    {
        private AlbumController underTest;
        IRepository<Album> albumRepo;

        public AlbumControllerTests()
        {
            albumRepo = Substitute.For<IRepository<Album>>();
            underTest = new AlbumController(albumRepo);
        }

        [Fact]
        public void Get_Returns_Two_Albums()
        {
            var expectedAlbums = new List<Album>()
            {new Album(1, "string1", "string2", "string3"),
            new Album(2, "string4", "string5", "string6")};
            albumRepo.GetAll().Returns(expectedAlbums);

            var result = underTest.Get();
            var countOfAlbum = result.Count();

            Assert.Equal(2, countOfAlbum);

        }

        [Fact]
        public void Get_By_Id_Returns_Chosen_Album()
        {
            var id = 2;
            var firstAlbum = new Album(1, "string1", "string2", "string3");
            var secondAlbum = new Album(2, "string4", "string5", "string6");
            var expectedAlbum = new List<Album>();
            expectedAlbum.Add(firstAlbum);
            expectedAlbum.Add(secondAlbum);

            albumRepo.GetById(id).Returns(secondAlbum);
            var result = underTest.Get(id);

            Assert.Equal(secondAlbum, result);
        }

        [Fact]
        public void Post_Creates_New_Album()
        {
            var newAlbum = new Album(1, "string1", "string2", "string3");
            var AlbumList = new List<Album>();
            albumRepo.When(a => a.Create(newAlbum))
                .Do(a => AlbumList.Add(newAlbum));

            albumRepo.GetAll().Returns(AlbumList);

            var result = underTest.Post(newAlbum);

            Assert.Contains(newAlbum, result);
        }

        [Fact]
        public void Delete_Removes_Album()
        {
            var AlbumId = 1;
            var deletedAlbum = new Album(AlbumId, "string1", "string2", "string3");
            var AlbumList = new List<Album>()
            {
                deletedAlbum,
                new Album(2, "string1", "string2", "string3")
            };
            albumRepo.GetById(AlbumId).Returns(deletedAlbum);
            albumRepo.When(d => d.Delete(deletedAlbum))
                .Do(d => AlbumList.Remove(deletedAlbum));
            albumRepo.GetAll().Returns(AlbumList);

            var result = underTest.Delete(AlbumId);

            Assert.All(result, item => Assert.Contains("string1", item.Title));
        }

        [Fact]
        public void Put_Updates_Album()
        {
            var originalAlbum = new Album(1, "title", "string2", "string3");
            var expectedAlbums = new List<Album>()
            {
                originalAlbum
            };
            var updatedAlbum = new Album(1, "new title", "string2", "updatedgenre");

            albumRepo.When(a => albumRepo.Update(updatedAlbum))
                .Do(Callback.First(a => expectedAlbums.Remove(originalAlbum))
                .Then(a => expectedAlbums.Add(updatedAlbum)));

            albumRepo.GetAll().Returns(expectedAlbums);

            var result = underTest.Put(updatedAlbum);

            Assert.All(result, item => Assert.Contains("new title", item.Title));
        }
    }
}
