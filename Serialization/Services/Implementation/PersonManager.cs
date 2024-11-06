
namespace Serialization.Services.Implementation;

public class PersonManager : IPersonService
{
    private readonly ISerializerService<Person> _serializerService;
    private readonly IWebHostEnvironment _environment;
    private string PATH;

    public PersonManager(ISerializerService<Person> serializerService, IWebHostEnvironment environment)
    {
        _serializerService = serializerService;
        _environment = environment;
        PATH = Path.Combine(_environment.WebRootPath, "documents", "people.txt");
    }   

    public List<Person> GetAll()
    {
        var people = _serializerService.ReadFromFile(PATH);

        return people;
    }
    public Person GetById(int id)
    {
        var people = _serializerService.ReadFromFile(PATH);

        var person = people.FirstOrDefault(x => x.Id == id);

        if (person == null) throw new Exception("Not found");

        return person;
    }

    public void Delete(int id)
    {
        var people = _serializerService.ReadFromFile(PATH);

        var person = people.FirstOrDefault(x => x.Id == id);

        if (person == null) throw new Exception("Not found");

        people.Remove(person);

        _serializerService.WriteToFile(people, PATH);
    }

    public void Add(Person person)
    {
        var people = _serializerService.ReadFromFile(PATH);

        people.Add(person);

        _serializerService.WriteToFile(people, PATH);
    }

    public void Update(Person person)
    {
        var people = _serializerService.ReadFromFile(PATH);

        var foundPerson = people.FirstOrDefault(x => x.Id == person.Id);

        if (foundPerson == null) throw new Exception("Not Found");

        foundPerson.Firstname = person.Firstname;
        foundPerson.Lastname = person.Lastname;
        foundPerson.Age = person.Age;

        _serializerService.WriteToFile(people,PATH);
    }
}
