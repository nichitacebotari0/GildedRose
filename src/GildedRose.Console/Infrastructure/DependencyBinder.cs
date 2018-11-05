using GildedRose.Console.Infrastructure;
using GildedRose.Console.Repository;
using GildedRose.Console.Services.ItemStrategy;
using SimpleInjector;

namespace GildedRose.Console
{
    public static class DependencyBinder
    {
        public static Container Register(string path)
        {
            var container = new Container();

            container.Register<IItemUpdateService, ItemUpdateService>();
            container.Register<IItemSellInManager, ItemSellInManager>();
            container.Register<IItemQualityManager, ItemQualityManager>();
            container.Register<IItemJsonRepository>(() => new ItemJsonRepository($"{path}.json"));
            container.Register<IItemXmlRepository>(() => new ItemXmlRepository($"{path}.xml"));
            container.Register<IItemStrategyFactory>(() => new ItemStrategyFactory()
            {
                { Constants.ItemType_Aged, () => container.GetInstance<AgedBrieStrategy>()},
                { Constants.ItemType_Backstage, () => container.GetInstance<BackstagePassStrategy>()},
                { Constants.ItemType_Conjured, () => container.GetInstance<ConjuredItemStrategy>()},
                { Constants.ItemType_Legendary, () => container.GetInstance<SulfurasStrategy>()},
                { Constants.ItemType_Default, () => container.GetInstance<DefaultItemStrategy>()}
            });
            container.Verify();
            return container;
        }
    }
}
