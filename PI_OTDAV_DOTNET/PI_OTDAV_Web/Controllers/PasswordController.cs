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
    public class PasswordController : Controller
    {
        // GET: Password
        public ActionResult Index()
        {
            return View();
        }

        // GET: Password/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Password/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Password/Create
        [HttpPost]
        public ActionResult Create(MailModel mail)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("PI_OTDAV_4GL5B-web/api/user/mail/" + mail.spec).Result;
            

              
                    return Redirect("/Login/Login");
                
           
        }

        // GET: Password/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Password/Edit/5
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

        // GET: Password/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Password/Delete/5
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
