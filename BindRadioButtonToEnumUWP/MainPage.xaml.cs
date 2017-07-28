using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using BindRadioButtonToEnumUWP.Annotations;

namespace BindRadioButtonToEnumUWP
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private ElementTheme _elementTheme = ElementTheme.Light;
        public ElementTheme ElementTheme
        {
            get => _elementTheme;
            set
            {
                if (_elementTheme != value)
                {
                    _elementTheme = value;
                    OnPropertyChanged();
                }
            }
        }

        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
