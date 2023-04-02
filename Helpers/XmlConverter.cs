using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace AnimeList.Helpers
{
    public static class XmlConverter
    {
        public static string ToXaml<T>() where T : new()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            var subReq = new T();

            using (var strWriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(strWriter, new XmlWriterSettings()
                {
                    Indent = true
                }))
                {
                    serializer.Serialize(writer, subReq);
                    return strWriter.ToString();
                }
            }
        }
        public static T FromXml<T>(string xmlCodePath) where T : new()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(xmlCodePath))
            {
                return (T)serializer.Deserialize(reader);
            }

            return default;
        }
    }
}
