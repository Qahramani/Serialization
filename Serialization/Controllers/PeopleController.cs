using Microsoft.AspNetCore.Mvc;

namespace Serialization.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PeopleController : ControllerBase
{
    private readonly IPersonService _personService;

    public PeopleController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var people = _personService.GetAll();
        return Ok(people);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var person = _personService.GetById(id);
        return Ok(person);
    }
    [HttpPost]
    public IActionResult CreatePerson(Person person)
    {
        _personService.Add(person);

        return Ok();
    }
    [HttpPut]
    public IActionResult UpdatePerson(Person person)
    {
        _personService.Update(person);

        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeletePerson(int id)
    {
        _personService.Delete(id);

        return Ok();
    }
}
