using System;
using System.Collections.Generic;

namespace GildedRose.Console.Repository
{
    public class ItemXMLRepository : IItemXMLRepository
    {
        private string XMLPath;
        public ItemXMLRepository(string path)
        {
            XMLPath = path;
        }
        public IEnumerable<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdate(Item item)
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdate(IEnumerable<Item> inputItems)
        {
            throw new NotImplementedException();
        }
    }
}
