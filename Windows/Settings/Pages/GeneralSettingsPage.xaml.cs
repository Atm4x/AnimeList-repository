﻿using AnimeList.Helpers;
using AnimeList.Models;
using AnimeList.Services;
using LanguageClassTest.Models;
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
            CurrentFontSelectionBox.ItemsSource = Fonts.SystemFontFamilies.OrderBy(x => x.Source).ToList();
            TvBox.SelectedItem = TvBox.ItemsSource.OfType<SchemeView>().FirstOrDefault(x => x.Id == App.CurrentThemeId);
            UIChangeLanguage(App.CurrentLanguage);
        }

        public void UIChangeLanguage(LanguageModel lang)
        {
            foreach (var translations in lang.Translate)
            {
                var buttonBlock = UIFinder.FindVisualChildren<System.Windows.Controls.Button>(WholeGrid).FirstOrDefault(x => x.Name == translations.Name);
                if (buttonBlock != null)
                {
                    buttonBlock.Content = translations.Value;
                    continue;
                }

                var textBlock = UIFinder.FindVisualChildren<TextBlock>(WholeGrid).FirstOrDefault(x => x.Name == translations.Name);
                if (textBlock != null)
                {
                    textBlock.Text = translations.Value;
                    continue;
                }
            }
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

        private void FontChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = CurrentFontSelectionBox.SelectedItem as FontFamily;
            this.Resources["DynamicFontFamily"] = new FontFamily(selected.Source);
        }
    }
}
