using BookingHotelWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace BookingHotelWEB.Controllers
{
    public class HomeController : Controller
    {


        string Baseurl = "https://localhost:44344/";
        
        public ActionResult Index()
        {
            IEnumerable<Branche> branche = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //HTTP GET
                var responseTask = client.GetAsync("api/Branche");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Branche>>();
                    readTask.Wait();

                    branche = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    branche = Enumerable.Empty<Branche>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(branche);

        }

        public ActionResult Create(Branche branche)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Branche>("api/Branche", branche);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(branche);
        }
        public ActionResult Edit(int id , Branche branche)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //HTTP GET
                var responseTask = client.GetAsync("api/Branche/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Branche>();
                    readTask.Wait();

                    branche = readTask.Result;
                    return View(branche);
                }
            }
            return View(branche);
        }

        public ActionResult Delete(int id , Branche branche)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("api/Branche/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return View(branche);
                }
            }
            return View(branche);
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