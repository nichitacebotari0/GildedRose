using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace GildedRose.Console.Repository
{
    public class ItemJsonRepository : ItemRepositoryBase, IItemJsonRepository
    {
        private string jsonPath;

        public ItemJsonRepository(string path)
        {
            jsonPath = path;
            if (!File.Exists(jsonPath))
                File.WriteAllText(jsonPath, "[]");
        }

        public IEnumerable<Item> GetAll()
        {
            var items = JsonConvert.DeserializeObject<IEnumerable<Item>>(File.ReadAllText(jsonPath));
            return items;
        }

        public void AddOrUpdate(Item inputItem)
        {
            var items = JsonConvert.DeserializeObject<List<Item>>(jsonPath);
            if (ShouldAddOrUpdate(inputItem, items))
            {
                File.WriteAllText(jsonPath, JsonConvert.SerializeObject(items));
            }
        }

        public void AddOrUpdate(IEnumerable<Item> inputItems)
        {
            var items = JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(jsonPath));
            if (ShouldAddOrUpdate(inputItems, items))
            {
                File.WriteAllText(jsonPath, JsonConvert.SerializeObject(items));
            }
        }
    }
}
