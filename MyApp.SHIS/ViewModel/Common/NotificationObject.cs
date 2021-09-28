using System.ComponentModel;
using System.Runtime.CompilerServices;
using MyApp.SHIS.Annotations;

namespace MyApp.SHIS.ViewModel.Common
{
    public class NotificationObject : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}