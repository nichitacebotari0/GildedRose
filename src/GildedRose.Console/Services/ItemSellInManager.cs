using System.Collections.Generic;

namespace GildedRose.Console
{
    public class ItemSellInManager : IItemSellInManager
    {
        public void UpdateSellIn(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                var sellInVelocity = GetSellInVelocity(item.Name);
                item.SellIn += sellInVelocity;
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
    }
}
