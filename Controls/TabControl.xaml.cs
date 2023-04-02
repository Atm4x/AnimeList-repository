using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using AnimeList.Models;
using Path = System.Windows.Shapes.Path;

namespace AnimeList.Controls
{
    public partial class TabControl : Grid
    {
        public class TabModel
        {
            public Models.AnimeList ListConnected;
        }
        
        public TabModel model;
        
        public delegate void TabActivated(TabEventArgs tab);

        public event TabActivated onTabActivated;

        public class TabEventArgs : EventArgs
        {
            public TabControl Tab;
        }
        public delegate void TabCreated();
        public event TabActivated onTabCreated;
        
        public bool Active;
        public bool IsMain { get; set; } = false;
        
        private bool SetActive(bool activeStatus)
        {
            Active = activeStatus;
            return Active;
        }
        private string ActiveColors(bool ActiveStatus) => ActiveStatus ? "#3b3b3b" : "#262626";
        

        public TabControl(string Name, Models.AnimeList listConnected, bool isMain = false)
        {
            InitializeComponent();
            model = new TabModel() { ListConnected = listConnected };
            TabName.Text = Name;
            Activation();
            IsMain = isMain;
            CtxMenu.DataContext = this;
            xDelete.Tag = model.ListConnected;
            
            if(isMain) Panel.Children.Remove(xDelete);


        }

        public void Activation(object sender = null, MouseButtonEventArgs e = null)
        {
            if (sender != null && (App.window != null && App.window.IsActive) || (e != null && e.ChangedButton == MouseButton.Right))
            {
                return;
            }
            if (!Active)
            {
                foreach (var tab in App.list.TabList)
                {
                    tab.Deactivation();
                }

                onTabActivated?.Invoke(new TabEventArgs() {Tab = this});
                button.Background = new SolidColorBrush(
                    (Color)ColorConverter.ConvertFromString(
                        ActiveColors(
                            SetActive(true)))!);
            }
        }

        public void Deactivation()
        {
            if (Active)
            {
                button.Background = new SolidColorBrush(
                    (Color)ColorConverter.ConvertFromString(
                        ActiveColors(
                            SetActive(false)))!);
            }
        }

        private void RemoveButton(object sender, MouseButtonEventArgs e)
        {
            AnimeListConfig.Config config = App.Configuration.FindConfig(((Models.AnimeList)((Border)sender).Tag));
            App.Configuration.Configs.Remove(config);
            App.controlWindow.RefreshTabs();
        }

        private void ToTopFilenameClicked(object sender, RoutedEventArgs e)
        {
            var path = App.Configuration.FindConfig(model.ListConnected).Path;

            if (File.Exists(path))
            {
                var parent = Directory.GetParent(path);
                Process.Start($"{parent}");
            }
            else
            {
                App.controlWindow.RefreshTabs();
            }
        }
    }
}