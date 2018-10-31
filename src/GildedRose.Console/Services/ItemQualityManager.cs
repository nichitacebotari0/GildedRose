using System.Collections.Generic;

namespace GildedRose.Console
{
    public class ItemQualityManager : IItemQualityManager
    {
        public void UpdateQuality(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                var sellInVelocity = GetSellInVelocity(item.Name);
                item.SellIn += sellInVelocity;

                var qualityVelocity = GetQualityVelocity(item);
                if (item.Quality >= Constants.MinQuality && item.Quality <= Constants.MaxQuality)
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

        private int GetSellInVelocity(string itemName)
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

        private int GetQualityVelocity(Item item)
        {
            int velocity;
            switch (item.Name)
            {
                case Constants.Sulfuras:
                    {
                        velocity = 0;
                        break;
                    }
                case Constants.AgedBrie:
                    {
                        velocity = 1;
                        break;
                    }
                case Constants.ConjuredManaCake:
                    {
                        velocity = -2;
                        break;
                    }
                case Constants.BackstagePass:
                    {
                        if (item.SellIn < 0)
                            velocity = -item.Quality;
                        else if (item.SellIn <= 5)
                            velocity = 3;
                        else if (item.SellIn <= 10)
                            velocity = +2;
                        else
                            velocity = +1;
                        break;
                    }
                default:
                    {
                        velocity = -1;
                        break;
                    }
            }
            if (item.SellIn < 0 && velocity < 0)
            {
                velocity *= 2;
            }
            return velocity;
        }
    }
}
