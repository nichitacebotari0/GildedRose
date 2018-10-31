using System.Collections.Generic;

namespace GildedRose.Console.Repository
{
    public interface IItemJsonRepository
    {
        IEnumerable<Item> GetAll();
        void AddOrUpdate(Item item);
        void AddOrUpdate(IEnumerable<Item> inputItems);
    }
}
