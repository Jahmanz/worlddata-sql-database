using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorldData.Models;

namespace WorldData.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
        List<City> newCitys = City.GetAll();
        return View(newCitys);
        }



    }
}
