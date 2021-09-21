using System.Windows.Controls;
using MaterialDesignThemes.Wpf;

namespace MyApp.SHIS.ViewModel
{
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