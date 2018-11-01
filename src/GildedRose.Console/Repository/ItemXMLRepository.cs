using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GildedRose.Console.Repository
{
    public class ItemXmlRepository : ItemRepositoryBase, IItemXmlRepository
    {
        private string XMLPath;
        public ItemXmlRepository(string path)
        {
            XMLPath = path;
            if (!File.Exists(XMLPath))
            {
                var itemSerializer = new XmlSerializer(typeof(List<Item>));
                using (var writer = new StreamWriter(XMLPath))
                {
                    itemSerializer.Serialize(writer, new List<Item>());
                }
            }
        }
        public IEnumerable<Item> GetAll()
        {
            var itemSerializer = new XmlSerializer(typeof(List<Item>));
            XElement content = XElement.Load(XMLPath);
            var items = (List<Item>)itemSerializer.Deserialize(content.CreateReader());
            return items;
        }

        public void AddOrUpdate(Item inputItem)
        {
            var itemSerializer = new XmlSerializer(typeof(List<Item>));
            XElement content = XElement.Load(XMLPath);
            var items = (List<Item>)itemSerializer.Deserialize(content.CreateReader());
            if (ShouldAddOrUpdate(inputItem, items))
            {
                using (var writer = new StreamWriter(XMLPath))
                {
                    itemSerializer.Serialize(writer, items);
                }
            }
        }

        public void AddOrUpdate(IEnumerable<Item> inputItems)
        {
            var itemSerializer = new XmlSerializer(typeof(List<Item>));
            XElement content = XElement.Load(XMLPath);
            var items = (List<Item>)itemSerializer.Deserialize(content.CreateReader());
            if (ShouldAddOrUpdate(inputItems, items))
            {
                using (var writer = new StreamWriter(XMLPath))
                {
                    itemSerializer.Serialize(writer, items);
                }
            }
        }
    }
}
