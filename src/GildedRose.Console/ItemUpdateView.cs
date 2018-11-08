using System;
using System.Data;
using System.Windows.Forms;

namespace GildedRose.Console
{
    public partial class ItemUpdateView : UserControl, IItemUpdateView
    {
        public ItemUpdateView()
        {
            InitializeComponent();
            ItemGridView.AutoGenerateColumns = true;
        }

        public event EventHandler ViewLoad;
        public event EventHandler ItemsUpdate;

        public object DataSource
        {
            get { return ItemGridView.DataSource; }
            set { ItemGridView.DataSource = value; }
        }

        private void ViewLoaded(object sender, EventArgs e)
        {
            ViewLoad?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            ItemsUpdate?.Invoke(this, EventArgs.Empty);
        }
    }
}
