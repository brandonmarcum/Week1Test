using Xunit;
using ContactApp.Library.Models;
using ContactApp.Library;
using System.Collections.Generic;
using System.Linq;

namespace ContactApp.Tests
{
  public class Helper
  {
    public Person p;

    public Helper()
    {
      p = new Person();
    }

    [Fact]
    public void Test_ContactHelper_Add_Positive()
    {
      // arrange
      var ch = new ContactHelper<Person>();
      //var expected =  1;

      // act
      var actual = ch.Add(new Person());
      //var actual = ch.Read();

      // assert
      Assert.True(actual);
    }

    [Fact]
    public void Test_ContactHelper_Add_Negative()
    {
      // arrange
      var ch = new ContactHelper<Person>();

      // act
      var actual = ch.Add(new Person());

      // assert
      Assert.False(!actual);
    }

    [Fact]
    public void Test_ContactHelper_Read()
    {
      var ch = new ContactHelper<Person>();
      var expected = 0;

      var actual = ch.Read();

      Assert.True(actual.GetType() == typeof(List<Person>));
      Assert.NotNull(actual);
      Assert.True(actual.Count >= expected);
    }

    [Fact]
    //[Theory]
    //[InlineData(typeof(Person))]
    public void Test_ContactHelper_AddPerson()
    {
      var ch = new ContactHelper<Person>();
      var expected = new Name();

      ch.Add(p);
      var actual = ch.Read().Last();

      Assert.True(expected.First == actual.Name.First);
      Assert.True(expected.Last == actual.Name.Last);
    }
  }
}