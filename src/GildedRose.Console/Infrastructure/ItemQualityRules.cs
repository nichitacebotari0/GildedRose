namespace GildedRose.Console.Infrastructure
{
    public static class ItemConstraitns
    {
        public static void LimitToMinMax(Item item)
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
