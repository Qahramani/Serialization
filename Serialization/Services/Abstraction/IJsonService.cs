using Serialization.Entities.Common;

namespace Serialization.Services.Abstraction;

public interface IJsonService<T> : ISerializerService<T> where T : BaseEntity
{
}
