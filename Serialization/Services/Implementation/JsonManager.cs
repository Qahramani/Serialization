using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Serialization.Entities.Common;
using Serialization.Services.Abstraction;

namespace Serialization.Services.Implementation;

public class JsonManager<T> : IJsonService<T> where T : BaseEntity
{

    public List<T> ReadFromFile(string filePath)
    {
        using(StreamReader  reader = new StreamReader(filePath))
        {
            string data = reader.ReadToEnd();

            var result = JsonConvert.DeserializeObject<List<T>>(data);

            return result ?? new();
        }
    }

    public void WriteToFile(List<T> data , string filePath)
    {
        var json = JsonConvert.SerializeObject(data);

        using(StreamWriter writer = new StreamWriter(filePath))
        {
            writer.Write(json);
        }
    }
}
