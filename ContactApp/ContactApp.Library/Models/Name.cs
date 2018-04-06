namespace ContactApp.Library.Models
{
  public class Name
  {
    public string First { get; set; }
    public string Last { get; set; }

    public Name()
    {
      First = "fred";
      Last = "belotte";
    }

    public override string ToString()
    {
      return $"{First} {Last}";
    }
  }
}