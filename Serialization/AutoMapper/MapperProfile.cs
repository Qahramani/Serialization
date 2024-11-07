using AutoMapper;
namespace Serialization.AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Person, PersonGetDto>().ReverseMap();
        CreateMap<Person, PersonPostDto>().ReverseMap();
        CreateMap<Person, PersonPutDto>().ReverseMap();
    }
}
