namespace GildedRose.Console.Infrastructure
{
    public static class ItemQualityRules
    {
        public static void ApplyMinMaxRule(Item item)
        {
            if (item.Quality > Constants.MaxQuality)
            {
                item.Quality = Constants.MaxQuality;
            }
            if (item.Quality < Constants.MinQuality)
            {
                item.Quality = Constants.MinQuality;
            }
        }
    }
}
