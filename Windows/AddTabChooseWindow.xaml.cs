using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Controls;
using AnimeList.Controls;
using AnimeList.Helpers;
using AnimeList.Models;
using AnimeList.Services;
using LanguageClassTest.Models;
using Microsoft.Win32;

namespace AnimeList.Windows
{
    public partial class AddTabChooseWindow : Window
    {
        private LanguageModel.AddTabChooseWindowDialogMessages translates = null;
        public AddTabChooseWindow()
        {
            InitializeComponent();

            UIChangeLanguage(App.CurrentLanguage);
        }

        public void UIChangeLanguage(LanguageModel lang)
        {
            Title = lang.AddTabChooseWindowTitle.Value;
            translates = lang.AddTabWindowDialogTranslate;
            foreach (var translations in lang.Translate)
            {
                var buttonBlock = UIFinder.FindVisualChildren<System.Windows.Controls.Button>(WholePageGrid).FirstOrDefault(x => x.Name == translations.Name);
                if (buttonBlock != null)
                {
                    buttonBlock.Content = translations.Value;
                    continue;
                }

                var textBlock = UIFinder.FindVisualChildren<TextBlock>(WholePageGrid).FirstOrDefault(x => x.Name == translations.Name);
                if (textBlock != null)
                {
                    textBlock.Text = translations.Value;
                    continue;
                }
            }
        }
        private void ChooseClick(object sender, RoutedEventArgs e)
        {
            var open = new OpenFileDialog();
            open.InitialDirectory = Directory.GetCurrentDirectory();
            open.Filter = "Anime List exports (.al)|*.al";
            open.RestoreDirectory = true;
            open.DefaultExt = ".al";
            
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
                ALCipher.Cipher cipher = Helpers.ALCipher.ReadCipher(filename);
                var own = cipher.EncryptionText;
                var animelist = JsonSerializer.Deserialize<Models.AnimeList>(own,
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = false,
                        IncludeFields = true
                    });


                string name = "";
                if (cipher.Name == "export")
                    name = Path.GetFileNameWithoutExtension(filename);
                else name = cipher.Name;

                var existingOne = App.Configuration.Configs.FirstOrDefault(x => x.Path == filename);
                if (existingOne != null)
                {
                    MessageBox.Show(translates.ExistsMessage, translates.WarningMessage);
                    return;
                }
                var config = new AnimeListConfig.Config(animelist, filename, name);
                App.Configuration.AddConfig(config);
                ConfigCipher.WriteConfigCipher();
                App.list.TabList.Add(new Controls.TabControl(name, animelist));
            }
            Close();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            var open = new SaveFileDialog();
            open.Filter = "Anime List exports (.al)|*.al";
            open.RestoreDirectory = true;
            open.DefaultExt = ".al";
            open.RestoreDirectory = true;
            open.FileName = "export.al";
            
            
            var result = open.ShowDialog();
            if (result.HasValue && result.Value)
            {
                string filename = open.FileName;
                if (filename == "") return;

                var name = Path.GetFileNameWithoutExtension(filename);
                
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };

                var newList = new Models.AnimeList();
                var config = new AnimeListConfig.Config(newList, filename, name);
                ALCipher.WriteCipher(filename,
                    new ALCipher.Cipher()
                    {
                        Name = name, EncryptionText = JsonSerializer.Serialize(newList, options)
                    });
                
                App.Configuration.AddConfig(config);
                ConfigCipher.WriteConfigCipher();
                App.list.TabList.Add(new Controls.TabControl(name, newList));
            }
            Close();
        }
    }
}