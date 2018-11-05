using GildedRose.Console.Infrastructure;

namespace GildedRose.Console.Services.ItemStrategy
{
    class AgedBrieStrategy : IItemQualityStrategy
    {
        public void UpdateItemQuality(Item item)
        {
            item.Quality +=1;
            ItemQualityRules.ApplyMinMaxRule(item);
        }
    }
}
