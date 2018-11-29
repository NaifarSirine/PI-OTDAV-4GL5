using PI_OTDAV_Domain.Entities;
using PI_OTDAV_Services.Services;
using PI_OTDAV_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace PI_OTDAV_Web.Controllers
{
    public class NotificationController : Controller
    {
        public NotificationServices ns = new NotificationServices();
        // GET: Notification
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public void Create(Notification n, int idUser)
        {

            try
            {
                Models.User u = new Models.User();
                u.id = 1;
                n.destination = u;
                Models.User u2 = new Models.User();
                u2.id = idUser;
                n.user = u2;
                n.dateNotification = null;
                Console.WriteLine(n);
                HttpClient Client = new HttpClient();
                HttpResponseMessage response = Client.PostAsJsonAsync<Notification>("http://localhost:18080/PI_OTDAV_4GL5B-web/api/notifications/add", n).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;
            }
            catch
            {

            }
        }

        [HttpGet]
        public ActionResult DisplayNonLu(int idDestination)
        {
            var uriString2 = string.Format("{0}{1}", "/PI_OTDAV_4GL5B-web/api/notifications/totalNonLu?idDestination=", idDestination);
            HttpClient Client2 = new HttpClient();
            Client2.BaseAddress = new Uri("http://localhost:18080");
            Client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response2 = Client2.GetAsync(uriString2).Result;
            if (response2.IsSuccessStatusCode)
            {
                ViewBag.count1 = response2.Content.ReadAsAsync<int>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            var uriString3 = string.Format("{0}{1}", "/PI_OTDAV_4GL5B-web/api/notifications/total?idDestination=", idDestination);
            HttpClient Client3 = new HttpClient();
            Client3.BaseAddress = new Uri("http://localhost:18080");
            Client3.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response3 = Client3.GetAsync(uriString3).Result;
            if (response3.IsSuccessStatusCode)
            {
                ViewBag.count3 = response3.Content.ReadAsAsync<int>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            var uriString = string.Format("{0}{1}", "/PI_OTDAV_4GL5B-web/api/notifications/displayNonLu?idDestination=", idDestination);
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync(uriString).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Notification>>().Result;
                if (ViewBag.result!=null)
                {
                    foreach(Notification n in ViewBag.result)
                    {
                        ns.UpdateEtatNotification(n.idNotification);
                    }
                }
            }
            else
            {
                ViewBag.result = "error";
            }
            

            return View("DisplayNonLu");
        }
        [HttpGet]
        public ActionResult DisplayLu(int idDestination)
        {
            var uriString = string.Format("{0}{1}", "/PI_OTDAV_4GL5B-web/api/notifications/displayLu?idDestination=", idDestination);
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync(uriString).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Notification>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            var uriString2 = string.Format("{0}{1}", "/PI_OTDAV_4GL5B-web/api/notifications/totalLu?idDestination=", idDestination);
            HttpClient Client2 = new HttpClient();
            Client2.BaseAddress = new Uri("http://localhost:18080");
            Client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response2 = Client2.GetAsync(uriString2).Result;
            if (response2.IsSuccessStatusCode)
            {
                ViewBag.count1 = response2.Content.ReadAsAsync<int>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            var uriString3 = string.Format("{0}{1}", "/PI_OTDAV_4GL5B-web/api/notifications/total?idDestination=", idDestination);
            HttpClient Client3 = new HttpClient();
            Client3.BaseAddress = new Uri("http://localhost:18080");
            Client3.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response3 = Client3.GetAsync(uriString3).Result;
            if (response3.IsSuccessStatusCode)
            {
                ViewBag.count3 = response3.Content.ReadAsAsync<int>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View("DisplayLu");
        }
        [HttpGet]
        public ActionResult DisplayHistorique(int idUser)
        {
            ViewBag.result = ns.GetHistorique(idUser);
            return View();
        }

    }
}
