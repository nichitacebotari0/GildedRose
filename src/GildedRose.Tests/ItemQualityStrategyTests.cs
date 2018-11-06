using GildedRose.Console;
using GildedRose.Console.Services.ItemStrategy;
using Xunit;

namespace GildedRose.Tests
{
    public class ItemQualityStrategyTests
    {

        [Theory]
        [InlineData(1, 6)]
        [InlineData(-1, 5)]
        public void UpdateQuality_UpdateNormalItem_QualityDegrades(int currentSellIn, int expectedQuality)
        {
            // Arrange
            var strategy = new DefaultItemStrategy();
            var item = new ItemBuilder(Constants.DexVestPlus5)
                .WithQuality(7)
                .WithSellIn(currentSellIn)
                .Build();

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
            var item = new ItemBuilder(Constants.ConjuredManaCake)
                .WithQuality(7)
                .WithSellIn(currentSellIn)
                .Build();

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
            var item = new ItemBuilder(Constants.Sulfuras)
                .WithQuality(80)
                .WithSellIn(0)
                .Build();

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
            var item = new ItemBuilder(Constants.AgedBrie)
                .WithQuality(currentQuality)
                .WithSellIn(2)
                .Build();


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
            var item = new ItemBuilder(Constants.BackstagePass)
                .WithQuality(20)
                .WithSellIn(currentSellIn)
                .Build();

            // Act
            strategy.UpdateItemQuality(item);

            // Assert
            Assert.Equal(expectedQuality, item.Quality);
        }

    }
}