using GildedRose.Console.Repository;
using SimpleInjector;

namespace GildedRose.Console
{
    public static class DependencyBinder
    {
        public static Container Register()
        {
            var container = new Container();

            container.Register<IItemQualityService, ItemQualityService>();
            container.Register<IItemQualityManager, ItemQualityManager>();
            container.Register<IItemJsonRepository, ItemJsonRepository>();

            container.Verify();
            return container;
        }
    }
}
