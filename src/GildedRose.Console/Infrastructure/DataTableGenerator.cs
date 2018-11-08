using System.Collections.Generic;
using System.Data;

namespace GildedRose.Console.Infrastructure
{
    public static class DataTableGenerator
    {
        public static DataTable GenerateItemTable(IEnumerable<Item> items)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Quality", typeof(int));
            dataTable.Columns.Add("Sell In", typeof(int));

            foreach (var item in items)
            {
                var values = new object[3];
                values[0] = item.Name;
                values[1] = item.Quality;
                values[2] = item.SellIn;
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }
}
