using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Media;
using AnimeList.Helpers;

namespace AnimeList.Models
{
    public class AnimeListConfig
    {
        [JsonInclude]
        public List<Config> Configs;

        public int ThemeId { get; set; }
        
        public AnimeListConfig()
        {
            Configs = new List<Config>();
            ThemeId = 1;
        }

        public Config FindConfig(AnimeList list)
        {
            return Configs.FirstOrDefault(x => x.List.Equals(list));
        }

        public void AddConfig(Config config)
        {
            Configs.Add(config);
            ConfigCipher.WriteConfigCipher();
        }
        
        public class Config
        {
            [JsonIgnore]
            public AnimeList List;
            
            [JsonInclude]
            public string Path;
            
            [JsonInclude]
            public string Name;

            public Config(AnimeList list, string path, string name)
            {
                List = list;
                Path = path;
                Name = name;
            }

            /// <summary>
            /// Возвращает Config - если исполняемый файл не найден. Null - если файл найден. Параллельно присваивает Config значение List.
            /// </summary>
            /// <returns></returns>
            public bool RestoreConfig(out Config conf)
            {
                if (File.Exists(Path))
                {
                    try
                    {
                        ALCipher.Cipher cipher = ALCipher.ReadCipher(Path);
                        var animelist = JsonSerializer.Deserialize<Models.AnimeList>(cipher.EncryptionText,
                            new JsonSerializerOptions()
                            {
                                PropertyNameCaseInsensitive = false,
                                IncludeFields = true
                            });
                        List = animelist;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        conf = this;
                        return true;
                    }

                    conf = null;
                    return false;
                } 
                conf = this;
                return true;
            }
        }
    }
}