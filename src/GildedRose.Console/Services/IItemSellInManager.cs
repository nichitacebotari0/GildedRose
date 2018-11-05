using System.Collections.Generic;

namespace GildedRose.Console
{
    public interface IItemSellInManager
    {
        void UpdateSellIn(IEnumerable<Item> items);
    }
}