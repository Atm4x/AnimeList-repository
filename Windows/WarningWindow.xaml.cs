using System;
using System.Windows;

namespace AnimeList.Windows
{
    public partial class WarningWindow : Window
    {
        public bool ToRewrite = false;
        public WarningWindow()
        {
            InitializeComponent();
        }

        private void ViewMode(object sender, RoutedEventArgs e)
        {
            ToRewrite = false;
            this.Close();
        }

        private void OwnerMode(object sender, RoutedEventArgs e)
        {
            ToRewrite = true;
            this.Close();
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            ToRewrite = false;
        }
    }
}