using System;
using System.Windows;

namespace MyApp.SHIS.Commom
{
    public class ViewManage
    {
        public static void ChangeView(Window sourceWindow, Window targetWindow)
        {
            targetWindow.Top = sourceWindow.Top;
            targetWindow.Left = sourceWindow.Left;
            targetWindow.ShowDialog();
            sourceWindow.Close();

        }
    }
}