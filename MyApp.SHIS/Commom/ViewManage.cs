using System.Windows;

namespace MyApp.SHIS.Commom
{
    public static class ViewManage
    {
        public static void ChangeView(Window sourceWindow, Window targetWindow)
        {
            targetWindow.Top = sourceWindow.Top;
            targetWindow.Left = sourceWindow.Left;
            targetWindow.Show();
            sourceWindow.Close();

        }
    }
}