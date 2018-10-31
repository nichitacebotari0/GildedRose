using GildedRose.Console.Repository;

namespace GildedRose.Console
{
    public class ItemQualityService : IItemQualityService
    {
        private IItemJsonRepository itemJsonRepo;
        private IItemQualityManager itemQualityManager;
        public ItemQualityService(IItemJsonRepository jsonRepo, IItemQualityManager qualityManager)
        {
            itemJsonRepo = jsonRepo;
            itemQualityManager = qualityManager;
        }

        public void UpdateQuality()
        {
            var items = itemJsonRepo.GetAll();
            itemQualityManager.UpdateQuality(items);
            itemJsonRepo.AddOrUpdate(items);
        }
    }
}
