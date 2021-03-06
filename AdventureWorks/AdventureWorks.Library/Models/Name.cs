using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.Library.Models
{
  public class Name
  {
    [Key]
    public int Id { get; set; }
    public string First { get; set; }
    public string Last { get; set; }

    public override string ToString()
    {
      return $"{First} {Last}";
    }
  }
}
