using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Windows;

namespace AnimeList.Helpers
{
    public static class ALCipher
    {
        public class Cipher
        {
            
            [JsonPropertyName("Type")]
            public string Name { get; set; }
            public string EncryptionText { get; set; }
        }

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
        
        public static void WriteCipher(Cipher text)
        {
            var encrypted = Encrypt(JsonSerializer.Serialize(text));
            Assembly asm = Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(asm.Location);
            var directory = Path.Combine(path, "Crypted.al");
            
            if (!File.Exists(directory))
            {
                File.Create(directory).Close();
            }
            
            File.WriteAllText(directory, encrypted);
        }
        
        public static void WriteCipher(string path, Cipher text, bool recreate = true)
        {
            var encrypted = Encrypt(JsonSerializer.Serialize(text));
            var directory = path;
            
            if (!File.Exists(directory))
            {
                if (recreate == true) 
                    File.Create(directory).Close();
                else
                {
                    MessageBox.Show("Файл топа был перемещён или удалён.", "Ошибка!");
                    App.controlWindow.RefreshTabs();
                    
                    return;
                }
            }
            
            File.WriteAllText(directory, encrypted);
        }
        
        public static Cipher ReadCipher(string filename)
        {
            var directory = filename;
            
            if (File.Exists(directory))
            {
                var encrypted = Decrypt(File.ReadAllText(directory));
                var text = JsonSerializer.Deserialize<Cipher>(encrypted);
                return text;
            }
            return null;
        }
        
        public static Cipher ReadCipher()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(asm.Location);
            var directory = Path.Combine(path, "Crypted.al");
            
            if (File.Exists(directory))
            {
                var encrypted = Decrypt(File.ReadAllText(directory));
                var text = JsonSerializer.Deserialize<Cipher>(encrypted);
                return text;
            }
                
            File.Create(directory).Close();
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            Cipher txt;
            if(App.list.TabList.Count > 0)
                 txt = new Cipher() {Name = "Default", EncryptionText = JsonSerializer.Serialize(App.list.GetActive().model.ListConnected, options)};
            else txt = new Cipher() {Name = "Default", EncryptionText = JsonSerializer.Serialize(new Models.AnimeList(), options)};
            WriteCipher(directory, txt);
            return txt;
        }
    }
}