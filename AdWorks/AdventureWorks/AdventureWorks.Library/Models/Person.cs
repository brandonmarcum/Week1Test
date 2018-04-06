using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.Library.Models
{
  public class Person
  {
    [Key]
    public int Id { get; set; }
    public Name Name { get; set; }

    public override string ToString()
    {
      return $"{Name}";
    }
  }
}
