using GildedRose.Console;

namespace GildedRose.Tests
{
    public class ItemBuilder
    {
        private Item item;
        public ItemBuilder()
        {
            item = new Item();
        }
        public ItemBuilder(string name)
        {
            item = new Item();
            item.Name = name;
        }

        public ItemBuilder WithName(string name)
        {
            item.Name = name;
            return this;
        }

        public ItemBuilder WithQuality(int quality)
        {
            item.Quality = quality;
            return this;
        }

        public ItemBuilder WithSellIn(int SellIn)
        {
            item.SellIn = SellIn;
            return this;
        }

        public Item Build()
        {
            return item;
        }
    }
}
