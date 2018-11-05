using GildedRose.Console.Repository;

namespace GildedRose.Console
{
    public class ItemUpdateService : IItemUpdateService
    {
        private IItemJsonRepository itemJsonRepo;
        private IItemXmlRepository itemXmlRepo;
        private IItemQualityManager itemQualityManager;
        private IItemSellInManager itemSellInManager;
        public ItemUpdateService(IItemJsonRepository jsonRepo, IItemXmlRepository xmlRepo, IItemQualityManager qualityManager, IItemSellInManager sellInManager)
        {
            itemJsonRepo = jsonRepo;
            itemXmlRepo = xmlRepo;
            itemQualityManager = qualityManager;
            itemSellInManager = sellInManager;
        }

        public void UpdateItems()
        {
            var items = itemJsonRepo.GetAll();
            itemSellInManager.UpdateSellIn(items);
            itemQualityManager.UpdateQuality(items);
            itemJsonRepo.AddOrUpdate(items);


            items = itemXmlRepo.GetAll();
            itemQualityManager.UpdateQuality(items);
            itemXmlRepo.AddOrUpdate(items);
        }
    }
}
