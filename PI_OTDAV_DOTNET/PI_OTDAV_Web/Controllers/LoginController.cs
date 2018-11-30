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

                    if (ViewBag.result.accountType == "ADMINISTRATEUR")
                    {
                        return View("Admin");
                    }
                    else if ((ViewBag.result.accountType == "DEPOSITOR" ||
                        ViewBag.result.accountType == "MEMBER") &&
                        ViewBag.result.accountStatuts == "ACTIF")
                    {
                        Session["id"] = ViewBag.result.id;
                        Session["nom"] = ViewBag.result.firstName;
                        Session["prenom"] = ViewBag.result.lastName;
                        Session["user"] = ViewBag.result.userName;

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

        // GET: Login/GoHome
        public ActionResult GoHome()
        {
            return View("Login");
        }

        public ActionResult GoRegDep()
        {
            return Redirect("/Registration/create");
        }

        public ActionResult GoRegMem()
        {
            return Redirect("/RegistrationMember/create");
        }

        public ActionResult GoPassworRecover() {
            return Redirect("/Password/Create");
        }

        // POST: Login/GoRegDep
        public ActionResult Create()
        {
            return View();
        }



        // GET: Conge/Edit/5
        public ActionResult Edit(int id)
        {
            Models.User user = null;

            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/levio.esprit-web/rest/conge/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                user = response.Content.ReadAsAsync<User>().Result;

            }

            else
            {
                ViewBag.result = "error";
            }



            return View();
        }


        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                HttpClient Client = new HttpClient();
                HttpResponseMessage response = Client.PutAsJsonAsync<User>("http://localhost:18080/PI_OTDAV_4GL5B-web/api/user", user).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;

                if (response.IsSuccessStatusCode)
                    return View("Login");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // Get: User/Edit/5
   
        public ActionResult PasswordRecover()
        {
            return View();
        }


        [HttpPost]
        public ActionResult PasswordRecoverrrr(MailModel model)
        {

            return RedirectToAction("PasswordRecoverrrr"); 
        }




    } 

}
