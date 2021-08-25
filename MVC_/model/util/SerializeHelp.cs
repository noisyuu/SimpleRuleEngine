using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MVC_.model.util
{
    public class SerializeHelp
    {


        public bool serializeObjToXml(Object obj, string path)
        {
            XmlSerializer xmlSerializer;
            string content = string.Empty;
            if (obj != null)
            {
                xmlSerializer = new XmlSerializer(obj.GetType());
                //serialize
                using (StringWriter sw = new StringWriter())
                {
                    xmlSerializer.Serialize(sw, obj);
                    content = sw.ToString();
                    if (!string.IsNullOrEmpty(path))
                    {
                        if (File.Exists(path)) { File.Delete(path); }
                        File.AppendAllText(path, content);
                        return true;
                    }

                }
            }

            return false;
        }

        public object deserializeXml(string path, Type objectType)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            XmlSerializer xmlSerializer = new XmlSerializer(objectType);
            using (StreamReader xmlreader = new StreamReader(path))
            {
                return xmlSerializer.Deserialize(xmlreader);
            }
        }

    }
    
       
}
