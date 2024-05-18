using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace AnimeList.Controls
{
    /// <summary>
    /// Логика взаимодействия для StarControl.xaml
    /// </summary>
    public partial class StarControl : StackPanel, INotifyPropertyChanged
    {
        private const string FilledStarPath = "M 10,1 L 12,7 L 18,7 L 13,11 L 15,17 L 10,13 L 5,17 L 7,11 L 2,7 L 8,7 Z";
        private const string EmptyStarPath = "M 10,1 L 12,7 L 18,7 L 13,11 L 15,17 L 10,13 L 5,17 L 7,11 L 2,7 L 8,7 Z";

        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register(nameof(Rating), typeof(int), typeof(StarControl),
                new PropertyMetadata(0, OnRatingChanged));

        public static readonly DependencyProperty MaxRatingProperty =
            DependencyProperty.Register(nameof(MaxRating), typeof(int), typeof(StarControl),
                new PropertyMetadata(10, OnMaxRatingChanged));

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler RatingChanged;

        public ObservableCollection<Star> Stars { get; set; } = new ObservableCollection<Star>();

        public int Rating
        {
            get => (int)GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }

        public int MaxRating
        {
            get => (int)GetValue(MaxRatingProperty);
            set => SetValue(MaxRatingProperty, value);
        }

        public StarControl()
        {
            InitializeComponent();
            DataContext = this;
            UpdateStars();
        }

        private static void OnRatingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is StarControl control)
            {
                control.OnPropertyChanged(nameof(Rating));
                control.UpdateStars();
                control.RatingChanged?.Invoke(control, EventArgs.Empty);
            }
        }

        private static void OnMaxRatingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is StarControl control)
            {
                control.OnPropertyChanged(nameof(MaxRating));
                control.UpdateStars();
            }
        }

        private void UpdateStars()
        {
            Stars.Clear();
            for (int i = 1; i <= MaxRating; i++)
            {
                Stars.Add(new Star
                {
                    Index = i,
                    PathData = Geometry.Parse(EmptyStarPath),
                    Fill = Brushes.Gray
                });
            }

            for (int i = 0; i < Rating; i++)
            {
                Stars[i].PathData = Geometry.Parse(FilledStarPath);
                Stars[i].Fill = Brushes.Orange;
            }
        }

        private void Star_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Path path && path.DataContext is Star star)
            {
                Rating = (Rating == star.Index) ? 0 : star.Index;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Star : INotifyPropertyChanged
    {
        private Geometry _pathData;
        private Brush _fill;
        public int Index { get; set; }

        public Geometry PathData
        {
            get => _pathData;
            set
            {
                _pathData = value;
                OnPropertyChanged(nameof(PathData));
            }
        }

        public Brush Fill
        {
            get => _fill;
            set
            {
                _fill = value;
                OnPropertyChanged(nameof(Fill));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
