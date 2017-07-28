using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using BindRadioButtonToEnumUWP.Annotations;

namespace BindRadioButtonToEnumUWP
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        #region RadioButton Implementation

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

        #endregion

        #region ListBox Implementation

        public MainPage()
        {
            InitializeComponent();

            SelectedCustomTheme = CustomThemes[1];
            SelectedTheme = Themes[1];
        }

        public List<ThemeModel> CustomThemes { get; } =
            typeof(CustomTheme).GetValues<CustomTheme>().Select(t => new ThemeModel(t)).ToList();

        public List<ElementTheme> Themes { get; } =
            typeof(ElementTheme).GetValues<ElementTheme>().ToList();

        private ThemeModel _selectedCustomTheme;
        public ThemeModel SelectedCustomTheme
        {
            get => _selectedCustomTheme;
            set
            {
                if (_selectedCustomTheme != value)
                {
                    _selectedCustomTheme = value;
                    OnPropertyChanged();
                }
            }
        }

        private ElementTheme _selectedTheme;
        public ElementTheme SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                if (_selectedTheme != value)
                {
                    _selectedTheme = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public enum CustomTheme
    {
        [Display(Name = "High Contrast")]
        HighContrast,
        Light,
        Dark,
        Default
    }

    public class ThemeModel
    {
        public ThemeModel(CustomTheme appTheme)
        {
            AppTheme = appTheme;
        }

        public CustomTheme AppTheme { get; set; }
        public string DisplayName => AppTheme.GetDisplayName();
    }
}
