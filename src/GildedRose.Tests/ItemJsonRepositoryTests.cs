using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GildedRose.Console;
using GildedRose.Console.Repository;
using Xunit;

namespace GildedRose.Tests
{
    public class ItemJsonRepositoryTests : IDisposable
    {
        private ItemJsonRepository itemJsonRepo;
        private string path = "C:\\Workspace\\ItemRepoTests.json";
        public ItemJsonRepositoryTests()
        {

            File.WriteAllText(path, "[" +
                "{\"name\" : \"Testitem\"," +
                "\"Quality\" : 8," +
                " \"SellIn\" : 3}," +
                "{\"name\" : \"Testitem2\"," +
                "\"Quality\" : 8," +
                " \"SellIn\" : 3}]");
            itemJsonRepo = new ItemJsonRepository(path);
        }

        public void Dispose()
        {
            File.Delete(path);
        }

        [Fact]
        public void ItemJsonRepository_GetAllItems_MapsCorrectly()
        {
            // Act
            var result = itemJsonRepo.GetAll().ToList();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void ItemJsonRepository_GetAllItems_QualityMapsCorrectly()
        {
            // Act
            var result = itemJsonRepo.GetAll().ToList();

            // Assert
            Assert.Equal(8, result.FirstOrDefault().Quality);
        }

        [Fact]
        public void ItemJsonRepository_GetAllItems_SellInMapsCorrectly()
        {
            // Act
            var result = itemJsonRepo.GetAll().ToList();

            // Assert
            Assert.Equal(3, result.FirstOrDefault().SellIn);
        }

        [Fact]
        public void ItemJsonRepository_UpdateItem_FirstItemQualityUpdated()
        {
            // Arrange
            var itemToUpdate = new ItemBuilder("Testitem")
                .WithQuality(99)
                .Build(); ;

            // Act
            itemJsonRepo.AddOrUpdate(itemToUpdate);
            var result = itemJsonRepo.GetAll().ToList();

            // Assert
            Assert.Equal(99, result.FirstOrDefault().Quality);
        }

        [Fact]
        public void ItemJsonRepository_UpdateItem_OnlyFirstItemQualityUpdated()
        {
            // Arrange
            var itemToUpdate = new ItemBuilder("Testitem")
                .WithQuality(99)
                .Build(); ;

            // Act
            itemJsonRepo.AddOrUpdate(itemToUpdate);
            var result = itemJsonRepo.GetAll().ToList();

            // Assert
            Assert.Equal(8, result.LastOrDefault().Quality);
        }

        [Fact]
        public void ItemJsonRepository_UpdateItems_ItemsQualityUpdated()
        {
            // Arrange
            var itemBuilder = new ItemBuilder()
                .WithQuality(99);
            var itemsToUpdate = new List<Item>() {
            itemBuilder
                .WithName("Testitem")
                .Build(),

            itemBuilder
                .WithName("Testitem2")
                .Build()
            };
            // Act
            itemJsonRepo.AddOrUpdate(itemsToUpdate);
            var result = itemJsonRepo.GetAll().ToList();

            // Assert
            Assert.False(result.Any(x => x.Quality != 99));
        }
    }
}
