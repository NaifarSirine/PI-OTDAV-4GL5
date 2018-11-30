using PI_OTDAV_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PI_OTDAV_Web.Controllers
{
    public class RegistrationMemberController : Controller
    {
        // GET: RegistrationMember
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistrationMember/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrationMember/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrationMember/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            user.accountType = "MEMBER";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.PostAsJsonAsync<User>("PI_OTDAV_4GL5B-web/api/user", user).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return Redirect("/Login/Login");
        }

        // GET: RegistrationMember/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrationMember/Edit/5
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

        // GET: RegistrationMember/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrationMember/Delete/5
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
