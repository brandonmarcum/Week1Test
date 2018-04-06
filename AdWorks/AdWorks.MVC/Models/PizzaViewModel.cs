using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdWorks.MVC.Models
{
  public class PizzaViewModel
  {
    // [Required(Message = "the message")]
    // [Datatype(Datatype.Email)]
    // [StringLength]
    // [NameValidator(Message = "")]
    public string Name
    {
      get;
      set;
    }

    public string Size
    {
      get;
      set;
    }

    public List<string> ToppingList
    {
      get;
      set;
    }

    public Size Sizes
    {
      get;
      set;
    }

    public Topping Toppings
    {
      get;
      set;
    }

    public PizzaViewModel()
    {
      Name = "fred";
      Sizes = new Size();
      Toppings = new Topping();
    }
  }
}
