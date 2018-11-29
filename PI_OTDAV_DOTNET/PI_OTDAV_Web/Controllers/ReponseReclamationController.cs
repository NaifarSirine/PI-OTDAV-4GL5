using PI_OTDAV_Domain.Entities;
using PI_OTDAV_Services.Services;
using PI_OTDAV_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;


namespace PI_OTDAV_Web.Controllers
{
    public class ReponseReclamationController : Controller
    {
        // GET: ReponseReclamation
        public ReclamationServices rs = new ReclamationServices();
        public NotificationController nc = new NotificationController();
        public UserServices us = new UserServices();
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(ReponseReclamation r, int idReclamation, int idUser)
        {

            try
            {
                Models.User u = new Models.User();
                u.id = idUser;
                r.user = u;
                r.dateReponse = null;
                Models.Reclamation rec = new Models.Reclamation();
                rec.idReclamation = idReclamation;
                rec.dateReclamation = null;
                r.reclamation = rec;

                Console.WriteLine(r);
                HttpClient Client = new HttpClient();
                HttpResponseMessage response = Client.PostAsJsonAsync<ReponseReclamation>("http://localhost:18080/PI_OTDAV_4GL5B-web/api/reponses/add", r).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;

                if (response.IsSuccessStatusCode)
                {
                    //Add Notif
                    reclamation rselc = rs.GetById(idReclamation);
                    user utilisateur = us.GetById(idUser);
                    Notification n = new Notification();
                    n.description = "L'utilisateur " + utilisateur.FirstName + " " + utilisateur.LastName + " a ajouté une réponse pour sa réclamation de type:" + rselc.type + ".";
                    n.type = "Réclamation";
                    nc.Create(n, idUser);
                    //End Add Notif
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Display(int idReclamation)
        {
            var uriString = string.Format("{0}{1}", "/PI_OTDAV_4GL5B-web/api/reponses/display?idReclamation=", idReclamation);


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync(uriString).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<ReponseReclamation>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            var uriString2 = string.Format("{0}{1}", "/PI_OTDAV_4GL5B-web/api/reponses/total?idReclamation=", idReclamation);
            HttpClient Client2 = new HttpClient();
            Client2.BaseAddress = new Uri("http://localhost:18080");
            Client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response2 = Client2.GetAsync(uriString2).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.count1 = response2.Content.ReadAsAsync<int>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            ViewBag.count2 = rs.GetReclamation(idReclamation);
            ViewBag.userId = rs.GetUserId(idReclamation);
            return View();

        }



    }
}