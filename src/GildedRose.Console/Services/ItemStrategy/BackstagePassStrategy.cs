using GildedRose.Console.Infrastructure;

namespace GildedRose.Console.Services.ItemStrategy
{
    public class BackstagePassStrategy : IItemQualityStrategy
    {
        public void UpdateItemQuality(Item item)
        {
            if (item.SellIn < 0)
                item.Quality = 0;
            else if (item.SellIn <= 5)
                item.Quality += 3;
            else if (item.SellIn <= 10)
                item.Quality += 2;
            else
                item.Quality += 1;
            ItemConstraitns.LimitToMinMax(item);
        }
    }
}
