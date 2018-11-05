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
                { "Aged", () => container.GetInstance<AgedBrieStrategy>()},
                { "Backstage", () => container.GetInstance<BackstagePassStrategy>()},
                { "Conjured", () => container.GetInstance<ConjuredItemStrategy>()},
                { "Legendary", () => container.GetInstance<SulfurasStrategy>()},
                { "Default", () => container.GetInstance<DefaultItemStrategy>()}
            });
            container.Verify();
            return container;
        }
    }
}
