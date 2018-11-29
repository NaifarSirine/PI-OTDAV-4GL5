using PI_OTDAV_Domain.Entities;
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
    public class ProgrammeController : Controller
    {
        // GET: Programme
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/PI_OTDAV_4GL5B-web/api/Programme").Result;

            ViewBag.result = response.Content.ReadAsAsync<IEnumerable<programme>>().Result;


            return View();
        }


        // GET: Programme/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Programme/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View("Create");

        }

        // POST: Programme/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(programme prog)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.PostAsJsonAsync<programme>("http://localhost:18080/PI_OTDAV_4GL5B-web/api/Programme/add", prog).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Index");
        }



        public async System.Threading.Tasks.Task<ActionResult> Delete(string id)
        {
            HttpClient Client = new System.Net.Http.HttpClient();
            HttpResponseMessage response = await Client.DeleteAsync(
                $"http://localhost:18080/PI_OTDAV_4GL5B-web/api/Programme/{id}");
            return RedirectToAction("AffichageCandidat");
        }



        // GET: Programme/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Programme/Edit/5
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

      
        }
    }
