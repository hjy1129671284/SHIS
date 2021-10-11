using System.Collections.Generic;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;

namespace MyApp.SHIS.ViewModel.UserControlsViewModels.UserControlMenuItem
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

        public string Header { get; set; }
        public PackIconKind Icon { get; set; }
        public List<SubItem> SubItems { get; set; }
        public Page NewPage { get; set; }
    }
    
    public class SubItem
        {
            public SubItem(string name, Page newPage = null, PackIconKind icon = default)
            {
                Name = name;
                NewPage = newPage;
                Icon = icon;
            }
            public string Name { get; set; }
            public Page NewPage { get; set; }
            public PackIconKind Icon { get; set; }
        }
}
