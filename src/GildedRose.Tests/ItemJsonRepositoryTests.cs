using System;
using System.IO;
using System.Linq;
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

            File.WriteAllText(path,"[" +
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
    }
}
