using System.Collections.Generic;
using AdventureWorks.Library.Models;
using System.Linq;
using AdventureWorks.Data;

namespace AdventureWorks.Client
{
  public class EfData
  {
    private PersonContext db = new PersonContext();
    private AWContext db2 = new AWContext();
    
    public List<Library.Models.Person> Read()
    {
      return db.Persons.ToList();
    }

    public List<Data.Person> ReadAW()
    {
      return db2.Person.ToList();
    }

    public bool Insert()
    {
      db.Persons.AddRange
      (
        new Library.Models.Person() { Name = new Name() { First = "fred", Last = "belotte"}},
        new Library.Models.Person() { Name = new Name() { First = "james", Last = "belotte"}},
        new Library.Models.Person() { Name = new Name() { First = "karl", Last = "belotte"}},
        new Library.Models.Person() { Name = new Name() { First = "marc", Last = "belotte"}},
        new Library.Models.Person() { Name = new Name() { First = "waldo", Last = "belotte"}}
      );

      return db.SaveChanges() != 0;
    }
  }
}
