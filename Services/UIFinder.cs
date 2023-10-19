using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace AnimeList.Services
{
    public static class UIFinder
    {
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject UI) where T : DependencyObject
        {
            if (UI != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(UI); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(UI, i);

                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
