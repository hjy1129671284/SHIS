using System.Collections.Generic;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;

namespace MyApp.SHIS.ViewModel.UserControlsViewModels
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
    
    public class SubItem
        {
            public SubItem(string name, Page newPage = null, PackIconKind icon = default)
            {
                Name = name;
                NewPage = newPage;
                Icon = icon;
            }
            public string Name { get; private set; }
            public Page NewPage { get; private set; }
            public PackIconKind Icon { get; private set; }
        }
}
