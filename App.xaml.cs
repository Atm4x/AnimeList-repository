﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Timers;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
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
        public static int CurrentThemeId;

        public delegate void LanguageUpdate(LanguageModel model);
        public static event LanguageUpdate LanguageUpdated;

        public static LanguageModel CurrentLanguage { get; private set; }
        public static List<LanguageModel> Languages { get; set; }

        public static void ChangeLanguage(LanguageModel model)
        {
            CurrentLanguage = model;
            LanguageUpdated?.Invoke(CurrentLanguage);
            ColorSchemeModel.SetupColors();
        }
        public static void ChangeFont(FontFamily font)
        {
            Console.WriteLine(font.Source);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ExectutionPath = Directory.GetParent(Assembly.GetEntryAssembly().Location).FullName;
            historyList = new HistoryList();

            CheckUpdates();

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

