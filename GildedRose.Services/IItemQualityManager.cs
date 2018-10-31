using System.Collections.Generic;

namespace GildedRose.Console
{
    public interface IItemQualityManager
    {
        void UpdateQuality(IList<Item> items);
    }
}