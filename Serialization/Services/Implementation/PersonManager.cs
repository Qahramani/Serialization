
using AutoMapper;
using Serialization.Dtos.ResponseDto;
using Serialization.Exceptions;

namespace Serialization.Services.Implementation;

public class PersonManager : IPersonService
{
    private readonly ISerializerService<Person> _serializerService;
    private readonly IWebHostEnvironment _environment;
    private string PATH;
    private readonly IMapper _mapper;

    public PersonManager(ISerializerService<Person> serializerService, IWebHostEnvironment environment, IMapper mapper)
    {
        _serializerService = serializerService;
        _environment = environment;
        PATH = Path.Combine(_environment.WebRootPath, "documents", "people.txt");
        _mapper = mapper;
    }

    public List<PersonGetDto> GetAll()
    {
        var people = _serializerService.ReadFromFile(PATH);

        var dtos = _mapper.Map<List<PersonGetDto>>(people);

        return dtos;
    }
    public PersonGetDto GetById(int id)
    {
        var people = _serializerService.ReadFromFile(PATH);

        var person = people.FirstOrDefault(x => x.Id == id);

        if (person == null) throw new NotFoundException("Not found");

        var dto = _mapper.Map<PersonGetDto>(person);

        return dto;
    }

    public ResultDto Delete(int id)
    {
        var people = _serializerService.ReadFromFile(PATH);

        var person = people.FirstOrDefault(x => x.Id == id);

        if (person == null) throw new NotFoundException("Not found");

        people.Remove(person);

        _serializerService.WriteToFile(people, PATH);

        return new ResultDto("Successfully deleted");
    }

    public ResultDto Add(PersonPostDto dto)
    {
        var people = _serializerService.ReadFromFile(PATH);

         var person = _mapper.Map<Person>(dto);


        people.Add(person);

        _serializerService.WriteToFile(people, PATH);

        return new ResultDto("Successfully added");
    }

    public ResultDto Update(PersonPutDto dto)
    {
        var people = _serializerService.ReadFromFile(PATH);

        var foundPerson = people.FirstOrDefault(x => x.Id == dto.Id);

        if (foundPerson == null) throw new NotFoundException("Not Found");

        foundPerson = _mapper.Map(dto, foundPerson);

        _serializerService.WriteToFile(people,PATH);

        return new ResultDto("Successfully updated");
    }
}
