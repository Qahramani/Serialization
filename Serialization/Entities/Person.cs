using Serialization.Entities.Common;
using System.Xml.Serialization;

namespace Serialization.Entities;

public class Person : BaseEntity
{
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public int Age { get; set; }
}
