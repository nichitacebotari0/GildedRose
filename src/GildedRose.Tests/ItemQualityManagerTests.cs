using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using GildedRose.Console.Services.ItemStrategy;
using Xunit;

namespace GildedRose.Tests
{
    public class ItemQualityManagerTests
    {

        [Theory]
        [InlineData(1, 6)]
        [InlineData(-1, 5)]
        public void UpdateQuality_UpdateNormalItem_QualityDegrades(int currentSellIn, int expectedQuality)
        {
            // Arrange
            var strategy = new DefaultItemStrategy();
            var item = new Item { Name = Constants.DexVestPlus5, SellIn = currentSellIn, Quality = 7 };
            new Item { Name = Constants.MongooseElixir, SellIn = currentSellIn, Quality = 7 };

            // Act
            strategy.UpdateItemQuality(item);

            // Assert
            Assert.True(item.Quality == expectedQuality);
        }

        [Theory]
        [InlineData(1, 5)]
        [InlineData(-1, 3)]
        public void ItemQualityManager_UpdateConjuredItems_QualityDegrades(int currentSellIn, int expectedQuality)
        {
            // Arrange
            var strategy = new ConjuredItemStrategy();
            var item = new Item { Name = Constants.ConjuredManaCake, SellIn = currentSellIn, Quality = 7 };

            // Act
            strategy.UpdateItemQuality(item);

            // Assert
            Assert.True(item.Quality == expectedQuality);
        }

        [Fact]
        public void ItemQualityManager_UpdateSulfuras_DoesntChange()
        {
            // Arrange
            var strategy = new SulfurasStrategy();
            var item = new Item() { Name = Constants.Sulfuras, Quality = 80, SellIn = 0 };

            // Act
            strategy.UpdateItemQuality(item);

            // Assert
            Assert.Equal(80, item.Quality);
        }

        [Theory]
        [InlineData(49, 50)]
        [InlineData(50, 50)]
        public void ItemQualityManager_UpdateAgedBrie_IncreasesQuality(int currentQuality, int expectedQuality)
        {
            // Arrange
            var strategy = new AgedBrieStrategy();
            var item = new Item { Name = Constants.AgedBrie, SellIn = 2, Quality = currentQuality };


            // Act
            strategy.UpdateItemQuality(item);

            // Assert
            Assert.Equal(expectedQuality, item.Quality);
        }

        [Theory]
        [InlineData(20, 21)]
        [InlineData(10, 22)]
        [InlineData(5, 23)]
        [InlineData(-1, 0)]
        public void ItemQualityManager_UpdateBackStagePass_QualityChanges(int currentSellIn, int expectedQuality)
        {
            // Arrange
            var strategy = new BackstagePassStrategy();
            var item = new Item { Name = Constants.BackstagePass, SellIn = currentSellIn, Quality = 20 };

            // Act
            strategy.UpdateItemQuality(item);

            // Assert
            Assert.Equal(expectedQuality, item.Quality);
        }

    }
}