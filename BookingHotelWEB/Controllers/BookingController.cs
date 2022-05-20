using BookingHotelWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BookingHotelWEB.Controllers
{
    public class BookingController : Controller
    {

        string Baseurl = "https://localhost:44344/";

        public ActionResult Index()
        {
            IEnumerable<Booking> booking = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //HTTP GET
                var responseTask = client.GetAsync("api/Booking");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Booking>>();
                    readTask.Wait();

                    booking = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    booking = Enumerable.Empty<Booking>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(booking);

        }

        public ActionResult Create(Booking booking)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Booking>("api/Booking", booking);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(booking);
        }
        
        public ActionResult Edit(int id, Booking booking)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //HTTP GET
                var responseTask = client.GetAsync("api/Booking" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Booking>();
                    readTask.Wait();

                    booking = readTask.Result;
                    return View(booking);
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("api/Booking" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return View();
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}