using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AnimeList.Helpers
{
    public class ColorHelper
    {
        public static string InvertHexColor(string hexColor)
        {
            if (hexColor.StartsWith("#"))
            {
                hexColor = hexColor.Substring(1);
            }

            Color originalColor = (Color)ColorConverter.ConvertFromString("#" + hexColor);

            Color invertedColor = new Color
            {
                A = originalColor.A,
                R = (byte)(255 - originalColor.R),
                G = (byte)(255 - originalColor.G),
                B = (byte)(255 - originalColor.B)
            };

            string invertedHexColor = invertedColor.ToString();
            return invertedHexColor;
        }
    }
}
