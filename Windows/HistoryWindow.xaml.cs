using AnimeList.Controls.ActionVisuals;
using AnimeList.Models;
using AnimeList.Services;
using LanguageClassTest.Models;
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
using static System.Collections.Specialized.BitVector32;

namespace AnimeList.Windows
{
    /// <summary>
    /// Логика взаимодействия для HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        public HistoryWindow()
        {
            InitializeComponent();
            HistoryModelsList.ItemsSource = App.historyList.HList;
            HistoryModelsList.SelectionChanged += (sender, e) =>
            {
                var selected = (HistoryModel)HistoryModelsList.SelectedItem;
                if (selected != null)
                    HistoryChanges.ItemsSource
                    = HistoryChangeView.GetView(selected.HList)
                    .Reverse<HistoryChangeView>();

            }; 
            UIChangeLanguage(App.CurrentLanguage);
        }

        public void UIChangeLanguage(LanguageModel lang)
        {
            Title = lang.HistoryWindowTitle.Value;
            foreach (var translations in lang.Translate)
            {

                var textBlock = UIFinder.FindVisualChildren<TextBlock>(WholeGrid).FirstOrDefault(x => x.Name == translations.Name);
                if (textBlock != null)
                {
                    textBlock.Text = translations.Value;
                    continue;
                }
            }
        }

        private void SelectedSomething(object sender, RoutedEventArgs e)
        {
            var selected = (HistoryModel)HistoryModelsList.SelectedItem;
            if (selected != null)
                HistoryChanges.ItemsSource
                = HistoryChangeView.GetView(selected.HList)
                .Reverse<HistoryChangeView>();
        }

        private void SelectionOfAction(object sender, SelectionChangedEventArgs e)
        {
            if(HistoryChanges.SelectedItem is HistoryChangeView view)
            {
                switch (view.Action)
                {
                    case AddAction addAction:
                        VisualActionView.Child = new AddActionVisual(addAction);
                        break;
                    case RemoveAction removeAction:
                        VisualActionView.Child = new RemoveActionVisual(removeAction);
                        break;
                    case EditAction editAction:
                        VisualActionView.Child = new EditActionVisual(editAction);
                        break;
                    case WiFiAction:
                        VisualActionView.Child = new Grid();
                        break;

                }
                ChangeInfoTitle.Text = view.Name;
            }
        }

        public class HistoryChangeView
        {
            public IAction Action { get; set; }

            public string Name { get; set; }

            public HistoryChangeView(IAction action, string name)
            {
                Action = action;
                Name = name;
            }

            public static List<HistoryChangeView> GetView(List<IAction> actions)
            {
                var list = new List<HistoryChangeView>();
                int iterator = 0;
                foreach (var action in actions)
                {
                    iterator++;
                    switch(action)
                    {
                        case AddAction: 
                            list.Add(new HistoryChangeView(action, $"{iterator} - {App.CurrentLanguage.HistoryWindowActionsTranslate.AddMessage}"));
                            break;
                        case RemoveAction:
                            list.Add(new HistoryChangeView(action, $"{iterator} - {App.CurrentLanguage.HistoryWindowActionsTranslate.RemoveMessage}"));
                            break;
                        case EditAction:
                            list.Add(new HistoryChangeView(action, $"{iterator} - {App.CurrentLanguage.HistoryWindowActionsTranslate.EditMessage}"));
                            break;
                        case WiFiAction:
                            list.Add(new HistoryChangeView(action, $"{iterator} - {App.CurrentLanguage.HistoryWindowActionsTranslate.WiFiMessage}"));
                            break;
                    }
                }
                return list;
                
            }
        }
    }
}
