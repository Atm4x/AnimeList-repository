using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using AnimeList.Models;

namespace AnimeList.Helpers
{
    public class ConfigCipher
    {
        public static string Encrypt(string text)
        {
            var byteText = Encoding.UTF8.GetBytes(text);
            var bytes = Convert.ToBase64String(byteText);
            return bytes;
        } 
        
        public static string Decrypt(string byteText)
        {
            var bytes = Convert.FromBase64String(byteText);
            return Encoding.UTF8.GetString(bytes);
        } 
        
        public static void WriteConfigCipher()
        {
            var encrypted = Encrypt(JsonSerializer.Serialize(App.Configuration));
            Assembly asm = Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(asm.Location);
            var directory = Path.Combine(path, "Configs.alc");
            
            if (!File.Exists(directory))
            {
                File.Create(directory).Close();
            }
            
            File.WriteAllText(directory, encrypted);
        }
        
        public static AnimeListConfig ReadConfigCipher()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(asm.Location);
            var directory = Path.Combine(path, "Configs.alc");
            
            if (File.Exists(directory))
            {
                var encrypted = Decrypt(File.ReadAllText(directory));
                var result = JsonSerializer.Deserialize<AnimeListConfig>(encrypted, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = false,
                    IncludeFields = true
                });
                App.Configuration = result;
                return result;
            }
                
            File.Create(directory).Close();
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            App.Configuration = new AnimeListConfig();
            WriteConfigCipher();
            return App.Configuration;
        }
    }
}