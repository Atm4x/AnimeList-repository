using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace AnimeList.Models
{
    public static class ColorSchemeModel
    {
        //public static List<(string, string)> DarkScheme = new List<(string, string)>()
        //{
        //        ("ForegroundColor", "#fff"),
        //        ("ForegroundWathcingColor", "#F0E68C"),
        //        ("InputBoxColor", "#2c2c2c"),
        //        ("ForegroundDisabledColor", "#808080"),
        //        ("BackgroundDarkerColor", "#1e1e1e"),
        //        ("BackgroundMoreDarkerColor", "#121212"),
        //        ("BackgroundModelColor", "#333333"),
        //        ("MidColor", "#2b2b2b"),
        //        ("ButtonDisabledBackgroundColor", "#1f1f1f"),
        //        ("BackgroundColor", "#363636"),
        //        ("ButtonSelectedBackgroundColor", "#121212"),
        //        ("ButtonEnabledBackgroundColor", "#222222"),
        //        ("BackgroundEditingColor", "#1a1a1a"),
        //        ("BackgroundEditColor", "#202020"),
        //        ("TabActiveColor", "#3b3b3b"),
        //        ("TabPassiveColor", "#262626"),
        //        ("BackgroundLightColor", "#515151"),
        //};


        public delegate void Themed();
        public static event Themed ThemeChanged;

        public static List<Theme> Themes = new List<Theme>()
        {
            new Theme(1, "Light Theme", new SolidColorBrush(Color.FromRgb(220, 220, 220)))
            {
                Colors = new Dictionary<string, string>()
                {
                    {"ForegroundColor", "#000"},
                    {"ForegroundWathcingColor", "#620f73"},
                    {"InputBoxColor", "#f4f4f4"},
                    {"ForegroundDisabledColor", "#999999"},
                    {"BackgroundDarkerColor", "#e0e0e0"},
                    {"BackgroundMoreDarkerColor", "#ffffff"},
                    {"BackgroundModelColor", "#eeeeee"},
                    {"MidColor", "#d6d6d6"},
                    {"ButtonDisabledBackgroundColor", "#e0e0e0"},
                    {"BackgroundColor", "#fefefe"},
                    {"ButtonSelectedBackgroundColor", "#ffffff"},
                    {"ButtonEnabledBackgroundColor", "#f2f2f2"},
                    {"BackgroundEditingColor", "#e6e6e6"},
                    {"BackgroundEditColor", "#fafafa"},
                    {"TabActiveColor", "#f2f2f2"},
                    {"TabPassiveColor", "#c4c4c4"},
                    {"BackgroundLightColor", "#d6d6d6"},
                }
            },
            new Theme(2, "Dark Scheme",  new SolidColorBrush(Color.FromRgb(20, 20, 20)))
            {
                Colors = new Dictionary<string, string>()
                {
                    {"ForegroundColor", "#fff"},
                    {"ForegroundWathcingColor", "#F0E68C"},
                    {"InputBoxColor", "#2c2c2c"},
                    {"ForegroundDisabledColor", "#808080"},
                    {"BackgroundDarkerColor", "#1e1e1e"},
                    {"BackgroundMoreDarkerColor", "#121212"},
                    {"BackgroundModelColor", "#333333"},
                    {"MidColor", "#202020"},
                    {"ButtonDisabledBackgroundColor", "#121212"},
                    {"BackgroundColor", "#2b2b2b"},
                    {"ButtonSelectedBackgroundColor", "#222222"},
                    {"ButtonEnabledBackgroundColor", "#1a1a1a"},
                    {"BackgroundEditingColor", "#1f1f1f"},
                    {"BackgroundEditColor", "#202020"},
                    {"TabActiveColor", "#3b3b3b"},
                    {"TabPassiveColor", "#262626"},
                    {"BackgroundLightColor", "#515151"},
                }
            }
        };



        public static void ChangeTheme(int themeId)
        {
            var theme = Themes.Find(t => t.ID == themeId);
            if (theme != null)
            {
                foreach (var color in theme.Colors)
                {
                    App.Current.Resources[color.Key] = (Color)ColorConverter.ConvertFromString(color.Value);
                }
                ThemeChanged?.Invoke();
            }
            else
            {
                MessageBox.Show("Неудача");
            }
        }

    }

    public class Theme
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Dictionary<string, string> Colors { get; set; }
        public SolidColorBrush SchemeBackground { get; set; }

        public Theme(int id, string title, SolidColorBrush schemeBackground)
        {
            ID = id;
            Title = title;
            Colors = new Dictionary<string, string>();
            SchemeBackground = schemeBackground;
        }

        public void AddColor(string key, string value)
        {
            Colors[key] = value;
        }
    }

}
