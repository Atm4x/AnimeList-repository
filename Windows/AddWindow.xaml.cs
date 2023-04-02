using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using AnimeList.Models;

namespace AnimeList.Windows
{
    public partial class AddWindow : Window
    {
        public bool IsActive = false;
        public AddWindow()
        {
            InitializeComponent();
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
                MessageBox.Show("Не введено название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }

            if (String.IsNullOrWhiteSpace(Place.Text))
            {
                MessageBox.Show("Не введено место", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }

            var found = list.GetModels().FirstOrDefault(x => x.Name == Name.Text);
            if (found != null)
            {
                MessageBox.Show($"Введёное название уже присутствует в строке {found.Place}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Hand);
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