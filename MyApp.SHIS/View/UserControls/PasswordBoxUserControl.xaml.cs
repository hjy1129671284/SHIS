using System.Windows;
using System.Windows.Controls;

namespace MyApp.SHIS.View.UserControls
{
    public partial class PasswordBoxUserControl : UserControl
    {
        public PasswordBoxUserControl()
        {
            InitializeComponent();
        }
 
        /// <summary>
        /// 控制TextBox显示或者隐藏----TextBox来显示明文
        /// </summary>
        public Visibility TbVisibility
        {
            get => (Visibility)GetValue(TbVisibilityProperty);
            set => SetValue(TbVisibilityProperty, value);
        }
 
        // Using a DependencyProperty as the backing store for TbVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TbVisibilityProperty =
            DependencyProperty.Register("TbVisibility", typeof(Visibility), typeof(PasswordBoxUserControl));
 
        /// <summary>
        /// 控制PassworBox显示或者隐藏----PasswordBox控件来显密文
        /// </summary>
        public Visibility PwVisibility
        {
            get => (Visibility)GetValue(PwVisibilityProperty);
            set => SetValue(PwVisibilityProperty, value);
        }
 
        // Using a DependencyProperty as the backing store for PwVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PwVisibilityProperty =
            DependencyProperty.Register("PwVisibility", typeof(Visibility), typeof(PasswordBoxUserControl));
 
        /// <summary>
        /// 和“眼睛”进行绑定
        /// </summary>
        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }
 
        // Using a DependencyProperty as the backing store for Check.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(PasswordBoxUserControl), new PropertyMetadata((s, e) =>
            {
                var dp = s as PasswordBoxUserControl;
                if ((bool)e.NewValue)
                {
                    dp.TbVisibility = Visibility.Visible;
                    dp.PwVisibility = Visibility.Collapsed;
                }
                else
                {
                    dp.TbVisibility = Visibility.Collapsed;
                    dp.PwVisibility = Visibility.Visible;
                }
            }));
 
        /// <summary>
        /// 点击图标“x”,使密码框清空
        /// </summary>
        public bool IsCleared
        {
            get => (bool)GetValue(IsClearedProperty);
            set => SetValue(IsClearedProperty, value);
        }
        public static readonly DependencyProperty IsClearedProperty =
            DependencyProperty.Register("IsCleared", typeof(bool), typeof(PasswordBoxUserControl), new PropertyMetadata((s, e) =>
            {
                var c = s as PasswordBoxUserControl;
                c.Password = "";
            }));
 
        /// <summary>
        /// 控制显示符号“x”
        /// </summary>
        public Visibility ClearVisibility
        {
            get => (Visibility)GetValue(ClearVisibilityProperty);
            set => SetValue(ClearVisibilityProperty, value);
        }
        public static readonly DependencyProperty ClearVisibilityProperty =
            DependencyProperty.Register("ClearVisibility", typeof(Visibility), typeof(PasswordBoxUserControl), new PropertyMetadata(Visibility.Collapsed));
 
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get => (string)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }
 
        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(PasswordBoxUserControl), new PropertyMetadata((s, e) =>
            {
                var pw = s as PasswordBoxUserControl;
                pw.ClearVisibility = !string.IsNullOrEmpty(pw.Password) ? Visibility.Visible : Visibility.Collapsed;
            }));
    }
}