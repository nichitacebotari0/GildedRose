using GildedRose.Console.Services.ItemStrategy;

namespace GildedRose.Console.Infrastructure
{
    public interface IItemStrategyFactory
    {
        IItemQualityStrategy CreateNew(string itemName);
    }
}
