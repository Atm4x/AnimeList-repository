using AnimeList.Services;
using LanguageClassTest.Models;
using Newtonsoft.Json.Linq;
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
using System.Windows.Shapes;

namespace AnimeList.Windows.Settings
{
    public partial class SettingsWindow : Window
    {
        public class ViewItem
        {
            public string Setting { get; set; }
            public int Tag { get; set; }

            public ViewItem(string settingName, int tag)
            {
                Setting = settingName;
                Tag = tag;
            }

            public static implicit operator ViewItem((string, int) args) 
                => new ViewItem(args.Item1, args.Item2);
        }

        public static List<ViewItem> Items { get; private set; } 

        public SettingsWindow()
        {
            InitializeComponent();
            Items = new List<ViewItem>()
            {
                (App.CurrentLanguage.SettingsWindowMessagesTranslate.General, 1)
            };
            SettingList.ItemsSource = Items; 
            UIChangeLanguage(App.CurrentLanguage);
        }

        public void UIChangeLanguage(LanguageModel lang)
        {
            Title = lang.SettingsWindowTitle.Value;
        }
    }
}
