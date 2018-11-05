using GildedRose.Console.Infrastructure;

namespace GildedRose.Console.Services.ItemStrategy
{
    public class DefaultItemStrategy : IItemQualityStrategy
    {
        public void UpdateItemQuality(Item item)
        {
            if (item.SellIn > 0)
                item.Quality += -1;
            else
                item.Quality += -2;
            ItemConstraitns.ResetMinMax(item);
        }
    }
}
