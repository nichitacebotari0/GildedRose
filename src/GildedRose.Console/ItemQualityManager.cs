using System.Collections.Generic;

namespace GildedRose.Console
{
    static class ItemQualityManager
    {

        public static void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
            {
                var sellInVelocity = GetSellInVelocity(item.Name);
                item.SellIn += sellInVelocity;

                var qualityVelocity = GetQualityVelocity(item);
                if (item.Quality > Constants.MinQuality && item.Quality < Constants.MaxQuality)
                {
                    item.Quality += qualityVelocity;
                    if (item.Quality > Constants.MaxQuality)
                    {
                        item.Quality = Constants.MaxQuality;
                    }
                    if (item.Quality < Constants.MinQuality)
                    {
                        item.Quality = Constants.MinQuality;
                    }
                }
            }
        }

        private static int GetSellInVelocity(string itemName)
        {
            switch (itemName)
            {
                case Constants.Sulfuras:
                    {
                        return 0;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }

        private static int GetQualityVelocity(Item item)
        {
            switch (item.Name)
            {
                case Constants.Sulfuras:
                    {
                        return 0;
                    }
                case Constants.AgedBrie:
                    {
                        return 1;
                    }
                case Constants.ConjuredManaCake:
                    {
                        return -2;
                    }
                case Constants.BackstagePass:
                    {
                        if (item.SellIn < 0)
                        {
                            return -item.Quality;
                        }
                        if (item.SellIn <= 5)
                        {
                            return 3;
                        }
                        if (item.SellIn <= 10)
                        {
                            return +2;
                        }
                        return +1;
                    }
                default:
                    {
                        if (item.SellIn < 0)
                        {
                            return -2;
                        }
                        return -1;
                    }
            }
        }
    }
}
