using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AnimeList.Models;
using AnimeList.Services;
using LanguageClassTest.Models;

namespace AnimeList.Windows
{
    public partial class AddWindow : Window
    {
        public bool IsActive = false;
        private LanguageModel.AddWindowDialogMessages translates = null;

        public AddWindow()
        {
            InitializeComponent();
            UIChangeLanguage(App.CurrentLanguage);
        }

        public void UIChangeLanguage(LanguageModel lang)
        {
            Title = lang.AddWindowTitle.Value;
            translates = lang.AddWindowDialogTranslate;
            foreach (var translations in lang.Translate)
            {
                var buttonBlock = UIFinder.FindVisualChildren<System.Windows.Controls.Button>(WholePageGrid).FirstOrDefault(x => x.Name == translations.Name);
                if (buttonBlock != null)
                {
                    buttonBlock.Content = translations.Value;
                    continue;
                }

                var textBlock = UIFinder.FindVisualChildren<TextBlock>(WholePageGrid).FirstOrDefault(x => x.Name == translations.Name);
                if (textBlock != null)
                {
                    textBlock.Text = translations.Value;
                    continue;
                }
            }
        }

        public void Show()
        {
            IsActive = true;
            base.Show();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Models.AnimeList list = App.list.GetActive().model.ListConnected;
            if (String.IsNullOrWhiteSpace(Name.Text))
            {
                MessageBox.Show(translates.InputNameMessage, translates.ErrorMessage, MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }

            if (String.IsNullOrWhiteSpace(Place.Text))
            {
                MessageBox.Show(translates.InputPlaceMessage, translates.ErrorMessage, MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }

            var found = list.GetModels().FirstOrDefault(x => x.Name == Name.Text);
            if (found != null)
            {
                MessageBox.Show(translates.InputExistsMessage + found.Place, translates.ErrorMessage, MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }
            
            if (int.TryParse(Place.Text, out int place))
            {
                if (place >= list.GetModels().Count)
                {
                    if (list.GetModels().Count > 1) 
                        list.AddModel(new AnimeModel(list.GetModels().Last().Place+1, Name.Text));
                    else list.AddModel(new AnimeModel(1, Name.Text));
                }
                else
                {
                    if (place <= 0)
                    {
                        list.AddModel(new AnimeModel(1, Name.Text));
                    }
                    else
                    {
                        list.AddModel(new AnimeModel(place, Name.Text));
                    }
                }
            }
            list.SaveChanges();
            IsActive = false;
            this.Close();
            
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            IsActive = false;
        }
    }
}