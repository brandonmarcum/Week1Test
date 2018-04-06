using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdWorks.MVC.Models;

namespace AdWorks.MVC.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      dynamic obj = "hello";
      obj = new { name = "fred" };
      obj = 10;

      ViewBag.Message = "banana";
      ViewData["Message"] = "minion";
      TempData["Message"] = "despicable";
      //return View();
      return RedirectToAction("About");
    }

    public IActionResult About()
    {
      //ViewData["Message"] = "Your application description page.";
      ViewBag.Message = "banana";
      //ViewData["Message"] = "minion";

      return View();
    }

    public IActionResult Contact()
    {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
