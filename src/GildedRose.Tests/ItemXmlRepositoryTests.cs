using System;
using System.IO;
using GildedRose.Console.Repository;
using Xunit;

namespace GildedRose.Tests
{
    public class ItemXmlRepositoryTests : IDisposable
    {
        private ItemXmlRepository itemXmlRepo;
        private string path = "C:\\Workspace\\ItemRepoTests.Xml";
        public ItemXmlRepositoryTests()
        {
            itemXmlRepo = new ItemXmlRepository(path);
        }

        public void Dispose()
        {
            File.Delete(path);
        }

        [Fact]
        public void ItemXmlRepository_GetAll()
        {
            // Act
            var result = itemXmlRepo.GetAll();

            // Assert 
            Assert.NotNull(result);
        }
    }
}
