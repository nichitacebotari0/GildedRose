using System.Collections.Generic;
using GildedRose.Console.Infrastructure;
using GildedRose.Console.Services.ItemStrategy;

namespace GildedRose.Console
{
    public class ItemQualityManager : IItemQualityManager
    {
        IItemStrategyFactory itemStrategyFactory;
        public ItemQualityManager(IItemStrategyFactory itemQualityStrategyFactory)
        {
            itemStrategyFactory = itemQualityStrategyFactory;
        }
        public void UpdateQuality(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                var qualityStrategy = GetQualityStrategy(item.Name);
                    qualityStrategy.UpdateItemQuality(item);
            }
        }

        private IItemQualityStrategy GetQualityStrategy(string itemName)
        {
            return itemStrategyFactory.CreateNew(itemName);
        }
    }
}
