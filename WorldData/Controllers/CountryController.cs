using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
using System.Collections.Generic;

namespace WorldData.Controllers
{
  public class CountryController : Controller
  {

    [HttpGet("/country")]
    public ActionResult Index()
    {
      List<CountryDB> myCountryDB= CountryDB.GetAll();
      return View(myCountryDB);
    }

  }
}
