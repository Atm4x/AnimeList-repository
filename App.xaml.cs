using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows;
using AnimeList.Controls;
using AnimeList.Helpers;
using AnimeList.Models;
using AnimeList.Windows;
using LanguageClassTest.Models;

namespace AnimeList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static ControlWindow controlWindow;
        public static string ExectutionPath = "";
        public static string Password;
        public static string Login;
        public static Models.TabModelList list = new();
        public static AnimeListConfig Configuration;
        public static TabControl MainTab;
        public static Timer timer;
        public static bool isUpdated = false;
        public static AddWindow window;
        public static VersionUpdate versionUpdate;
        public static HistoryList historyList;
        public static int CurrentThemeId = ColorSchemeModel.Themes[1].ID;

        public delegate void LanguageUpdate(LanguageModel model);
        public static event LanguageUpdate LanguageUpdated;

        public static LanguageModel CurrentLanguage { get; private set; }
        public static List<LanguageModel> Languages { get; set; }

        public static void ChangeLanguage(LanguageModel model)
        {
            CurrentLanguage = model;
            LanguageUpdated?.Invoke(CurrentLanguage);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ExectutionPath = Environment.CurrentDirectory;
            historyList = new HistoryList();

            CheckUpdates();

            ColorSchemeModel.ChangeTheme(CurrentThemeId);

            if (e.Args != default && e.Args.Length > 0)
            {
                this.Properties["ArbitraryArgName"] = e.Args[0];
            }


            var xmlPath = Path.Combine(ExectutionPath, "report.xaml");
            if (File.Exists(xmlPath))
            {
                var updateReport = XmlConverter.FromXml<UpdateReport>(xmlPath);
                versionUpdate = updateReport.VersionUpdate;
            } else
            {
                File.Create(xmlPath).Close();
                File.WriteAllText(xmlPath, XmlConverter.ToXaml(new UpdateReport()));
                var updateReport = XmlConverter.FromXml<UpdateReport>(File.ReadAllText(xmlPath));
                versionUpdate = updateReport.VersionUpdate;
            }

            DLLCleaner();
            base.OnStartup(e);
        }

        private void CheckUpdates()
        {
            try
            {
                if (File.Exists(Path.Combine(ExectutionPath, "_update_file_c.txt")))
                {
                    isUpdated = true;
                    File.Delete(Path.Combine(ExectutionPath, "_update_file_c.txt"));
                }
                var path = Path.Combine(ExectutionPath, "UpdateTopReserve");
                if (Directory.Exists(path))
                {
                    var pathFile = Path.Combine(path, "UpdateTop.exe");
                    if (File.Exists(pathFile))
                    {
                        var newFile = Path.Combine(ExectutionPath, "UpdateTop.exe");

                        File.Create(newFile).Close();
                        File.WriteAllBytes(newFile, File.ReadAllBytes(pathFile));
                        File.Delete(pathFile);
                        Directory.Delete(path);
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DLLCleaner()
        {
            var executionPath = Environment.CurrentDirectory;
            var dllsPath = Path.Combine(executionPath, "lib");
            if (!Directory.Exists(dllsPath))
                Directory.CreateDirectory(dllsPath);

            foreach (var dll in new DirectoryInfo(executionPath).GetFiles().Where(
                x => ((FileInfo)x).Extension == ".dll" || ((FileInfo)x).Extension == ".xml"))
            {
                dll.CopyTo(Path.Combine(dllsPath, dll.Name), true);
                File.Delete(dll.FullName);
            }
        }
    }
}



//{ "ForegroundColor", "#000"},                       {"ForegroundColor", "#fff"},                      
//{ "ForegroundWathcingColor", "#620f73"},            {"ForegroundWathcingColor", "#F0E68C"},
//{ "InputBoxColor", "#f4f4f4"},                      {"InputBoxColor", "#2c2c2c"},
//{ "ForegroundDisabledColor", "#999999"},            {"ForegroundDisabledColor", "#808080"},
//{ "BackgroundDarkerColor", "#e0e0e0"},              {"BackgroundDarkerColor", "#1e1e1e"},
//{ "BackgroundMoreDarkerColor", "#ffffff"},          {"BackgroundMoreDarkerColor", "#121212"},
//{ "BackgroundModelColor", "#fefefe"},               {"BackgroundModelColor", "#333333"},
//{ "MidColor", "#d6d6d6"},                           {"MidColor", "#2b2b2b"},
//{ "ButtonDisabledBackgroundColor", "#e0e0e0"},      {"ButtonDisabledBackgroundColor", "#1f1f1f"},
//{ "BackgroundColor", "#fefefe"},                    {"BackgroundColor", "#363636"},
//{ "ButtonSelectedBackgroundColor", "#ffffff"},      {"ButtonSelectedBackgroundColor", "#121212"},
//{ "ButtonEnabledBackgroundColor", "#f2f2f2"},       {"ButtonEnabledBackgroundColor", "#222222"},
//{ "BackgroundEditingColor", "#e6e6e6"},             {"BackgroundEditingColor", "#1a1a1a"},
//{ "BackgroundEditColor", "#fafafa"},                {"BackgroundEditColor", "#202020"},
//{ "TabActiveColor", "#f2f2f2"},                     {"TabActiveColor", "#3b3b3b"},
//{ "TabPassiveColor", "#c4c4c4"},                    {"TabPassiveColor", "#262626"},
//{ "BackgroundLightColor", "#d6d6d6"},               {"BackgroundLightColor", "#515151"},
//"ForegroundColor",
//"ForegroundWathcingColor",
//"ForegroundDisabledColor",
//"BackgroundDarkerColor",
//"BackgroundMoreDarkerColor",
//"BackgroundModelColor",
//"MidColor",
//"ButtonDisabledBackgroundColor",
//"BackgroundColor",
//"ButtonSelectedBackgroundColor",
//"ButtonEnabledBackgroundColor",
//"BackgroundEditingColor",
//"InputBoxColor",
//"BackgroundEditColor",

