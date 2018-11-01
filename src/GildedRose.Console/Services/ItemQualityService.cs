using GildedRose.Console.Repository;

namespace GildedRose.Console
{
    public class ItemQualityService : IItemQualityService
    {
        private IItemJsonRepository itemJsonRepo;
        private IItemXmlRepository itemXmlRepo;
        private IItemQualityManager itemQualityManager;
        public ItemQualityService(IItemJsonRepository jsonRepo, IItemXmlRepository xmlRepo, IItemQualityManager qualityManager)
        {
            itemJsonRepo = jsonRepo;
            itemXmlRepo = xmlRepo;
            itemQualityManager = qualityManager;
        }

        public void UpdateQuality()
        {
            var items = itemJsonRepo.GetAll();
            itemQualityManager.UpdateQuality(items);
            itemJsonRepo.AddOrUpdate(items);


            items = itemXmlRepo.GetAll();
            itemQualityManager.UpdateQuality(items);
            itemXmlRepo.AddOrUpdate(items);
        }
    }
}
