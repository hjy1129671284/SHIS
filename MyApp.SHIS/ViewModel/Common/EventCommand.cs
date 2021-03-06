using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace MyApp.SHIS.ViewModel.Common
{
    public class EventCommand : TriggerAction<DependencyObject>
    {
        
        /// <summary>
        /// 事件命令
        /// </summary>
        protected override void Invoke(object parameter)
        {
            if (CommandParameter != null)
            {
                parameter = CommandParameter;
            }
            if (Command != null)
            {
                Command.Execute(parameter);
            }
        }
        
        /// <summary>
        /// 事件
        /// </summary>
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(EventCommand), new PropertyMetadata(null));
        
        
        /// <summary>
        /// 事件参数，如果为空，将自动传入事件的真实参数
        /// </summary>
        public object CommandParameter
        {
            get => (object)GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(EventCommand), new PropertyMetadata(null));
        
    }
}