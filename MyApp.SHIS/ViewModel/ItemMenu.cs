using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MyApp.SHIS.ViewModel
{
    public class ItemMenu
    {
        public ItemMenu(string header, List<SubItem> subItems, PackIconKind icon)
        {
            Header = header;
            SubItems = subItems;
            Icon = icon;
        }

        public ItemMenu(string header, Page newPage, PackIconKind icon)
        {
            Header = header;
            NewPage = newPage;
            Icon = icon;
        }

        public string Header { get; private set; }
        public PackIconKind Icon { get; private set; }
        public List<SubItem> SubItems { get; private set; }
        public Page NewPage { get; private set; }
    }
}
