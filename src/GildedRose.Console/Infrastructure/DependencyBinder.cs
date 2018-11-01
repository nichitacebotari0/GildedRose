using GildedRose.Console.Repository;
using SimpleInjector;

namespace GildedRose.Console
{
    public static class DependencyBinder
    {
        public static Container Register(string path)
        {
            var container = new Container();

            container.Register<IItemQualityService, ItemQualityService>();
            container.Register<IItemQualityManager, ItemQualityManager>();
            container.Register<IItemJsonRepository>(() => new ItemJsonRepository($"{path}.json"));
            container.Register<IItemXmlRepository>(() => new ItemXmlRepository($"{path}.xls"));

            container.Verify();
            return container;
        }
    }
}
