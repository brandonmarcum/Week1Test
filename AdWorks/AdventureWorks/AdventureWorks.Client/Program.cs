using System;

namespace AdventureWorks.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      var ed = new EfData();

      // if (ed.Insert())
      // {
      //   System.Console.WriteLine("it works");
      // }
      // else
      // {
      //   System.Console.WriteLine("noooooooo");
      // }

      foreach (var item in ed.ReadAW())
      {
        System.Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
      }
    }
  }
}
