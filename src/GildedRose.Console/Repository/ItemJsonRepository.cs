using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace GildedRose.Console.Repository
{
    public class ItemJsonRepository : IItemJsonRepository
    {
        private string jsonPath;

        public ItemJsonRepository()
        {
            jsonPath = @"C:\Workspace\itemsRepo.json";
            if (!File.Exists(jsonPath))
                File.WriteAllText(jsonPath, "[]");
        }

        public IEnumerable<Item> GetAll()
        {
            var items = JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(jsonPath));
            return items;
        }

        public void AddOrUpdate(Item inputItem)
        {
            var items = JsonConvert.DeserializeObject<List<Item>>(jsonPath);
            var currentItem = items.FirstOrDefault(x => x.Name == inputItem.Name);
            if (currentItem == null)
            {
                items.Add(new Item()
                {
                    Name = inputItem.Name,
                    Quality = inputItem.Quality,
                    SellIn = inputItem.SellIn
                });
                File.WriteAllText(jsonPath, JsonConvert.SerializeObject(items));
            }
            else if (currentItem.Quality != inputItem.Quality ||
                     currentItem.SellIn != inputItem.SellIn)
            {
                currentItem.Quality = inputItem.Quality;
                currentItem.SellIn = inputItem.SellIn;
                File.WriteAllText(jsonPath, JsonConvert.SerializeObject(items));
            }
        }

        public void AddOrUpdate(IEnumerable<Item> inputItems)
        {
            var items = JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(jsonPath));
            foreach (var inputItem in inputItems)
            {
                var currentItem = items.FirstOrDefault(x => x.Name == inputItem.Name);
                if (currentItem == null)
                {
                    items.Add(new Item()
                    {
                        Name = inputItem.Name,
                        Quality = inputItem.Quality,
                        SellIn = inputItem.SellIn
                    });
                }
                else if (currentItem.Quality != inputItem.Quality ||
                         currentItem.SellIn != inputItem.SellIn)
                {
                    currentItem.Quality = inputItem.Quality;
                    currentItem.SellIn = inputItem.SellIn;
                }
            }
            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(items));
        }
    }
}
