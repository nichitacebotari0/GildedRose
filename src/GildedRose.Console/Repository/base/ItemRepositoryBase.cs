using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console.Repository
{
    public abstract class ItemRepositoryBase
    {
        protected bool ShouldAddOrUpdate(Item inputItem, List<Item> contextItems)
        {
            bool updated = false;
            var currentItem = contextItems.FirstOrDefault(x => x.Name == inputItem.Name);
            if (currentItem == null)
            {
                contextItems.Add(new Item()
                {
                    Name = inputItem.Name,
                    Quality = inputItem.Quality,
                    SellIn = inputItem.SellIn
                });
                updated = true;
            }
            else if (currentItem.Quality != inputItem.Quality ||
                     currentItem.SellIn != inputItem.SellIn)
            {
                currentItem.Quality = inputItem.Quality;
                currentItem.SellIn = inputItem.SellIn;
                updated = true;
            }
            return updated;
        }

        protected bool ShouldAddOrUpdate(IEnumerable<Item> inputItems, List<Item> contextItems)
        {
            bool updated = false;
            foreach (var inputItem in inputItems)
            {
                if (ShouldAddOrUpdate(inputItem, contextItems))
                {
                    updated = true;
                }
            }
            return updated;
        }
    }
}