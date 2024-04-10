using AnimeList.Models;
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

namespace AnimeList.Controls.ActionVisuals
{
    public partial class EditActionVisual : Border
    {
        public EditActionVisual(EditAction action)
        {
            InitializeComponent();
            if(action.PlaceA > action.PlaceB)
            {
                PlaceA.Text = $"{action.PlaceB}.";
                NameA.Text = $"{action.NameB}";
                WatchingA.Visibility = action.WatchingB == AnimeModelStatus.InProcess ? Visibility.Visible : Visibility.Hidden;
                PlaceB.Text = $"{action.PlaceA}.";
                NameB.Text = $"{action.NameA}";
                WatchingB.Visibility = action.WatchingA == AnimeModelStatus.InProcess ? Visibility.Visible : Visibility.Hidden;

                UpArrow.Visibility = Visibility.Visible;
            } 
            else if(action.PlaceA <= action.PlaceB)
            {
                PlaceA.Text = $"{action.PlaceA}.";
                NameA.Text = $"{action.NameA}";
                WatchingA.Visibility = action.WatchingA == AnimeModelStatus.InProcess ? Visibility.Visible : Visibility.Hidden;
                PlaceB.Text = $"{action.PlaceB}.";
                NameB.Text = $"{action.NameB}";
                WatchingB.Visibility = action.WatchingB == AnimeModelStatus.InProcess ? Visibility.Visible : Visibility.Hidden;

                if(action.PlaceA == action.PlaceB)
                    EqualsSymbol.Visibility = Visibility.Visible;
                else
                    DownArrow.Visibility = Visibility.Visible;
            }
        }
    }
}
