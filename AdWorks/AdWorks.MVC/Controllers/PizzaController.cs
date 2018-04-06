using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdWorks.MVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdWorks.MVC.Controllers
{
  public class PizzaController : Controller
  {
    [HttpGet]
    public IActionResult Index()
    {
      return View(new PizzaViewModel());
    }

    //[HttpPost]
    //public IActionResult Index(int id)
    //{
    //  return View();
    //}

    [HttpPost]
    public IActionResult Index(PizzaViewModel model)
    {
      if (ModelState.IsValid)
      {

      }
      
      Session["Key"] = "Value";
      return View();
    }
  }
}
