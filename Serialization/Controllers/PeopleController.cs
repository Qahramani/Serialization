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
    public IActionResult CreatePerson(PersonPostDto person)
    {
       var result = _personService.Add(person);

        return Ok(result);
    }
    [HttpPut]
    public IActionResult UpdatePerson(PersonPutDto person)
    {
       var result = _personService.Update(person);

        return Ok(result);
    }
    [HttpDelete("{id}")]
    public IActionResult DeletePerson(int id)
    {
       var result = _personService.Delete(id);

        return Ok(result);
    }
}
