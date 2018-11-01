using System.Collections.Generic;

namespace GildedRose.Console.Repository
{
    public interface IItemXmlRepository
    {
        void AddOrUpdate(IEnumerable<Item> inputItems);
        void AddOrUpdate(Item item);
        IEnumerable<Item> GetAll();
    }
}