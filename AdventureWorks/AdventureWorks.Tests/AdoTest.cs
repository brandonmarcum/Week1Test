using System.Collections.Generic;
using AdventureWorks.Data;
using AdventureWorks.Library.Models;
using Xunit;

namespace AdventureWorks.Tests
{
  public class AdoTest
  {
    [Fact]
    public void ReadConnected()
    {
      var ad = new AdoData();
      var expected = string.Empty;
      var actual = ad.ReadConnected();

      System.Console.WriteLine(actual);

      Assert.NotEqual(expected, actual);
      Assert.False(expected == actual);
    }

    [Fact]
    public void ReadDisconnected()
    {
      var ad = new AdoData();
      var expected = string.Empty;
      var actual = ad.ReadDisconnected();

      System.Console.WriteLine(actual);

      Assert.NotEqual(expected, actual);
      Assert.False(expected == actual);
    }

    [Fact]
    public void ReadConnected2()
    {
      var ad = new AdoData();
      var expected = new List<Person>();
      var actual = ad.ReadConnected2();

      foreach (var item in actual)
      {
        System.Console.WriteLine(item);
      }

      Assert.NotEqual(expected.Count, actual.Count);
      Assert.False(expected.Count == actual.Count);
    }
  }
}