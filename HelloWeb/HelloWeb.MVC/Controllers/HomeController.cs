using System;
using Microsoft.AspNetCore.Mvc;

namespace HelloWeb.MVC.Controllers
{
  [Route("/[controller]/[action]")]
  public class HomeController : Controller
  {
    [Route("/index")]
    public string Index()
    {
      return "hello MVC!";
    }
  }
}
