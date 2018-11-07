using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GildedRose.Console;
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
            File.WriteAllText(path,
                "<?xml  version=\"1.0\" encoding=\"utf-8\"?>"  + 
                    @"<ArrayOfItem>
                      <Item>
                        <Name>Testitem</Name>
                        <SellIn>3</SellIn>
                        <Quality>8</Quality>
                      </Item>
                      <Item>
                        <Name>Testitem2</Name>
                        <SellIn>3</SellIn>
                        <Quality>8</Quality>
                      </Item>
                    </ArrayOfItem>");
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

        [Fact]
        public void itemXmlRepository_GetAllItems_MapsCorrectly()
        {
            // Act
            var result = itemXmlRepo.GetAll().ToList();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void itemXmlRepository_GetAllItems_QualityMapsCorrectly()
        {
            // Act
            var result = itemXmlRepo.GetAll().ToList();

            // Assert
            Assert.Equal(8, result.FirstOrDefault().Quality);
        }

        [Fact]
        public void itemXmlRepository_GetAllItems_SellInMapsCorrectly()
        {
            // Act
            var result = itemXmlRepo.GetAll().ToList();

            // Assert
            Assert.Equal(3, result.FirstOrDefault().SellIn);
        }

        [Fact]
        public void itemXmlRepository_UpdateItem_FirstItemQualityUpdated()
        {
            // Arrange
            var itemToUpdate = new ItemBuilder("Testitem")
                .WithQuality(99)
                .Build(); ;

            // Act
            itemXmlRepo.AddOrUpdate(itemToUpdate);
            var result = itemXmlRepo.GetAll().ToList();

            // Assert
            Assert.Equal(99, result.FirstOrDefault().Quality);
        }

        [Fact]
        public void itemXmlRepository_UpdateItem_OnlyFirstItemQualityUpdated()
        {
            // Arrange
            var itemToUpdate = new ItemBuilder("Testitem")
                .WithQuality(99)
                .Build(); ;

            // Act
            itemXmlRepo.AddOrUpdate(itemToUpdate);
            var result = itemXmlRepo.GetAll().ToList();

            // Assert
            Assert.Equal(8, result.LastOrDefault().Quality);
        }

        [Fact]
        public void itemXmlRepository_UpdateItems_ItemsQualityUpdated()
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
            itemXmlRepo.AddOrUpdate(itemsToUpdate);
            var result = itemXmlRepo.GetAll().ToList();

            // Assert
            Assert.False(result.Any(x => x.Quality != 99));
        }
    }
}
