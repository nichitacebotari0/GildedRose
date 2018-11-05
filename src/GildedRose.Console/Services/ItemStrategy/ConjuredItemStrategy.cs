using GildedRose.Console.Infrastructure;

namespace GildedRose.Console.Services.ItemStrategy
{
    public class ConjuredItemStrategy : IItemQualityStrategy
    {
        public void UpdateItemQuality(Item item)
        {
            if (item.SellIn > 0)
                item.Quality += -2;
            else
                item.Quality += -4;
            ItemConstraitns.LimitToMinMax(item);
        }
    }
}
