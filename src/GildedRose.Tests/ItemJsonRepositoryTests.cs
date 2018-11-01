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
            Assert.Equal(8, result.FirstOrDefault().Quality);
            Assert.Equal(3, result.FirstOrDefault().SellIn);
        }

        [Fact]
        public void ItemJsonRepository_UpdateItem_OnlyOneItemUpdated()
        {
            // Arrange
            var itemToUpdate = new Item()
            {
                Name = "Testitem",
                Quality = 99,
                SellIn = 99
            };
            // Act
            itemJsonRepo.AddOrUpdate(itemToUpdate);
            var result = itemJsonRepo.GetAll().ToList();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(99, result.FirstOrDefault().Quality);
            Assert.Equal(8, result.LastOrDefault().Quality);
        }

        [Fact]
        public void ItemJsonRepository_UpdateItems_ItemsUpdated()
        {
            // Arrange
            var itemsToUpdate = new List<Item>() {
                new Item()
                {
                    Name = "Testitem",
                    Quality = 99,
                    SellIn = 99
                },
                new Item()
                {
                    Name = "Testitem2",
                    Quality = 45,
                    SellIn = 45
                }
            };
            // Act
            itemJsonRepo.AddOrUpdate(itemsToUpdate);
            var result = itemJsonRepo.GetAll().ToList();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(99, result.FirstOrDefault().Quality);
            Assert.Equal(45, result.LastOrDefault().Quality);
        }
    }
}
