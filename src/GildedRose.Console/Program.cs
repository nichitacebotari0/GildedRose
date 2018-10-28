using System.Collections.Generic;

namespace GildedRose.Console
{
    static class Program
    {
        static IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");


            Items = new List<Item>
            {
                new Item {Name = Constants.DexVestPlus5, SellIn = 10, Quality = 20},
                new Item {Name = Constants.AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = Constants.MongooseElixir, SellIn = 5, Quality = 7},
                new Item {Name = Constants.Sulfuras, SellIn = 0, Quality = 80},
                new Item {Name = Constants.BackstagePass, SellIn = 15, Quality = 20},
                new Item {Name = Constants.ConjuredManaCake, SellIn = 3, Quality = 6}
            };

            ItemQualityManager.UpdateQuality(Items);

            System.Console.ReadKey();

        }


    }



}
