using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using AnimeList.Controls;
using AnimeList.Helpers;
using AnimeList.Models;
using AnimeList.Services;
using DiscordRPC;
using Microsoft.Win32;
using TabControl = AnimeList.Controls.TabControl;

namespace AnimeList.Windows
{
    public partial class ControlWindow : Window
    {
        DiscordRPC.DiscordRpcClient client;

        public string MinuteStringFormat(int minutes)
        {
            int number = Convert.ToInt32(minutes.ToString());

            var numbers = number.ToString().ToArray();
            
            int last = Convert.ToInt32(numbers.Last().ToString());
            int _2last = Convert.ToInt32(String.Join("", numbers.Reverse().Take(2).Reverse()));
            
            if (_2last >= 11 && _2last <= 19)
            {
                return "минут";
            }
            else if (last == 1)
            {
                return "минуту";
            } 
            else if (last > 1 && last < 5)
            {
                return "минуты";
            }
            else
            {
                return "минут";
            }
        }

        public ControlWindow()
        {
            App.controlWindow = this;
            try
            {
                client = new DiscordRpcClient("951589158583943218");

                client.OnReady += (sender, e) =>
                {
                    Console.WriteLine("Received Ready from user {0}", e.User.Username);
                    user = client.CurrentUser;
                    var time = (DateTime.Now - started);
                    var minutes = Math.Floor(time.TotalMinutes);
                    client.SetPresence(new RichPresence()
                    {
                        Details = $"{(user?.Username)} редактирует топ",
                        Buttons = new DiscordRPC.Button[]
                        {
                            new DiscordRPC.Button()
                            {
                                Label = "Быть в шоке", Url = "https://www.youtube.com/channel/UCUmlHoipYHuw057PCaVnGkg"
                            }
                        },
                        State = $"{minutes} {MinuteStringFormat(Convert.ToInt32(minutes))}",
                        Timestamps = new Timestamps()
                        {
                            StartUnixMilliseconds =
                                Convert.ToUInt64(((DateTimeOffset)started).ToUnixTimeMilliseconds())
                        },
                        Assets = new Assets()
                        {
                            LargeImageKey = "anime_ico", LargeImageText = "AnimeList"
                        }

                    });
                };

                client.OnPresenceUpdate += (sender, e) => { Console.WriteLine("Received Update! {0}", e.Presence); };
                if (client.Initialize())
                {
                    App.timer = new Timer(30000);
                    App.timer.Elapsed += TOnElapsed;
                    App.timer.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла внутренняя ошибка." + ex.Message, "Внутренняя ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }

            InitializeComponent();
            VersionControl.Text = $"{App.versionUpdate.VersionControl} ({App.versionUpdate.VersionCount})";
            TitleUpdate.Text = $"{App.versionUpdate.VersionTitle}";
            DescriptionUpdate.Text = $"{App.versionUpdate.VersionDescription}";

            AnimeListConfig configuration = ConfigCipher.ReadConfigCipher();
            
            Models.AnimeList list = null;
            WarningWindow check = null;

            App.LanguageUpdated += LanguageUIUpdate;
            LanguagesHelper.SaveDefaultLanguage();
            App.Languages = LanguagesHelper.GetAllLanguagesModel().ToList();
            var rus = App.Languages.FirstOrDefault(x => x.Code.Value.Equals("ru-RU"));
            App.ChangeLanguage(rus ?? new LanguageClassTest.Models.LanguageModel());

            ALCipher.Cipher cipher1 = null;

            string fname = ""; 
            if (Application.Current.Properties["ArbitraryArgName"] != null)
            {
                InitializeComponent();


                fname = Application.Current.Properties["ArbitraryArgName"].ToString();
                check = new WarningWindow();
                check.ShowDialog();
                cipher1 = Helpers.ALCipher.ReadCipher(fname);
                var t = cipher1.EncryptionText;

                //тут начну замену
                list = JsonSerializer.Deserialize<Models.AnimeList>(t,
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = false,
                        IncludeFields = true
                    });
            }
            /*var items2 = JsonSerializer.Deserialize<List<AnimeModel>>(t, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = false,
                IncludeFields = true
            });
            var it = new AnimeList.Models.AnimeList(items2);
            
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            ALCipher.WriteCipher(new ALCipher.Cipher() {Type = "idk", EncryptionText = JsonSerializer.Serialize(it, options)});*/

            

            ALCipher.Cipher cipher2 = Helpers.ALCipher.ReadCipher();
                var own = cipher2.EncryptionText;
                var animelist = JsonSerializer.Deserialize<Models.AnimeList>(own,
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = false,
                        IncludeFields = true
                    });
                App.MainTab = new TabControl(cipher2.Name, animelist, true);
                AnimeList.ItemsSource = animelist.GetModels();
            

                if (check != null && check.ToRewrite)
                {
                    var options = new JsonSerializerOptions
                    {
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                        WriteIndented = true
                    };
                    ALCipher.WriteCipher(new ALCipher.Cipher()
                        { Name = "Default", EncryptionText = JsonSerializer.Serialize(App.list.TabList[0].model.ListConnected, options) });


                    App.MainTab = new TabControl(cipher2.Name, list, true);
                    AnimeList.ItemsSource = list.GetModels();
                }
            
            AnimeList.SelectionChanged += AnimeListOnSelectionChanged;
            if (check != null && check is { ToRewrite: false })
            {
                configuration.AddConfig(new AnimeListConfig.Config(list, fname, cipher1.Name));
            }

            RefreshTabs();
            if (App.isUpdated)
                ShowVersionReport();
        }

        private void LanguageUIUpdate(LanguageClassTest.Models.LanguageModel lang)
        {

            foreach (var translations in lang.Translate)
            {
                var buttonBlock = UIFinder.FindVisualChildren<System.Windows.Controls.Button>(WholeControlPanel).FirstOrDefault(x => x.Name == translations.Name);
                if (buttonBlock != null)
                {
                    buttonBlock.Content = translations.Value;
                    continue;
                }

                var textBlock = UIFinder.FindVisualChildren<TextBlock>(WholeControlPanel).FirstOrDefault(x => x.Name == translations.Name);
                if (textBlock != null)
                {
                    textBlock.Text = translations.Value;
                    continue;
                }

                var contextItemBlock = UIFinder.FindVisualChildren<MenuItem>(WholeControlPanel).FirstOrDefault(x => x.Name == translations.Name);
                if (contextItemBlock != null)
                {
                    contextItemBlock.Header = translations.Value;
                    continue;
                }
            }
        }

        public void RefreshTabs()
        {
            App.list.TabList.Clear();
            App.list.TabList.Add(App.MainTab);
            
            List<AnimeListConfig.Config> toDelete = new();
            foreach (var config in App.Configuration.Configs)
            {
                if (config.RestoreConfig(out AnimeListConfig.Config conf))
                {
                    toDelete.Add(conf);
                }
            }

            foreach (var removeItem in toDelete)
            {
                App.Configuration.Configs.RemoveAll(x => x.Equals(removeItem));
            }
            
            ConfigCipher.WriteConfigCipher();
            
            foreach (var config in App.Configuration.Configs)
            {
                var tab = new TabControl(config.Name, config.List);
                App.list.TabList.Add(tab);
            }
            Tabs.Children.Clear();
            foreach (var tab in App.list.TabList)
            {
                tab.onTabActivated += OnTabActivated;
                Tabs.Children.Add(tab);
            }
            
            App.MainTab.Activation();
        }

        private void OnTabActivated(TabControl.TabEventArgs tab)
        {
            foreach (var tabControl in App.list.TabList)
            {
                if (!tabControl.Equals(tab.Tab))
                {
                    tabControl.Deactivation();
                }
            }

            AnimeList.ItemsSource = tab.Tab.model.ListConnected.GetModels();
        }

        DateTime started = DateTime.Now;
        User user;
        private void TOnElapsed(object sender, ElapsedEventArgs e)
        {
            var time = (DateTime.Now - started);
            var minutes = Math.Floor(time.TotalMinutes);
            client.SetPresence(new RichPresence() {
                Details = $"{(user?.Username)} редактирует топ", 
                Buttons = new DiscordRPC.Button[] {new DiscordRPC.Button() {Label = "Быть в шоке", Url = "https://www.youtube.com/channel/UCUmlHoipYHuw057PCaVnGkg"}},
                State = $"{minutes} {MinuteStringFormat(Convert.ToInt32(minutes))}", 
                Timestamps = new Timestamps() {StartUnixMilliseconds = Convert.ToUInt64(((DateTimeOffset)started).ToUnixTimeMilliseconds())},
                Assets = new Assets()
                {
                    LargeImageKey = "anime_ico", LargeImageText = "AnimeList"
                }
                    
            });
        }

        private void AnimeListOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = AnimeList.SelectedItems;
            if (selected.Count >= 2)
            {
                //Edit.BorderThickness = new Thickness(0);
                Edit.BorderBrush = Brushes.Black;
                Edit.IsEnabled = false;
                

                //Remove.BorderThickness = new Thickness(1);
                Remove.BorderBrush = Brushes.White;
                Remove.IsEnabled = true;

                if (Grid.GetColumnSpan(AnimeList) == 2)
                {
                    Grid.SetColumnSpan(AnimeList, 3);
                    Editing.Opacity = 0;
                    Editing.Visibility = Visibility.Hidden;
                }
                
            }
            else if (selected.Count >= 1)
            {
                Edit.IsEnabled = true;
                //Edit.BorderThickness = new Thickness(1);
                Edit.BorderBrush = Brushes.White;

                //Remove.BorderThickness = new Thickness(1);
                Remove.BorderBrush = Brushes.White;
                Remove.IsEnabled = true;

                if (Grid.GetColumnSpan(AnimeList) == 2)
                {
                    ActualName.Text = ((AnimeModel) AnimeList.SelectedItem).Name;
                    ActualPlace.Text = ((AnimeModel) AnimeList.SelectedItem).Place.ToString();
                    ActualStatus.IsChecked = ((AnimeModel)AnimeList.SelectedItem).Status == AnimeModelStatus.Finished ? true : false;
                }
            }
            else
            {
                //Edit.BorderThickness = new Thickness(0);
                Edit.BorderBrush = Brushes.Black;
                Edit.IsEnabled = false;

                //Remove.BorderThickness = new Thickness(0);
                Remove.BorderBrush = Brushes.Black;
                Remove.IsEnabled = false;

                if (Grid.GetColumnSpan(AnimeList) == 2)
                {
                    Grid.SetColumnSpan(AnimeList, 3);
                    Editing.Opacity = 0;
                    Editing.Visibility = Visibility.Hidden;
                }
                
            }
            
        }

        private void RemoveButton(object sender, RoutedEventArgs e)
        {
            Models.AnimeList list = App.list.GetActive().model.ListConnected;
            var selected = AnimeList.SelectedItems;
            if (selected.Count >= 1)
            {
                foreach (var model in selected)
                {
                    var place = (model as AnimeModel)?.Place;
                    if (place != null)
                        list.RemoveModel(place.Value);
                }

                AnimeList.ItemsSource = list.GetModels();
            }

            AnimeList.Focus();
            list.SaveChanges();

        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            App.window = new AddWindow();
            App.window.Closed += WindowOnClosed;
            App.window.Show();
        }

        private void WindowOnClosed(object sender, EventArgs e)
        {
            Models.AnimeList list = App.list.GetActive().model.ListConnected;
            AnimeList.ItemsSource = list.GetModels();
        }

        private void CopyButton(object sender, RoutedEventArgs e)
        {

            var list = App.list.GetActive().model.ListConnected.GetModels();
            string inProc = " [В процессе]";
            Clipboard.SetText(String.Join("\n", list.Select(x => $"{x.Place}. {x.Name}{(x.Status == AnimeModelStatus.InProcess ? inProc : String.Empty)}")));

            CopiedMark.SetValue(Canvas.MarginProperty, new Thickness(0, 0, 0, 0));
            var point = Mouse.GetPosition(this); 
            point.Y += 40; 

            Storyboard appearStoryboard = (Storyboard)Resources["AppearStoryboard"];
            Storyboard disappearStoryboard = (Storyboard)Resources["DisappearStoryboard"];

            CopiedMark.BeginAnimation(OpacityProperty, null); 
            CopiedMark.Opacity = 0; 
            CopiedMark.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

            CopiedMark.Visibility = Visibility.Visible;

            var left = point.X - CopiedMark.DesiredSize.Width/2;
            var top = point.Y - CopiedMark.DesiredSize.Height;
            CopiedMark.SetValue(Canvas.MarginProperty, new Thickness(left, top, 0, 0));

            disappearStoryboard.Completed += (sender, e) =>
            {
                CopiedMark.Visibility = Visibility.Hidden;
            };

            appearStoryboard.Begin(CopiedMark);
            disappearStoryboard.Begin(CopiedMark);
        }

        private void ExportClick(object sender, RoutedEventArgs e)
        {
            var list = App.list.GetActive().model.ListConnected;
            var open = new SaveFileDialog();
            var path = Path.Combine(Environment.CurrentDirectory, @"Exports\");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            open.InitialDirectory = Path.Combine(path);
            open.Filter = "Anime List exports (.al)|*.al";
            open.DefaultExt = ".al";
            open.FileName = "export.al";
            
            var result = open.ShowDialog();

            if (result.HasValue && result.Value)
            {
                string filename = open.FileName;
                if (filename == "") return;
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                var name = JsonSerializer.Serialize(list, options);

                ALCipher.WriteCipher(filename, new ALCipher.Cipher() {Name = "export", EncryptionText = name});
            }
            list.SaveChanges();
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (Grid.GetColumnSpan(AnimeList) == 2)
            {
                Grid.SetColumnSpan(AnimeList, 3);
                Editing.Visibility = Visibility.Hidden;
                Editing.Opacity = 0;
            }
            else if (AnimeList.SelectedItems.Count == 1)
            {
                Grid.SetColumnSpan(AnimeList, 2);
                Editing.Visibility = Visibility.Visible;
                Editing.Opacity = 1;

                var selected = ((AnimeModel)AnimeList.SelectedItem);
                ActualName.Text = selected.Name;
                ActualPlace.Text = selected.Place.ToString();
                ActualStatus.IsChecked = selected.Status == AnimeModelStatus.Finished ? true : false;
            }
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            var list = App.list.GetActive().model.ListConnected;
            if (String.IsNullOrWhiteSpace(ActualPlace.Text))
            {
                MessageBox.Show("Не введено место", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }

            if (String.IsNullOrWhiteSpace(ActualName.Text))
            {
                MessageBox.Show("Не введено название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }


            var value = ActualStatus.IsChecked.Value;
            var current = ((AnimeModel)AnimeList.SelectedItem);
            if (int.TryParse(ActualPlace.Text, out int place))
            {
                var oldPlace = Convert.ToInt32(current.Place.ToString());
                var oldName = current.Name.ToString();
                var oldStatus = Convert.ToInt32(current.Status);
                if (current.Place == place)
                {
                    var item = list.AL[
                        list.GetModels().FindIndex(x => x.Place == current.Place)];
                    item.Name = ActualName.Text;
                    item.Status = ActualStatus.IsChecked.Value == false ? AnimeModelStatus.InProcess : AnimeModelStatus.Finished;
                    list.SaveChanges();
                }
                else
                {
                    list.RemoveModel(current.Place, true);
                    current = new AnimeModel(place, ActualName.Text, value == false ? AnimeModelStatus.InProcess : AnimeModelStatus.Finished);
                    if (current.Place > list.GetModels().Count) current.Place = list.GetModels().Count + 1;
                    list.AddModel(current, true);
                    list.SaveChanges();
                }



                var hsmodel = list.CreateHistoryModel();

                hsmodel.AddAction(new EditAction()
                {
                    NameA = oldName,
                    NameB = ActualName.Text,
                    PlaceA = oldPlace,
                    PlaceB = place,
                    WatchingA = oldStatus == 1 ? AnimeModelStatus.InProcess : AnimeModelStatus.Finished,
                    WatchingB = value == false ? AnimeModelStatus.InProcess : AnimeModelStatus.Finished,
                    AModel = current,
                    AnimeList = list
                }) ;

                AnimeList.ItemsSource = list.GetModels();
                AnimeList.ScrollIntoView(current);
                AnimeList.SelectedItem = current;
                Grid.SetColumnSpan(AnimeList, 3);
                Editing.Opacity = 0;
                Editing.Visibility = Visibility.Hidden;

            }

        }

        private void AddTab(object sender, RoutedEventArgs e)
        {
            var choose = new AddTabChooseWindow();
            choose.ShowDialog();
            RefreshTabs();
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            App.timer.Stop();
            App.timer = null;
        }

        private void CheckBoxMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ParentCheckBox.BorderBrush = Brushes.White;
        }

        private void CheckBoxMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ParentCheckBox.BorderBrush = Brushes.Transparent;
        }

        private void VersionMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowVersionReport();
        }

        public void ShowVersionReport()
        {

            UnderstoodButton.IsEnabled = true;
            Storyboard appearStoryboard = (Storyboard)Resources["AppearBoard"];

            NewContentPanel.BeginAnimation(OpacityProperty, null);
            NewContentPanel.Opacity = 0;


            appearStoryboard.Begin(NewContentPanel);

            NewContentPanel.Visibility = Visibility.Visible;
        }

        private void UnderstoodClick(object sender, RoutedEventArgs e)
        {
            UnderstoodButton.IsEnabled = false;
            Storyboard disappearStoryboard = (Storyboard)Resources["DisappearBoard"];

            NewContentPanel.BeginAnimation(OpacityProperty, null);
            NewContentPanel.Opacity = 1; 


            disappearStoryboard.Completed += (sender, e) => 
                NewContentPanel.Visibility = Visibility.Hidden;
            disappearStoryboard.Begin(NewContentPanel);
        }

        private void BackButtonOnWiFiPanelClicked(object sender, MouseButtonEventArgs e)
        {
            CloseWiFiPanel();
        }

        public void CloseWiFiPanel()
        {
            ThicknessAnimation animation = new ThicknessAnimation();
            animation.Duration = TimeSpan.FromSeconds(0.7);
            animation.To = new Thickness(30, -2000, 30, 30); // Начальное положение за пределами окна
            animation.From = new Thickness(30); // Конечное положение - без отступов


            ExponentialEase easingFunction = new ExponentialEase();
            easingFunction.EasingMode = EasingMode.EaseIn;
            animation.EasingFunction = easingFunction;
            // Применяем анимацию к свойству Margin
            helper.Dispose();
            Synchronize.BeginAnimation(Border.MarginProperty, animation);
        }

        public TcpHelper helper;

        private async void WiFiSyncronizeButtonClicked()
        {

            ThicknessAnimation animation = new ThicknessAnimation();
            animation.Duration = TimeSpan.FromSeconds(0.7);
            animation.From = new Thickness(30, -2000, 30, 30); // Начальное положение за пределами окна
            animation.To = new Thickness(30); // Конечное положение - без отступов

            ExponentialEase easingFunction = new ExponentialEase();
            easingFunction.EasingMode = EasingMode.EaseOut;
            animation.EasingFunction = easingFunction;
            // Применяем анимацию к свойству Margin
            Synchronize.BeginAnimation(Border.MarginProperty, animation);

            helper = new TcpHelper();
            helper.OnError += (mes) =>
            {
                Dispatcher.Invoke(() => 
                { 
                    MessageBox.Show(mes); 
                    CloseWiFiPanel();
                });
            };
            helper.Start();
            var code = helper.ReturnCode();
            LocalWifiCode.Text = code;

            if (code == "Нет сети") return;
            helper.OnAccepted += AcceptedClient;
            helper.OnConnected += ConnectedClient;

            await helper.StartWaiting();
        }
        private async void ConnectedClient(System.Net.Sockets.TcpClient client)
        {
            var gotList = await helper.ReadIncomingAsync();
            App.list.GetActive().model.ListConnected.AL = gotList.AL;
            App.list.GetActive().model.ListConnected.SaveChanges();
            AnimeList.ItemsSource = gotList.GetModels();
            CloseWiFiPanel();
        }

        private async void AcceptedClient(System.Net.Sockets.TcpClient clientConnected)
        {
            Models.AnimeList list = App.list.GetActive().model.ListConnected;
            await helper.SendAnimeList(clientConnected, list);
            CloseWiFiPanel();
        }

        private async void EnteredWiFiCode(object sender, RoutedEventArgs e)
        {
            if (WiFiCodeEntering.Text == LocalWifiCode.Text)
                return;
            if (string.IsNullOrWhiteSpace(WiFiCodeEntering.Text))
                return;
            if(helper != null)
            {
                await helper.Connect(WiFiCodeEntering.Text);
            }
        }

        private void WindowKeyDownPreview(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Keyboard.IsKeyDown(Key.Z))
                {
                    var history = App.historyList.HList.FirstOrDefault(x => x.Tab == App.list.GetActive());

                    if (history != null)
                    {
                        if (Keyboard.IsKeyDown(Key.LeftShift))
                        {
                            history.GoForward();

                        }
                        else
                        {
                            history.GoBack();

                        }
                    }

                    AnimeList.ItemsSource = App.list.GetActive().model.ListConnected.GetModels();
                }
            }
        }

        private void ExtraButtonMouseClicked(object sender, RoutedEventArgs e)
        {
            ContextMenu contextMenu = ExtraButton.ContextMenu;
            if (contextMenu != null && contextMenu.IsOpen == false)
            {
                contextMenu.PlacementTarget = ExtraButton;
                contextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                contextMenu.IsOpen = true;
            }
        }

        private void ExtraButtonMouseLeave(object sender, MouseEventArgs e)
        {
            ContextMenu contextMenu = ExtraButton.ContextMenu;
            if (contextMenu != null && contextMenu.IsOpen == true)
            {
                if (!contextMenu.IsMouseOver)
                {
                    contextMenu.IsOpen = false;
                }
            }
        }

        private void ElementInExtraClicked(object sender, RoutedEventArgs e)
        {
            var parent = (((System.Windows.Controls.Button)sender).TemplatedParent as MenuItem).Parent;
            var tag = Convert.ToInt32(((System.Windows.Controls.Button)sender).Tag);
            (parent as ContextMenu).IsOpen = false;
            if (tag == 1)
                WiFiSyncronizeButtonClicked();
            else if(tag == 2)
            {
                var window = new ChangeLanguageWindow();
                window.ShowDialog();
            }
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {

        }
    }

}