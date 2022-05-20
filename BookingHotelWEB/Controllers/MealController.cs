using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingHotelWEB.Controllers
{
    public class MealController : Controller
    {
        // GET: Meal
        public ActionResult Index()
        {
            return View();
        }
    }
}