using LanguageClassTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnimeList.Helpers
{
    public static class LanguagesHelper
    {
        public static void SaveDefaultLanguage()
        {
            var language = new LanguageModel();
            string path = Path.Combine(App.ExectutionPath, "Languages\\");
            if (!Directory.Exists(path)) 
                Directory.CreateDirectory(path);

            string filename = Path.Combine(path, $"language-model-{language.Code.Value}.llm");
            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
                File.WriteAllText(filename, XmlConverter.ToXaml(language));
            }

        }

        public static IEnumerable<LanguageModel> GetAllLanguagesModel()
        {
            string path = Path.Combine(App.ExectutionPath, "Languages\\");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var filenames = Directory.GetFiles(path);
            foreach (var filename in filenames.Where(file => file.EndsWith(".llm")))
            {
                yield return XmlConverter.FromXml<LanguageModel>(filename);
            }
        }
    }
}
