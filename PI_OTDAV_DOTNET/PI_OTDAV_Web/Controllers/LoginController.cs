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
    public class LoginController : Controller
    {
        NotificationServices ns = new NotificationServices();
        // GET: User
        public ActionResult Login(string username, string password)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("PI_OTDAV_4GL5B-web/api/user/" + username + "/" + password).Result;
            if (response.IsSuccessStatusCode)
            {

                ViewBag.result = response.Content.ReadAsAsync<User>().Result;

                if (ViewBag.result != null)
                {
                   
                    if (ViewBag.result.accountType == "ADMINISTRATEUR") {
                        return View("Admin");
                    }
                    else if ((ViewBag.result.accountType == "DEPOSITOR" ||
                        ViewBag.result.accountType == "MEMBER") &&
                        ViewBag.result.accountStatuts == "ACTIF")
                    {
                        Session["id"] = ViewBag.result.id;
                        Session["nom"] = ViewBag.result.firstName;
                        Session["prenom"] = ViewBag.result.lastName;
                        Session["userName"] = ViewBag.result.userName;
                        Session["nbNotif"] = ns.GetNbNotif(ViewBag.result.id);
                        return View("Dashbord");
                    }
                    else if ((ViewBag.result.accountType == "DEPOSITOR" ||
                            ViewBag.result.accountType == "MEMBER")
                            && ViewBag.result.accountStatuts == "BANNED")
                    {
                        return View("Banned");
                    }
                    else if (ViewBag.result.accountType == "MEMBER"
                            && ViewBag.result.accountStatuts == "WAIT")
                    {
                        return View("Wait");
                    }

                }
                else if (ViewBag.result == null)

                {
                    ViewBag.NotValidUser = "username ou mot de passe sont inccorecte";

                }
                else
                {
                    ViewBag.Failedcount -= 1;
                }

            }
            else
            {
                ViewBag.result = "Error";
            }
            return View("login");
        }

        // GET: Login/Details/5
        public ActionResult GoHome(int id)
        {
            return View("Login");
        }


        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
