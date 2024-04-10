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

        public static List<Theme> Themes;

        public static void SetupColors()
        {

            Themes = new List<Theme>()
            {

                new Theme(1, App.CurrentLanguage.ThemesTitlesTranslate.DarkTheme,  new SolidColorBrush(Color.FromRgb(20, 20, 20)))
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#fff"},
                        {"ForegroundWatchingColor", "#F0E68C"},
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
                        {"BackgroundEditColor", "#363636"},
                        {"TabActiveColor", "#3b3b3b"},
                        {"TabPassiveColor", "#262626"},
                        {"BackgroundLightColor", "#515151"},
                    }
                },
                new Theme(2, App.CurrentLanguage.ThemesTitlesTranslate.LightTheme, new SolidColorBrush(Color.FromRgb(220, 220, 220)))
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#000"},
                        {"ForegroundWatchingColor", "#de40ff"},
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
                new Theme(3, App.CurrentLanguage.ThemesTitlesTranslate.USSRTheme, new SolidColorBrush(Color.FromRgb(255, 23, 68))) // A strong red for primary elements
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#FFFFFF"}, // White for text to contrast against the dark reds and greys
                        {"ForegroundWatchingColor", "#FFD700"}, // Gold for highlighted elements, inspired by the hammer and sickle
                        {"InputBoxColor", "#CC2128"}, // A slightly darker red for input areas
                        {"ForegroundDisabledColor", "#999999"}, // Grey for disabled text, keeping with the theme
                        {"BackgroundDarkerColor", "#B32128"}, // A darker shade of red for varied background elements
                        {"BackgroundMoreDarkerColor", "#991B1E"}, // Even darker red for additional depth
                        {"BackgroundModelColor", "#E53935"}, // Bright red for modal backgrounds
                        {"MidColor", "#AB2024"}, // Mid-tone red for intermediate elements
                        {"ButtonDisabledBackgroundColor", "#7E1A1C"}, // Dark red for disabled buttons
                        {"BackgroundColor", "#D32F2F"}, // Standard Soviet red for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#FFD700"}, // Gold for selected buttons, adding contrast
                        {"ButtonEnabledBackgroundColor", "#C62828"}, // A slightly muted red for enabled buttons
                        {"BackgroundEditingColor", "#DE2D2F"}, // A vibrant red for editing areas
                        {"BackgroundEditColor", "#EF9A9A"}, // Lighter red for edit backgrounds
                        {"TabActiveColor", "#FFC107"}, // Gold for active tabs
                        {"TabPassiveColor", "#9E9E9E"}, // Grey for passive tabs, providing a subdued contrast
                        {"BackgroundLightColor", "#F44336"}, // Light, bright red for lighter elements
                    }
                },
                new Theme(4, App.CurrentLanguage.ThemesTitlesTranslate.WaterfallTheme, new SolidColorBrush(Color.FromRgb(173, 216, 230))) // Light Blue color
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#003366"}, // Dark Blue
                        {"ForegroundWatchingColor", "#007FFF"}, // Azure Blue
                        {"InputBoxColor", "#FFFFFF"}, // White
                        {"ForegroundDisabledColor", "#7F8C8D"}, // Gray for disabled text
                        {"BackgroundDarkerColor", "#B0C4DE"}, // Light Steel Blue
                        {"BackgroundMoreDarkerColor", "#E0FFFF"}, // Light Cyan
                        {"BackgroundModelColor", "#AFEEEE"}, // Pale Turquoise
                        {"MidColor", "#5D8AA8"}, // Air Force Blue
                        {"ButtonDisabledBackgroundColor", "#BDC3C7"}, // Silver
                        {"BackgroundColor", "#E6E6E6"}, // Light Gray, simulating spray mist
                        {"ButtonSelectedBackgroundColor", "#ADD8E6"}, // Light Blue, for a more interactive feel
                        {"ButtonEnabledBackgroundColor", "#B3CEE5"}, // Similar to Light Blue but slightly different for depth
                        {"BackgroundEditingColor", "#D3D3D3"}, // Light Gray, for editing fields
                        {"BackgroundEditColor", "#F0F8FF"}, // Alice Blue, very light and airy
                        {"TabActiveColor", "#B2DFEE"}, // Light Sky Blue
                        {"TabPassiveColor", "#7EC0EE"}, // Sky Blue, slightly darker for contrast
                        {"BackgroundLightColor", "#87CEEB"}, // Sky Blue
                    }
                },

                new Theme(5, App.CurrentLanguage.ThemesTitlesTranslate.LoveTheme, new SolidColorBrush(Color.FromRgb(255, 182, 193))) // Light Pink
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#B03060"}, // Maroon
                        {"ForegroundWatchingColor", "#FF69B4"}, // Hot Pink for highlights
                        {"InputBoxColor", "#FFF0F5"}, // Lavender Blush for a soft, inviting input area
                        {"ForegroundDisabledColor", "#D3D3D3"}, // Light Gray for disabled text, keeping it gentle
                        {"BackgroundDarkerColor", "#FFC0CB"}, // Pink, slightly darker for contrast
                        {"BackgroundMoreDarkerColor", "#FFB6C1"}, // Light Pink, a bit more intense for depth
                        {"BackgroundModelColor", "#FFD1DC"}, // Pale, soft pink for modal backgrounds
                        {"MidColor", "#FFAEB9"}, // A softer pink for mid elements
                        {"ButtonDisabledBackgroundColor", "#E6E6E6"}, // Light Gray, neutral for disabled buttons
                        {"BackgroundColor", "#FFF5EE"}, // Seashell, soft and warm background color
                        {"ButtonSelectedBackgroundColor", "#FFB6C1"}, // Light Pink for selected buttons, slightly vibrant
                        {"ButtonEnabledBackgroundColor", "#FFC0CB"}, // Pink, cheerful and inviting for enabled buttons
                        {"BackgroundEditingColor", "#F8F0E3"}, // A very soft peach, for editing fields
                        {"BackgroundEditColor", "#FAEBD7"}, // Antique White, rich and warm for edit backgrounds
                        {"TabActiveColor", "#FFD1DC"}, // Pale, soft pink for active tabs, gentle and inviting
                        {"TabPassiveColor", "#FFAEB9"}, // A softer pink for passive tabs, to distinguish from active ones
                        {"BackgroundLightColor", "#FFD1DC"}, // Matching the modal color for consistency
                    }
                },
                new Theme(6, App.CurrentLanguage.ThemesTitlesTranslate.JungleTheme, new SolidColorBrush(Color.FromRgb(34, 139, 34))) // Forest Green
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#004d00"}, // Dark Green for text, representing the dense foliage
                        {"ForegroundWatchingColor", "#ff4500"}, // Orange Red for highlights, mimicking exotic flowers
                        {"InputBoxColor", "#f5f5dc"}, // Beige, for a natural, light background in input boxes
                        {"ForegroundDisabledColor", "#708090"}, // Slate Gray for disabled text, resembling stones and river rocks
                        {"BackgroundDarkerColor", "#228b22"}, // Forest Green, a bit darker for contrast
                        {"BackgroundMoreDarkerColor", "#006400"}, // Dark Green, even more depth for shadows and underbrush
                        {"BackgroundModelColor", "#8fbc8f"}, // Dark Sea Green, for modal backgrounds, softer and lighter
                        {"MidColor", "#66cdaa"}, // Medium Aquamarine, representing clear, shallow waters
                        {"ButtonDisabledBackgroundColor", "#a9a9a9"}, // Dark Gray, neutral for disabled buttons
                        {"BackgroundColor", "#f0fff0"}, // Honeydew, a very light, almost white green, for the background
                        {"ButtonSelectedBackgroundColor", "#adff2f"}, // Green Yellow, vibrant for selected buttons
                        {"ButtonEnabledBackgroundColor", "#98fb98"}, // Pale Green, fresh and inviting for enabled buttons
                        {"BackgroundEditingColor", "#f5fffa"}, // Mint Cream, very light and airy for editing fields
                        {"BackgroundEditColor", "#e0eee0"}, // Very pale green, for edit backgrounds
                        {"TabActiveColor", "#8fbc8f"}, // Dark Sea Green for active tabs, blending in softly
                        {"TabPassiveColor", "#20b2aa"}, // Light Sea Green for passive tabs, a bit more pronounced
                        {"BackgroundLightColor", "#8fbc8f"}, // Matching the modal color for consistency and depth
                    }
                }
            };
        }

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
