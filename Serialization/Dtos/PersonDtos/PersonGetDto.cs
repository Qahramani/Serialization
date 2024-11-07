using Serialization.Dtos.Common;

namespace Serialization.Dtos;

public class PersonGetDto : IDto
{
    public int Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public int Age { get; set; }
}

public class PersonPostDto : IDto
{
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public int Age { get; set; }
}

public class PersonPutDto : IDto
{
    public int Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public int Age { get; set; }
}
