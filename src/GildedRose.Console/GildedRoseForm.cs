using System.Windows.Forms;

namespace GildedRose.Console
{
    public partial class GildedRoseForm : Form
    {
        private readonly ItemUpdateView itemView;

        public GildedRoseForm()
        {
            InitializeComponent();

            itemView = new ItemUpdateView() { Dock = DockStyle.Fill };
            this.Controls.Add(itemView);
        }

        public IItemUpdateView ItemView { get { return itemView; } }

    }
}
