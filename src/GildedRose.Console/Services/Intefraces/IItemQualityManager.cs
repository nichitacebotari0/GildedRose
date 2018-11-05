using System.Collections.Generic;

namespace GildedRose.Console
{
    public interface IItemQualityManager
    {
        void UpdateQuality(IEnumerable<Item> items);
    }
}