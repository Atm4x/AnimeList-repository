using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Media;
using AnimeList.Helpers;

namespace AnimeList.Models
{
    public class NameChangedEventArgs
    {
        public string OldName { get; set; }
        public string NewName { get; set; }
    }

    public class AnimeList
    {
        [JsonInclude]
        public List<AnimeModel> AL { get; private set; }  
        
        [NonSerialized]
        [JsonIgnore]
        private ALExceptions _alExceptions = new ALExceptions();
        
        public AnimeList()
        {
            AL = new List<AnimeModel>();
        }
        
        public AnimeList(List<AnimeModel> models)
        {
            var status = CheckStatus(models);
            if (status != SetStatus.OK)
            {
                ALExceptions.ThrowException(status);
            }
            AL = models ?? new List<AnimeModel>();
        }

        public void AddModel(AnimeModel model)
        {
            try
            {
                var config = App.Configuration.FindConfig(this);
                AL.Add(new AnimeModel(1, ""));
                //AL.Reverse();

                for (int y = AL.Count - 1; y > model.Place - 1; y--)
                {
                    var mod = new AnimeModel(AL[y - 1].Place + 1, AL[y - 1].Name);

                    AL[y] = mod;
                }

                if (AL.Count > model.Place)
                    AL[model.Place - 1] = model;
                else AL[AL.Count - 1] = model;

                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };

                SaveChanges();

            }
            catch
            {
                ALExceptions.ThrowException(SetStatus.InternalError);
            }
        }

        public void SaveChanges()
        {
            try
            {
                var config = App.Configuration.FindConfig(this);
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                
                if (config != null)
                {
                    ALCipher.WriteCipher(config.Path, new ALCipher.Cipher()
                        { Name = config.Name, EncryptionText = JsonSerializer.Serialize(this, options) }, false);
                }
                else
                {
                    ALCipher.WriteCipher(new ALCipher.Cipher()
                        { Name = "Default", EncryptionText = JsonSerializer.Serialize(this, options) });
                }

            }
            catch
            {
                ALExceptions.ThrowException(SetStatus.InternalError);
            }
        }
        public void RemoveModel(int place)
        {
            try
            {
                var config = App.Configuration.FindConfig(this);
                var toplist = AL.Where(x => x.Place > place).ToList();
                var bottomlist = AL.Where(x => x.Place < place).ToList();

                foreach (var item in toplist)
                {
                    item.Place -= 1;
                }

                bottomlist.AddRange(toplist);

                AL = bottomlist;

                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                SaveChanges();

            }
            catch
            {
                ALExceptions.ThrowException(SetStatus.InternalError);
            }
        }
        
        private SetStatus CheckStatus(List<AnimeModel> models)
        {
            try
            {
                foreach (var model in models.GroupBy(i => i.Place))
                {
                    if (model.Count() > 1)
                    {
                        return SetStatus.InvalidPlace;
                    }
                }
                return SetStatus.OK;
            }
            catch
            {
                return SetStatus.InternalError;
            }
        }
        
        
        public enum SetStatus
        {
            OK,
            InvalidPlace,
            InternalError
        }
        
        public List<AnimeModel> GetModels()
        {
            return AL.ToList();
        }
        
        public class ALExceptions
        {
            public class AException : Exception
            {
                public SetStatus Status;
                
                public AException(string message) 
                    : base(message)
                {
                }
            }
            
            private static List<AException> exceptions = new List<AException>();
            
            public class InvalidPlaceException : AException
            {
                 public InvalidPlaceException() : base("AList contains items with same place.")
                 {
                     Status = SetStatus.InvalidPlace;
                 }
            }
            public class InternalErrorException : AException
            {
                public InternalErrorException() : base("Internal Error has occurred while checking AList")
                {
                    Status = SetStatus.InternalError;
                }
            }

            public ALExceptions()
            {
                exceptions.Add(new InvalidPlaceException());
                exceptions.Add(new InternalErrorException());
            }
            
            public static void ThrowException(SetStatus status)
            {
                throw exceptions.Find(x => x.Status == status);
            }
        }    
    }


    public class AnimeModel
    {

        [JsonConstructor]
        public AnimeModel(int place, string name)
        {
            Place = place;
            _Name = name;
        }

        public AnimeModel(int place, string name, AnimeModelStatus modelStatus = AnimeModelStatus.Finished)
        {
            Place = place;
            _Name = name;
            _Status = modelStatus;
        }


        public delegate void NameHandler(NameChangedEventArgs e);
        public event NameHandler NameChanged;

        [JsonIgnore]
        private string _Name;


        public int Place { get; set; }
        public string Name
        {
            get => _Name;
            set
            {
                NameChanged?.Invoke(new NameChangedEventArgs() { OldName = _Name.ToString(), NewName = value });
                _Name = value;
            }
        }

        [JsonIgnore]
        private AnimeModelStatus _Status;
        public AnimeModelStatus Status { get => _Status; set
            {
                Brush = value == AnimeModelStatus.Finished ? Brushes.White : Brushes.Khaki;
                _Status = value;
            } 
        }

        [JsonIgnore]
        public Visibility Watching { get => IsWatching(); }
        public Visibility IsWatching() => _Status != AnimeModelStatus.Finished ? Visibility.Visible : Visibility.Hidden;

        [JsonIgnore]
        public SolidColorBrush Brush { get; set; } = Brushes.White;


    }
}