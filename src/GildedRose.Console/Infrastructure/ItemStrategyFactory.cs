using System;
using System.Collections.Generic;
using GildedRose.Console.Services.ItemStrategy;

namespace GildedRose.Console.Infrastructure
{
    public class ItemStrategyFactory : Dictionary<string, Func<IItemQualityStrategy>>, IItemStrategyFactory
    {
        public IItemQualityStrategy CreateNew(string itemName)
        {
            string itemType;
            switch (itemName)
            {
                case Constants.Sulfuras:
                    {
                        itemType = "Legendary";
                        break;
                    }
                case Constants.AgedBrie:
                    {
                        itemType = "Aged";
                        break;
                    }
                case Constants.ConjuredManaCake:
                    {
                        itemType = "Conjured";
                        break;
                    }
                case Constants.BackstagePass:
                    {
                        itemType = "Backstage";
                        break;
                    }
                default:
                    {
                        itemType = "Default";
                        break;
                    }
            }
            return this[itemType]();
        }
    }
}
