using System.Collections.Generic;
using System.Windows.Forms;
using GildedRose.Console.Repository;
using SimpleInjector;

namespace GildedRose.Console
{
    static class Program
    {
        static IList<Item> Items;

        static void Main(string[] args)
        {
            args = new string[] { @"C:\Workspace\itemsRepo" };
            Container dependencyContainer = DependencyBinder.Register(args[0]);
            IItemJsonRepository jsonRepo = dependencyContainer.GetInstance<IItemJsonRepository>();
            IItemXmlRepository xmlRepo = dependencyContainer.GetInstance<IItemXmlRepository>();
            IItemUpdateService itemUpdateService = dependencyContainer.GetInstance<IItemUpdateService>();

            System.Console.WriteLine("OMGHAI!");

            Items = new List<Item>()
            {
                new Item {Name = Constants.DexVestPlus5, SellIn = 10, Quality = 20},
                new Item {Name = Constants.AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = Constants.MongooseElixir, SellIn = 5, Quality = 7},
                new Item {Name = Constants.Sulfuras, SellIn = 0, Quality = 80},
                new Item {Name = Constants.BackstagePass, SellIn = 15, Quality = 20},
                new Item {Name = Constants.ConjuredManaCake, SellIn = 3, Quality = 6}
            };

            jsonRepo.AddOrUpdate(Items);
            xmlRepo.AddOrUpdate(Items);
            itemUpdateService.UpdateItems();


            //System.Console.ReadKey();

            var mainForm = new GildedRoseForm();
            var itemUpdatePresenter = new ItemUpdatePresenter(mainForm.ItemView ,jsonRepo, itemUpdateService);
            
            Application.Run(mainForm);
        }
    }
}
