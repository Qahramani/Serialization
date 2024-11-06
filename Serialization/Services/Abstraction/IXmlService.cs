using Serialization.Entities.Common;

namespace Serialization.Services.Abstraction;

public interface IXmlService<T> : ISerializerService<T> where T : BaseEntity
{
}
