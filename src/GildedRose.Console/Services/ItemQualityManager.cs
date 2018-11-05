using System.Collections.Generic;
using GildedRose.Console.Services.ItemStrategy;

namespace GildedRose.Console
{
    public class ItemQualityManager : IItemQualityManager
    {
        public void UpdateQuality(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                var qualityStrategy = GetQualityStrategy(item.Name);
                if (item.Quality >= Constants.MinQuality && item.Quality <= Constants.MaxQuality)
                {
                    qualityStrategy.UpdateItemQuality(item);
                }
            }
        }

        private IItemQualityStrategy GetQualityStrategy(string itemName)
        {
            switch (itemName)
            {
                case Constants.Sulfuras:
                    {
                        return new SulfurasStrategy();
                    }
                case Constants.AgedBrie:
                    {
                        return new AgedBrieStrategy();
                    }
                case Constants.ConjuredManaCake:
                    {
                        return new ConjuredItemStrategy();
                    }
                case Constants.BackstagePass:
                    {
                        return new BackstagePassStrategy();
                    }
                default:
                    {
                        return new DefaultItemStrategy();
                    }
            }
        }
    }
}
