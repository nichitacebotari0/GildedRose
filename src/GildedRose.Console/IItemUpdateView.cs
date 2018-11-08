using System;

namespace GildedRose.Console
{
    public interface IItemUpdateView
    {
        event EventHandler ItemsUpdate;
        event EventHandler ViewLoad;

        object DataSource { get; set; }
    }
}