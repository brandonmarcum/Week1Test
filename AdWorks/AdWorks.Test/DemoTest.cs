using Xunit;
using AdWorks.MVC.Models;

namespace AdWorks.Test
{
  public class DemoTest
  {
    [Fact]
    public void TestUp()
    {
      var sut = new PizzaViewModel();
      
      Assert.NotNull(sut.Sizes);
      Assert.NotNull(sut.Toppings);
    }
  }
}