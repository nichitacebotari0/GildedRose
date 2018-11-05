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
                        itemType = Constants.ItemType_Legendary;
                        break;
                    }
                case Constants.AgedBrie:
                    {
                        itemType = Constants.ItemType_Aged;
                        break;
                    }
                case Constants.ConjuredManaCake:
                    {
                        itemType = Constants.ItemType_Conjured;
                        break;
                    }
                case Constants.BackstagePass:
                    {
                        itemType = Constants.ItemType_Backstage;
                        break;
                    }
                default:
                    {
                        itemType = Constants.ItemType_Default;
                        break;
                    }
            }
            return this[itemType]();
        }
    }
}
