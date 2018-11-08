using System;
using System.Windows.Forms;
using GildedRose.Console.Infrastructure;
using GildedRose.Console.Repository;

namespace GildedRose.Console
{
    public class ItemUpdatePresenter
    {
        private readonly IItemUpdateView view;
        private readonly IItemJsonRepository repo;
        private readonly IItemUpdateService updateService;
        public ItemUpdatePresenter(IItemUpdateView itemView,
            IItemJsonRepository itemRepo,
            IItemUpdateService itemUpdate)
        {
            repo = itemRepo;
            updateService = itemUpdate;

            view = itemView;
            view.ViewLoad += OnViewLoad;
            view.ItemsUpdate += Updateitems;
        }

        private void Updateitems(object sender, EventArgs e)
        {
            updateService.UpdateItems();
            OnViewLoad(sender,e);
        }

        private void OnViewLoad(object sender, EventArgs e)
        {
            var items = DataTableGenerator.GenerateItemTable(repo.GetAll());
            var binding = new BindingSource();
            binding.DataSource = items;
            view.DataSource = binding;
        }
    }
}
