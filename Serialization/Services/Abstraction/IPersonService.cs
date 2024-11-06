using Serialization.Entities;

namespace Serialization.Services.Abstraction;

public interface IPersonService
{
    Person GetById(int id);
    List<Person> GetAll();

    void Add(Person person);
    void Update(Person person);
    void Delete(int id);
}
