using MyApp.SHIS.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MyApp.SHIS.View.Windows;
using MyApp.SHIS.ViewModel.UserControlsViewModels;

namespace MyApp.SHIS.View
{
  /// <summary>
  /// Interaction logic for UserControlMenuItem.xaml
  /// </summary>
  public partial class UserControlMenuItem
  {
    DashBoardView _context;
    private ItemMenu _itemMenu;
    public UserControlMenuItem(ItemMenu itemMenu, DashBoardView context)
    {
      InitializeComponent();
      ListViewItemMenu.AddHandler(ListBoxItem.MouseLeftButtonDownEvent, new MouseButtonEventHandler(this.ListViewItemMenu_OnMouseLeftButtonDown), true);
      _context = context;
      
      ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
      ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

      this.DataContext = itemMenu;
      _itemMenu = itemMenu;
    }
    
    private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      _context.SwitchPages(((SubItem)((ListView)sender).SelectedItem).NewPage);
    }

    private void ListViewItemMenu_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      _context.SwitchPages(_itemMenu.NewPage);
    }
  }
}
