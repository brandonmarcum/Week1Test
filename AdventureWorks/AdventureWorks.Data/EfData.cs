using System.Collections.Generic;
using AdventureWorks.Library.Models;
using System.Linq;

namespace AdventureWorks.Data
{
  public class EfData
  {
    private PersonContext db = new PersonContext();
    public List<Person> Read()
    {
      return db.Persons.ToList();
    }
  }
}