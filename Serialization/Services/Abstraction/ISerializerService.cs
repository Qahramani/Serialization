using Serialization.Entities.Common;

namespace Serialization.Services.Abstraction;

public interface ISerializerService<T> where  T : BaseEntity
{
    void WriteToFile(List<T> data, string filePath);
    List<T> ReadFromFile(string filePath);
}

