using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {

        [Theory]
        [InlineData(1,6)]
        [InlineData(-1,5)]
        public void UpdateQuality_UpdateNormalItems_QualityDegrades(int currentSellIn, int expectedQuality)
        {
            // Arrange
            var items = new List<Item>()
            {
            new Item {Name = Constants.DexVestPlus5, SellIn = currentSellIn, Quality = 7},
            new Item {Name = Constants.MongooseElixir, SellIn = currentSellIn, Quality = 7}
            };

            // Act
            ItemQualityManager.UpdateQuality(items);

            // Assert
            Assert.False(items.Any(x => x.Quality != expectedQuality));
            Assert.False(items.Any(x => x.SellIn != currentSellIn-1));
        }

        [Theory]
        [InlineData(1,5)]
        [InlineData(-1,3)]
        public void ItemQualityManager_UpdateConjuredItems_QualityDegrades(int currentSellIn, int expectedQuality)
        {
            // Arrange
            var items = new List<Item>()
            {
            new Item {Name = Constants.ConjuredManaCake, SellIn = currentSellIn, Quality = 7},
            };

            // Act
            ItemQualityManager.UpdateQuality(items);

            // Assert
            Assert.False(items.Any(x => x.Quality != expectedQuality));
            Assert.False(items.Any(x => x.SellIn != currentSellIn-1));
        }

        [Fact]
        public void ItemQualityManager_UpdateSulfuras_DoesntChange()
        {
            // Arrange
            var sulfuras = new Item() { Name = Constants.Sulfuras, Quality = 80, SellIn = 0 };
            var items = new List<Item>() { sulfuras };

            // Act
            ItemQualityManager.UpdateQuality(items);

            // Assert
            Assert.Equal(80, items.First(x => x.Name == sulfuras.Name).Quality);
            Assert.Equal(0, items.First(x => x.Name == sulfuras.Name).SellIn);
        }

        [Theory]
        [InlineData(49,50)]
        [InlineData(50,50)]
        public void ItemQualityManager_UpdateAgedBrie_IncreasesQuality(int currentQuality, int expectedQuality)
        {
            // Arrange
            var agedBrie = new Item { Name = Constants.AgedBrie, SellIn = 2, Quality = currentQuality };
            var items = new List<Item>() { agedBrie };

            // Act
            ItemQualityManager.UpdateQuality(items);

            // Assert
            Assert.Equal(expectedQuality, items.First(x => x.Name == agedBrie.Name).Quality);
            Assert.Equal(1, items.First(x => x.Name == agedBrie.Name).SellIn);
        }

        [Theory]
        [InlineData(20, 21)]
        [InlineData(10, 22)]
        [InlineData(5, 23)]
        [InlineData(-1, 0)]
        public void ItemQualityManager_UpdateBackStagePass_QualityChanges(int currentSellIn, int expectedQuality)
        {
            // Arrange
            var backstagePass = new Item { Name = Constants.BackstagePass, SellIn = currentSellIn, Quality = 20 };
            var items = new List<Item>() { backstagePass };

            // Act
            ItemQualityManager.UpdateQuality(items);

            // Assert
            Assert.Equal(expectedQuality, items.First(x => x.Name == backstagePass.Name).Quality);
            Assert.Equal(currentSellIn - 1, items.First(x => x.Name == backstagePass.Name).SellIn);
        }

    }
}