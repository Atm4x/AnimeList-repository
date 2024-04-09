using AnimeList.Helpers;
using AnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimeList.Windows.Settings.Pages
{
    /// <summary>
    /// Логика взаимодействия для GeneralSettingsPage.xaml
    /// </summary>
    public partial class GeneralSettingsPage : Page
    {
        public List<SchemeView> ThemesToChoose;
        public GeneralSettingsPage()
        {
            InitializeComponent();
            ThemesToChoose = new List<SchemeView>();
            foreach (var theme in ColorSchemeModel.Themes)
            {
                ThemesToChoose.Add(new SchemeView(theme.ID, theme.Title, theme.SchemeBackground));
            }
            this.TvBox.ItemsSource = ThemesToChoose;
            TvBox.SelectedItem = TvBox.ItemsSource.OfType<SchemeView>().FirstOrDefault(x => x.Id == App.CurrentThemeId);
        }

        public class SchemeView
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public SolidColorBrush SchemeBackground { get; set; }

            public SchemeView(int id, string title, SolidColorBrush brush)
            {
                Id = id;
                Title = title;
                SchemeBackground = brush;
            }
        }

        private void SaveClicked(object sender, RoutedEventArgs e)
        {
            var selectedTheme = (SchemeView)TvBox.SelectedItem;
            if (App.CurrentThemeId != selectedTheme.Id)
            {
                ColorSchemeModel.ThemeChanged += ThemeChangeFinished;
                App.CurrentThemeId = selectedTheme.Id; 
                ColorSchemeModel.ChangeTheme(selectedTheme.Id);
                App.Configuration.ThemeId = selectedTheme.Id;
                ConfigCipher.WriteConfigCipher();
            }
        }

        private void ThemeChangeFinished()
        {
            App.controlWindow.AnimeList.ItemsSource = App.list.GetActive().model.ListConnected.GetModels();
            ColorSchemeModel.ThemeChanged -= ThemeChangeFinished;
        }
    }
}
