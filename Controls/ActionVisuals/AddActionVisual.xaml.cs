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
    public partial class AddActionVisual : Border
    {
        public AddActionVisual(AddAction action)
        {
            InitializeComponent();
            Place.Text = $"{action.AModel.Place}.";
            Name.Text = $"{action.AModel.Name}.";
        }
    }
}
