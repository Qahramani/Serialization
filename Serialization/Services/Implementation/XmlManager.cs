using Serialization.Entities.Common;
using System.Xml.Serialization;

namespace Serialization.Services.Implementation;

public class XmlManager<T> : IXmlService<T> where T : BaseEntity
{
    private readonly XmlSerializer _xmlSerializer;

    public XmlManager()
    {
        _xmlSerializer = new XmlSerializer(typeof(List<T>));
    }

    public List<T> ReadFromFile(string filePath)
    {
        if(!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
        {
            return new List<T>();
        }

        using(StreamReader reader = new StreamReader(filePath))
        {
            var data = (List<T>)_xmlSerializer.Deserialize(reader);

            return data ?? new();
        }
    }

    public void WriteToFile(List<T> data, string filePath)
    {
        using(StreamWriter writer = new StreamWriter(filePath))
        {
            _xmlSerializer.Serialize(writer, data);
        }
    }
}
