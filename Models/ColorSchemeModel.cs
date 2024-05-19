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
                        {"BackgroundEditColor", "#ba2323"}, // Lighter red for edit backgrounds
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
                },
                new Theme(7, App.CurrentLanguage.ThemesTitlesTranslate.DesertTheme, new SolidColorBrush(Color.FromRgb(244, 164, 96))) // Sandy Brown
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#8B4513"}, // Saddle Brown for text
                        {"ForegroundWatchingColor", "#FFD700"}, // Gold for highlighted elements
                        {"InputBoxColor", "#FFF8DC"}, // Cornsilk for input areas
                        {"ForegroundDisabledColor", "#C0C0C0"}, // Silver for disabled text
                        {"BackgroundDarkerColor", "#D2B48C"}, // Tan for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#DEB887"}, // Burly Wood for even darker backgrounds
                        {"BackgroundModelColor", "#F5DEB3"}, // Wheat for modal backgrounds
                        {"MidColor", "#DAA520"}, // Goldenrod for mid elements
                        {"ButtonDisabledBackgroundColor", "#B8860B"}, // Dark Goldenrod for disabled buttons
                        {"BackgroundColor", "#FFF5EE"}, // Seashell for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#FFD700"}, // Gold for selected buttons
                        {"ButtonEnabledBackgroundColor", "#F4A460"}, // Sandy Brown for enabled buttons
                        {"BackgroundEditingColor", "#FFE4B5"}, // Moccasin for editing fields
                        {"BackgroundEditColor", "#FFDEAD"}, // Navajo White for edit backgrounds
                        {"TabActiveColor", "#FFFAF0"}, // Floral White for active tabs
                        {"TabPassiveColor", "#EED5B7"}, // Pale beige for passive tabs
                        {"BackgroundLightColor", "#FAEBD7"}, // Antique White for lighter elements
                    }
                },
                new Theme(8, App.CurrentLanguage.ThemesTitlesTranslate.SunsetTheme, new SolidColorBrush(Color.FromRgb(255, 99, 71))) // Tomato
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#800000"}, // Maroon for text
                        {"ForegroundWatchingColor", "#FFD700"}, // Gold for highlights
                        {"InputBoxColor", "#FFF5EE"}, // Seashell for input areas
                        {"ForegroundDisabledColor", "#CD5C5C"}, // Indian Red for disabled text
                        {"BackgroundDarkerColor", "#FF4500"}, // Orange Red for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#FF6347"}, // Tomato for more contrast
                        {"BackgroundModelColor", "#FF7F50"}, // Coral for modal backgrounds
                        {"MidColor", "#FA8072"}, // Salmon for mid elements
                        {"ButtonDisabledBackgroundColor", "#E9967A"}, // Dark Salmon for disabled buttons
                        {"BackgroundColor", "#FFE4E1"}, // Misty Rose for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#FF4500"}, // Orange Red for selected buttons
                        {"ButtonEnabledBackgroundColor", "#FF6347"}, // Tomato for enabled buttons
                        {"BackgroundEditingColor", "#FFF0F5"}, // Lavender Blush for editing fields
                        {"BackgroundEditColor", "#FFDAB9"}, // Peach Puff for edit backgrounds
                        {"TabActiveColor", "#FFA07A"}, // Light Salmon for active tabs
                        {"TabPassiveColor", "#FF7F50"}, // Coral for passive tabs
                        {"BackgroundLightColor", "#FFE4B5"}, // Moccasin for lighter elements
                    }
                },
                new Theme(9, App.CurrentLanguage.ThemesTitlesTranslate.OceanTheme, new SolidColorBrush(Color.FromRgb(0, 105, 148))) // Medium Sea Blue
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#000080"}, // Navy for text
                        {"ForegroundWatchingColor", "#20B2AA"}, // Light Sea Green for highlights
                        {"InputBoxColor", "#E0FFFF"}, // Light Cyan for input areas
                        {"ForegroundDisabledColor", "#A9A9A9"}, // Dark Gray for disabled text
                        {"BackgroundDarkerColor", "#4682B4"}, // Steel Blue for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#5F9EA0"}, // Cadet Blue for more contrast
                        {"BackgroundModelColor", "#B0C4DE"}, // Light Steel Blue for modal backgrounds
                        {"MidColor", "#00CED1"}, // Dark Turquoise for mid elements
                        {"ButtonDisabledBackgroundColor", "#A9A9A9"}, // Dark Gray for disabled buttons
                        {"BackgroundColor", "#F0FFFF"}, // Azure for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#5F9EA0"}, // Cadet Blue for selected buttons
                        {"ButtonEnabledBackgroundColor", "#4682B4"}, // Steel Blue for enabled buttons
                        {"BackgroundEditingColor", "#AFEEEE"}, // Pale Turquoise for editing fields
                        {"BackgroundEditColor", "#ADD8E6"}, // Light Blue for edit backgrounds
                        {"TabActiveColor", "#87CEEB"}, // Sky Blue for active tabs
                        {"TabPassiveColor", "#B0C4DE"}, // Light Steel Blue for passive tabs
                        {"BackgroundLightColor", "#87CEFA"}, // Light Sky Blue for lighter elements
                    }
                },
                new Theme(10, App.CurrentLanguage.ThemesTitlesTranslate.AutumnTheme, new SolidColorBrush(Color.FromRgb(210, 105, 30))) // Chocolate
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#8B4513"}, // Saddle Brown for text
                        {"ForegroundWatchingColor", "#FFD700"}, // Gold for highlights
                        {"InputBoxColor", "#FFEBCD"}, // Blanched Almond for input areas
                        {"ForegroundDisabledColor", "#A0522D"}, // Sienna for disabled text
                        {"BackgroundDarkerColor", "#D2691E"}, // Chocolate for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#CD853F"}, // Peru for more contrast
                        {"BackgroundModelColor", "#F4A460"}, // Sandy Brown for modal backgrounds
                        {"MidColor", "#DEB887"}, // Burly Wood for mid elements
                        {"ButtonDisabledBackgroundColor", "#A0522D"}, // Sienna for disabled buttons
                        {"BackgroundColor", "#FFE4C4"}, // Bisque for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#FF8C00"}, // Dark Orange for selected buttons
                        {"ButtonEnabledBackgroundColor", "#FFA07A"}, // Light Salmon for enabled buttons
                        {"BackgroundEditingColor", "#FFF8DC"}, // Cornsilk for editing fields
                        {"BackgroundEditColor", "#FAEBD7"}, // Antique White for edit backgrounds
                        {"TabActiveColor", "#FF7F50"}, // Coral for active tabs
                        {"TabPassiveColor", "#CD853F"}, // Peru for passive tabs
                        {"BackgroundLightColor", "#FFDAB9"}, // Peach Puff for lighter elements
                    }
                },
                new Theme(11, App.CurrentLanguage.ThemesTitlesTranslate.SpaceTheme, new SolidColorBrush(Color.FromRgb(10, 10, 36))) // Dark Blue
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#FFFFFF"}, // White for text
                        {"ForegroundWatchingColor", "#87CEEB"}, // Sky Blue for highlights
                        {"InputBoxColor", "#1C1C3C"}, // Dark Slate Blue for input areas
                        {"ForegroundDisabledColor", "#696969"}, // Dim Gray for disabled text
                        {"BackgroundDarkerColor", "#000080"}, // Navy for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#191970"}, // Midnight Blue for more contrast
                        {"BackgroundModelColor", "#2F4F4F"}, // Dark Slate Gray for modal backgrounds
                        {"MidColor", "#4169E1"}, // Royal Blue for mid elements
                        {"ButtonDisabledBackgroundColor", "#2F4F4F"}, // Dark Slate Gray for disabled buttons
                        {"BackgroundColor", "#0B3D91"}, // Dark Blue for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#1E90FF"}, // Dodger Blue for selected buttons
                        {"ButtonEnabledBackgroundColor", "#4682B4"}, // Steel Blue for enabled buttons
                        {"BackgroundEditingColor", "#1C1C1C"}, // Very Dark Gray for editing fields
                        {"BackgroundEditColor", "#2F4F4F"}, // Dark Slate Gray for edit backgrounds
                        {"TabActiveColor", "#87CEFA"}, // Light Sky Blue for active tabs
                        {"TabPassiveColor", "#1C1C3C"}, // Dark Slate Blue for passive tabs
                        {"BackgroundLightColor", "#4169E1"}, // Royal Blue for lighter elements
                    }
                },
                new Theme(12, App.CurrentLanguage.ThemesTitlesTranslate.ForestTheme, new SolidColorBrush(Color.FromRgb(34, 139, 34))) // Forest Green
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#013220"}, // Dark Green for text
                        {"ForegroundWatchingColor", "#FFD700"}, // Gold for highlights
                        {"InputBoxColor", "#228B22"}, // Forest Green for input areas
                        {"ForegroundDisabledColor", "#A9A9A9"}, // Dark Gray for disabled text
                        {"BackgroundDarkerColor", "#006400"}, // Dark Green for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#2E8B57"}, // Sea Green for more contrast
                        {"BackgroundModelColor", "#3CB371"}, // Medium Sea Green for modal backgrounds
                        {"MidColor", "#66CDAA"}, // Medium Aquamarine for mid elements
                        {"ButtonDisabledBackgroundColor", "#8FBC8F"}, // Dark Sea Green for disabled buttons
                        {"BackgroundColor", "#98FB98"}, // Pale Green for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#32CD32"}, // Lime Green for selected buttons
                        {"ButtonEnabledBackgroundColor", "#00FF7F"}, // Spring Green for enabled buttons
                        {"BackgroundEditingColor", "#F5FFFA"}, // Mint Cream for editing fields
                        {"BackgroundEditColor", "#E0EEE0"}, // Very Light Green for edit backgrounds
                        {"TabActiveColor", "#3CB371"}, // Medium Sea Green for active tabs
                        {"TabPassiveColor", "#2E8B57"}, // Sea Green for passive tabs
                        {"BackgroundLightColor", "#98FB98"}, // Pale Green for lighter elements
                    }
                },
                new Theme(13, App.CurrentLanguage.ThemesTitlesTranslate.IceTheme, new SolidColorBrush(Color.FromRgb(173, 216, 230))) // Light Blue
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#4682B4"}, // Steel Blue for text
                        {"ForegroundWatchingColor", "#00FFFF"}, // Cyan for highlights
                        {"InputBoxColor", "#E0FFFF"}, // Light Cyan for input areas
                        {"ForegroundDisabledColor", "#B0C4DE"}, // Light Steel Blue for disabled text
                        {"BackgroundDarkerColor", "#5F9EA0"}, // Cadet Blue for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#B0E0E6"}, // Powder Blue for more contrast
                        {"BackgroundModelColor", "#AFEEEE"}, // Pale Turquoise for modal backgrounds
                        {"MidColor", "#ADD8E6"}, // Light Blue for mid elements
                        {"ButtonDisabledBackgroundColor", "#A9A9A9"}, // Dark Gray for disabled buttons
                        {"BackgroundColor", "#F0FFFF"}, // Azure for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#00BFFF"}, // Deep Sky Blue for selected buttons
                        {"ButtonEnabledBackgroundColor", "#87CEEB"}, // Sky Blue for enabled buttons
                        {"BackgroundEditingColor", "#E1FFFF"}, // Light Cyan for editing fields
                        {"BackgroundEditColor", "#B0E0E6"}, // Powder Blue for edit backgrounds
                        {"TabActiveColor", "#87CEEB"}, // Sky Blue for active tabs
                        {"TabPassiveColor", "#4682B4"}, // Steel Blue for passive tabs
                        {"BackgroundLightColor", "#E0FFFF"}, // Light Cyan for lighter elements
                    }
                },
                new Theme(14, App.CurrentLanguage.ThemesTitlesTranslate.CandyTheme, new SolidColorBrush(Color.FromRgb(255, 182, 193))) // Light Pink
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#000"}, // Black for text
                        {"ForegroundWatchingColor", "#FFB6C1"}, // Light Pink for highlights
                        {"InputBoxColor", "#FFF0F5"}, // Lavender Blush for input areas
                        {"ForegroundDisabledColor", "#D3D3D3"}, // Light Gray for disabled text
                        {"BackgroundDarkerColor", "#FF1493"}, // Deep Pink for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#FF69B4"}, // Hot Pink for more contrast
                        {"BackgroundModelColor", "#FFC0CB"}, // Pink for modal backgrounds
                        {"MidColor", "#FFB6C1"}, // Light Pink for mid elements
                        {"ButtonDisabledBackgroundColor", "#E9967A"}, // Dark Salmon for disabled buttons
                        {"BackgroundColor", "#FFE4E1"}, // Misty Rose for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#FF1493"}, // Deep Pink for selected buttons
                        {"ButtonEnabledBackgroundColor", "#FF69B4"}, // Hot Pink for enabled buttons
                        {"BackgroundEditingColor", "#FFF0F5"}, // Lavender Blush for editing fields
                        {"BackgroundEditColor", "#FFDAB9"}, // Peach Puff for edit backgrounds
                        {"TabActiveColor", "#FFB6C1"}, // Light Pink for active tabs
                        {"TabPassiveColor", "#FFC0CB"}, // Pink for passive tabs
                        {"BackgroundLightColor", "#FFF5EE"}, // Seashell for lighter elements
                    }
                },
                new Theme(15, App.CurrentLanguage.ThemesTitlesTranslate.RetroTheme, new SolidColorBrush(Color.FromRgb(255, 228, 196))) // Bisque
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#8B4513"}, // Saddle Brown for text
                        {"ForegroundWatchingColor", "#FFD700"}, // Gold for highlights
                        {"InputBoxColor", "#FFE4C4"}, // Bisque for input areas
                        {"ForegroundDisabledColor", "#D3D3D3"}, // Light Gray for disabled text
                        {"BackgroundDarkerColor", "#CD853F"}, // Peru for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#DEB887"}, // Burly Wood for more contrast
                        {"BackgroundModelColor", "#F5DEB3"}, // Wheat for modal backgrounds
                        {"MidColor", "#D2B48C"}, // Tan for mid elements
                        {"ButtonDisabledBackgroundColor", "#8B4513"}, // Saddle Brown for disabled buttons
                        {"BackgroundColor", "#FFE4B5"}, // Moccasin for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#FFD700"}, // Gold for selected buttons
                        {"ButtonEnabledBackgroundColor", "#FFA500"}, // Orange for enabled buttons
                        {"BackgroundEditingColor", "#FFF8DC"}, // Cornsilk for editing fields
                        {"BackgroundEditColor", "#FAEBD7"}, // Antique White for edit backgrounds
                        {"TabActiveColor", "#FFD700"}, // Gold for active tabs
                        {"TabPassiveColor", "#CD853F"}, // Peru for passive tabs
                        {"BackgroundLightColor", "#F5DEB3"}, // Wheat for lighter elements
                    }
                },
                new Theme(16, App.CurrentLanguage.ThemesTitlesTranslate.NeonTheme, new SolidColorBrush(Color.FromRgb(57, 255, 20))) // Neon Green
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#39FF14"}, // Neon Green for text
                        {"ForegroundWatchingColor", "#FF1493"}, // Deep Pink for highlights
                        {"InputBoxColor", "#0F0F0F"}, // Almost Black for input areas
                        {"ForegroundDisabledColor", "#696969"}, // Dim Gray for disabled text
                        {"BackgroundDarkerColor", "#0F0F0F"}, // Almost Black for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#0D0D0D"}, // Even Darker Almost Black for more contrast
                        {"BackgroundModelColor", "#1C1C1C"}, // Very Dark Gray for modal backgrounds
                        {"MidColor", "#FF00FF"}, // Magenta for mid elements
                        {"ButtonDisabledBackgroundColor", "#696969"}, // Dim Gray for disabled buttons
                        {"BackgroundColor", "#000000"}, // Black for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#FF00FF"}, // Magenta for selected buttons
                        {"ButtonEnabledBackgroundColor", "#FF4500"}, // Orange Red for enabled buttons
                        {"BackgroundEditingColor", "#1C1C1C"}, // Very Dark Gray for editing fields
                        {"BackgroundEditColor", "#2F4F4F"}, // Dark Slate Gray for edit backgrounds
                        {"TabActiveColor", "#FF1493"}, // Deep Pink for active tabs
                        {"TabPassiveColor", "#0F0F0F"}, // Almost Black for passive tabs
                        {"BackgroundLightColor", "#1C1C1C"}, // Very Dark Gray for lighter elements
                    }
                },
                new Theme(17, App.CurrentLanguage.ThemesTitlesTranslate.GalaxyTheme, new SolidColorBrush(Color.FromRgb(75, 0, 130))) // Indigo
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#FFFFFF"}, // White for text
                        {"ForegroundWatchingColor", "#9400D3"}, // Dark Violet for highlights
                        {"InputBoxColor", "#4B0082"}, // Indigo for input areas
                        {"ForegroundDisabledColor", "#A9A9A9"}, // Dark Gray for disabled text
                        {"BackgroundDarkerColor", "#2E0854"}, // Dark Purple for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#4B0082"}, // Indigo for more contrast
                        {"BackgroundModelColor", "#8A2BE2"}, // Blue Violet for modal backgrounds
                        {"MidColor", "#9932CC"}, // Dark Orchid for mid elements
                        {"ButtonDisabledBackgroundColor", "#8B008B"}, // Dark Magenta for disabled buttons
                        {"BackgroundColor", "#483D8B"}, // Dark Slate Blue for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#9400D3"}, // Dark Violet for selected buttons
                        {"ButtonEnabledBackgroundColor", "#BA55D3"}, // Medium Orchid for enabled buttons
                        {"BackgroundEditingColor", "#7B68EE"}, // Medium Slate Blue for editing fields
                        {"BackgroundEditColor", "#9370DB"}, // Medium Purple for edit backgrounds
                        {"TabActiveColor", "#9932CC"}, // Dark Orchid for active tabs
                        {"TabPassiveColor", "#4B0082"}, // Indigo for passive tabs
                        {"BackgroundLightColor", "#6A5ACD"}, // Slate Blue for lighter elements
                    }
                },
                new Theme(18, App.CurrentLanguage.ThemesTitlesTranslate.RainbowTheme, new SolidColorBrush(Color.FromRgb(255, 0, 0))) // Red
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#FFFFFF"}, // White for text
                        {"ForegroundWatchingColor", "#FFD700"}, // Gold for highlights
                        {"InputBoxColor", "#FF0000"}, // Red for input areas
                        {"ForegroundDisabledColor", "#A9A9A9"}, // Dark Gray for disabled text
                        {"BackgroundDarkerColor", "#FF4500"}, // Orange Red for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#FFD700"}, // Gold for more contrast
                        {"BackgroundModelColor", "#FFFF00"}, // Yellow for modal backgrounds
                        {"MidColor", "#ADFF2F"}, // Green Yellow for mid elements
                        {"ButtonDisabledBackgroundColor", "#A9A9A9"}, // Dark Gray for disabled buttons
                        {"BackgroundColor", "#7FFF00"}, // Chartreuse for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#00FF00"}, // Lime for selected buttons
                        {"ButtonEnabledBackgroundColor", "#00CED1"}, // Dark Turquoise for enabled buttons
                        {"BackgroundEditingColor", "#1E90FF"}, // Dodger Blue for editing fields
                        {"BackgroundEditColor", "#BA55D3"}, // Medium Orchid for edit backgrounds
                        {"TabActiveColor", "#FF69B4"}, // Hot Pink for active tabs
                        {"TabPassiveColor", "#ADFF2F"}, // Green Yellow for passive tabs
                        {"BackgroundLightColor", "#DDA0DD"}, // Plum for lighter elements
                    }
                },
                new Theme(19, App.CurrentLanguage.ThemesTitlesTranslate.FireTheme, new SolidColorBrush(Color.FromRgb(255, 69, 0))) // Orange Red
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#8B0000"}, // Dark Red for text
                        {"ForegroundWatchingColor", "#FFD700"}, // Gold for highlights
                        {"InputBoxColor", "#FF4500"}, // Orange Red for input areas
                        {"ForegroundDisabledColor", "#A9A9A9"}, // Dark Gray for disabled text
                        {"BackgroundDarkerColor", "#B22222"}, // Fire Brick for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#FF6347"}, // Tomato for more contrast
                        {"BackgroundModelColor", "#FF7F50"}, // Coral for modal backgrounds
                        {"MidColor", "#FF8C00"}, // Dark Orange for mid elements
                        {"ButtonDisabledBackgroundColor", "#A9A9A9"}, // Dark Gray for disabled buttons
                        {"BackgroundColor", "#FFA07A"}, // Light Salmon for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#FF4500"}, // Orange Red for selected buttons
                        {"ButtonEnabledBackgroundColor", "#FF6347"}, // Tomato for enabled buttons
                        {"BackgroundEditingColor", "#FFE4E1"}, // Misty Rose for editing fields
                        {"BackgroundEditColor", "#FA8072"}, // Salmon for edit backgrounds
                        {"TabActiveColor", "#FF7F50"}, // Coral for active tabs
                        {"TabPassiveColor", "#CD5C5C"}, // Indian Red for passive tabs
                        {"BackgroundLightColor", "#FFA07A"}, // Light Salmon for lighter elements
                    }
                },
                new Theme(20, App.CurrentLanguage.ThemesTitlesTranslate.NatureTheme, new SolidColorBrush(Color.FromRgb(60, 179, 113))) // Medium Sea Green
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#2E8B57"}, // Sea Green for text
                        {"ForegroundWatchingColor", "#FFD700"}, // Gold for highlights
                        {"InputBoxColor", "#3CB371"}, // Medium Sea Green for input areas
                        {"ForegroundDisabledColor", "#A9A9A9"}, // Dark Gray for disabled text
                        {"BackgroundDarkerColor", "#006400"}, // Dark Green for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#228B22"}, // Forest Green for more contrast
                        {"BackgroundModelColor", "#32CD32"}, // Lime Green for modal backgrounds
                        {"MidColor", "#7FFF00"}, // Chartreuse for mid elements
                        {"ButtonDisabledBackgroundColor", "#A9A9A9"}, // Dark Gray for disabled buttons
                        {"BackgroundColor", "#98FB98"}, // Pale Green for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#7CFC00"}, // Lawn Green for selected buttons
                        {"ButtonEnabledBackgroundColor", "#00FF7F"}, // Spring Green for enabled buttons
                        {"BackgroundEditingColor", "#F5FFFA"}, // Mint Cream for editing fields
                        {"BackgroundEditColor", "#E0EEE0"}, // Very Light Green for edit backgrounds
                        {"TabActiveColor", "#66CDAA"}, // Medium Aquamarine for active tabs
                        {"TabPassiveColor", "#3CB371"}, // Medium Sea Green for passive tabs
                        {"BackgroundLightColor", "#F0FFF0"}, // Honeydew for lighter elements
                    }
                },
                new Theme(21, App.CurrentLanguage.ThemesTitlesTranslate.NightTheme, new SolidColorBrush(Color.FromRgb(25, 25, 112))) // Midnight Blue
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#FFFFFF"}, // White for text
                        {"ForegroundWatchingColor", "#FFD700"}, // Gold for highlights
                        {"InputBoxColor", "#191970"}, // Midnight Blue for input areas
                        {"ForegroundDisabledColor", "#A9A9A9"}, // Dark Gray for disabled text
                        {"BackgroundDarkerColor", "#000080"}, // Navy for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#00008B"}, // Dark Blue for more contrast
                        {"BackgroundModelColor", "#483D8B"}, // Dark Slate Blue for modal backgrounds
                        {"MidColor", "#6A5ACD"}, // Slate Blue for mid elements
                        {"ButtonDisabledBackgroundColor", "#2F4F4F"}, // Dark Slate Gray for disabled buttons
                        {"BackgroundColor", "#000000"}, // Black for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#4682B4"}, // Steel Blue for selected buttons
                        {"ButtonEnabledBackgroundColor", "#5F9EA0"}, // Cadet Blue for enabled buttons
                        {"BackgroundEditingColor", "#1C1C1C"}, // Very Dark Gray for editing fields
                        {"BackgroundEditColor", "#2F4F4F"}, // Dark Slate Gray for edit backgrounds
                        {"TabActiveColor", "#4169E1"}, // Royal Blue for active tabs
                        {"TabPassiveColor", "#000080"}, // Navy for passive tabs
                        {"BackgroundLightColor", "#1E90FF"}, // Dodger Blue for lighter elements
                    }
                },
                new Theme(22, App.CurrentLanguage.ThemesTitlesTranslate.SnowTheme, new SolidColorBrush(Color.FromRgb(255, 250, 250))) // Snow
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#4682B4"}, // Steel Blue for text
                        {"ForegroundWatchingColor", "#FFD700"}, // Gold for highlights
                        {"InputBoxColor", "#E0FFFF"}, // Light Cyan for input areas
                        {"ForegroundDisabledColor", "#B0C4DE"}, // Light Steel Blue for disabled text
                        {"BackgroundDarkerColor", "#5F9EA0"}, // Cadet Blue for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#B0E0E6"}, // Powder Blue for more contrast
                        {"BackgroundModelColor", "#AFEEEE"}, // Pale Turquoise for modal backgrounds
                        {"MidColor", "#ADD8E6"}, // Light Blue for mid elements
                        {"ButtonDisabledBackgroundColor", "#A9A9A9"}, // Dark Gray for disabled buttons
                        {"BackgroundColor", "#F0FFFF"}, // Azure for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#00BFFF"}, // Deep Sky Blue for selected buttons
                        {"ButtonEnabledBackgroundColor", "#87CEEB"}, // Sky Blue for enabled buttons
                        {"BackgroundEditingColor", "#E1FFFF"}, // Light Cyan for editing fields
                        {"BackgroundEditColor", "#B0E0E6"}, // Powder Blue for edit backgrounds
                        {"TabActiveColor", "#87CEEB"}, // Sky Blue for active tabs
                        {"TabPassiveColor", "#4682B4"}, // Steel Blue for passive tabs
                        {"BackgroundLightColor", "#E0FFFF"}, // Light Cyan for lighter elements
                    }
                },
                new Theme(23, App.CurrentLanguage.ThemesTitlesTranslate.CyberpunkTheme, new SolidColorBrush(Color.FromRgb(0, 255, 255))) // Cyan
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#00FFFF"}, // Cyan for text
                        {"ForegroundWatchingColor", "#FF00FF"}, // Magenta for highlights
                        {"InputBoxColor", "#2E2E2E"}, // Dark Gray for input areas
                        {"ForegroundDisabledColor", "#A9A9A9"}, // Dark Gray for disabled text
                        {"BackgroundDarkerColor", "#1C1C1C"}, // Very Dark Gray for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#000000"}, // Black for more contrast
                        {"BackgroundModelColor", "#2E2E2E"}, // Dark Gray for modal backgrounds
                        {"MidColor", "#00ff9f"}, // Dark Magenta for mid elements
                        {"ButtonDisabledBackgroundColor", "#2E2E2E"}, // Dark Gray for disabled buttons
                        {"BackgroundColor", "#000000"}, // Black for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#FF00FF"}, // Magenta for selected buttons
                        {"ButtonEnabledBackgroundColor", "#A020F0"}, // Cyan for enabled buttons
                        {"BackgroundEditingColor", "#2E2E2E"}, // Dark Gray for editing fields
                        {"BackgroundEditColor", "#1C1C1C"}, // Indigo for edit backgrounds
                        {"TabActiveColor", "#FF00FF"}, // Magenta for active tabs
                        {"TabPassiveColor", "#2E2E2E"}, // Dark Gray for passive tabs
                        {"BackgroundLightColor", "#1C1C1C"}, // Very Dark Gray for lighter elements
                    }
                },
                new Theme(24, App.CurrentLanguage.ThemesTitlesTranslate.SteampunkTheme, new SolidColorBrush(Color.FromRgb(139, 69, 19))) // Saddle Brown
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#D2B48C"}, // Tan for text
                        {"ForegroundWatchingColor", "#FFD700"}, // Gold for highlights
                        {"InputBoxColor", "#8B4513"}, // Saddle Brown for input areas
                        {"ForegroundDisabledColor", "#A9A9A9"}, // Dark Gray for disabled text
                        {"BackgroundDarkerColor", "#4B3A2A"}, // Dark Brown for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#3E2723"}, // Very Dark Brown for more contrast
                        {"BackgroundModelColor", "#5D4037"}, // Dark Brown for modal backgrounds
                        {"MidColor", "#D2691E"}, // Chocolate for mid elements
                        {"ButtonDisabledBackgroundColor", "#A9A9A9"}, // Dark Gray for disabled buttons
                        {"BackgroundColor", "#8B4513"}, // Saddle Brown for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#D2691E"}, // Chocolate for selected buttons
                        {"ButtonEnabledBackgroundColor", "#8B4513"}, // Saddle Brown for enabled buttons
                        {"BackgroundEditingColor", "#DEB887"}, // Burly Wood for editing fields
                        {"BackgroundEditColor", "#A0522D"}, // Sienna for edit backgrounds
                        {"TabActiveColor", "#FFD700"}, // Gold for active tabs
                        {"TabPassiveColor", "#8B4513"}, // Saddle Brown for passive tabs
                        {"BackgroundLightColor", "#F5DEB3"}, // Wheat for lighter elements
                    }
                },
                new Theme(25, App.CurrentLanguage.ThemesTitlesTranslate.MysticalForestTheme, new SolidColorBrush(Color.FromRgb(34, 139, 34))) // Forest Green
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#228B22"}, // Forest Green for text
                        {"ForegroundWatchingColor", "#ADFF2F"}, // Green Yellow for highlights
                        {"InputBoxColor", "#556B2F"}, // Dark Olive Green for input areas
                        {"ForegroundDisabledColor", "#8FBC8F"}, // Dark Sea Green for disabled text
                        {"BackgroundDarkerColor", "#006400"}, // Dark Green for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#2E8B57"}, // Sea Green for more contrast
                        {"BackgroundModelColor", "#66CDAA"}, // Medium Aquamarine for modal backgrounds
                        {"MidColor", "#20B2AA"}, // Light Sea Green for mid elements
                        {"ButtonDisabledBackgroundColor", "#A9A9A9"}, // Dark Gray for disabled buttons
                        {"BackgroundColor", "#3CB371"}, // Medium Sea Green for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#32CD32"}, // Lime Green for selected buttons
                        {"ButtonEnabledBackgroundColor", "#00FA9A"}, // Medium Spring Green for enabled buttons
                        {"BackgroundEditingColor", "#F0FFF0"}, // Honeydew for editing fields
                        {"BackgroundEditColor", "#98FB98"}, // Pale Green for edit backgrounds
                        {"TabActiveColor", "#66CDAA"}, // Medium Aquamarine for active tabs
                        {"TabPassiveColor", "#2E8B57"}, // Sea Green for passive tabs
                        {"BackgroundLightColor", "#F5FFFA"}, // Mint Cream for lighter elements
                    }
                },
                new Theme(26, App.CurrentLanguage.ThemesTitlesTranslate.SamuraiTheme, new SolidColorBrush(Color.FromRgb(128, 0, 0))) // Maroon
                {
                    Colors = new Dictionary<string, string>()
                    {
                        {"ForegroundColor", "#8fffff"}, // Maroon for text
                        {"ForegroundWatchingColor", "#FFD700"}, // Gold for highlights
                        {"InputBoxColor", "#3B3B3B"}, // Very Dark Gray for input areas
                        {"ForegroundDisabledColor", "#A9A9A9"}, // Dark Gray for disabled text
                        {"BackgroundDarkerColor", "#1B1B1B"}, // Almost Black for darker backgrounds
                        {"BackgroundMoreDarkerColor", "#2B2B2B"}, // Very Dark Gray for more contrast
                        {"BackgroundModelColor", "#4B0082"}, // Indigo for modal backgrounds
                        {"MidColor", "#8B0000"}, // Dark Red for mid elements
                        {"ButtonDisabledBackgroundColor", "#A9A9A9"}, // Dark Gray for disabled buttons
                        {"BackgroundColor", "#2F4F4F"}, // Dark Slate Gray for general backgrounds
                        {"ButtonSelectedBackgroundColor", "#FF4500"}, // Orange Red for selected buttons
                        {"ButtonEnabledBackgroundColor", "#DC143C"}, // Crimson for enabled buttons
                        {"BackgroundEditingColor", "#FA8072"}, // Salmon for editing fields
                        {"BackgroundEditColor", "#800000"}, // Maroon for edit backgrounds
                        {"TabActiveColor", "#FFD700"}, // Gold for active tabs
                        {"TabPassiveColor", "#8B0000"}, // Dark Red for passive tabs
                        {"BackgroundLightColor", "#A52A2A"}, // Brown for lighter elements
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
