using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SystemForOrderingTickets.Services
{
    public class XMLReaderService
    {
        public virtual List<T> ReadXMLFile<T>(string fileName)
        {
            var formatter = new XmlSerializer(typeof(List<T>));

            List<T> result = null;

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                result = (List<T>)formatter.Deserialize(fs);
            }

            return result;
        }
    }
}