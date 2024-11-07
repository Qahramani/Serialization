using Serialization.Dtos;
using Serialization.Dtos.ResponseDto;
using Serialization.Entities;

namespace Serialization.Services.Abstraction;

public interface IPersonService
{
    PersonGetDto GetById(int id);
    List<PersonGetDto> GetAll();

    ResultDto Add(PersonPostDto dto);
    ResultDto Update(PersonPutDto dto);
    ResultDto Delete(int id);
}
