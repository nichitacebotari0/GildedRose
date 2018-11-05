using GildedRose.Console.Infrastructure;

namespace GildedRose.Console.Services.ItemStrategy
{
    public class AgedBrieStrategy : IItemQualityStrategy
    {
        public void UpdateItemQuality(Item item)
        {
            item.Quality += 1;
            ItemConstraitns.LimitToMinMax(item);
        }
    }
}
