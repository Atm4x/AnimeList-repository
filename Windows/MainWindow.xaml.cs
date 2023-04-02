using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using AnimeList.Helpers;
using AnimeList.Models;
using AnimeList.Windows;

namespace AnimeList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(object param)
        {
            InitializeComponent();
            MessageBox.Show("тест");
        }
        private void ExitClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }

        private void LogInClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Login.Text))
            {
                MessageBox.Show("Не введён логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (String.IsNullOrWhiteSpace(Password.Password))
            {
                MessageBox.Show("Не введён пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (true)
            {
                //login
            }
            App.Login = Login.Text;
            App.Password = Password.Password;
            
            List<AnimeModel> a = new List<AnimeModel>();
            
            
            Window window = new Windows.ControlWindow();
            window.ShowDialog();
        }
    }
}