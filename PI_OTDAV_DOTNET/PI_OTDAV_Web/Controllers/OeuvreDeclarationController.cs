using PI_OTDAV_Data;
using PI_OTDAV_Domain.Entities;
using PI_OTDAV_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Mvc;



namespace PI_OTDAV_Web.Controllers
{
    public class OeuvreDeclarationController : Controller
    {
        // GET: DisplayAllOeuvreDeclarationAcceptee
        public ActionResult DispalyAllOeuvreDeclration()
        {
            FirstAlertOeuvreDeclaraion();
            DeadlineOeuvreDeclaraion();
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/PI_OTDAV_4GL5B-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/OeuvreDeclration").Result;
            if (response.IsSuccessStatusCode)
            {
                int cnt = please.CountAccepterArtWorAll();
                ViewBag.count = cnt;
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<PI_OTDAV_Web.Models.oeuvredeclaration>>().Result;

            }
            else
            {

                ViewBag.result = "error";
            }
            return View();
        }

        [HttpGet]
        public ActionResult AjouterOuvre()
        {
            return View();
        }



        [HttpPost]
        public ActionResult AjouterOuvre(PI_OTDAV_Web.Models.oeuvredeclaration o)
        {
            HttpClient Client = new HttpClient();
            Models.User u = new Models.User();
            u.id = (int)Session["id"];
            o.user = u;
            Client.BaseAddress = new Uri("http://localhost:18080/PI_OTDAV_4GL5B-web/");
            Client.PostAsJsonAsync<PI_OTDAV_Web.Models.oeuvredeclaration>("api/OeuvreDeclration/AddOeuvre", o).ContinueWith((PostTask) => PostTask.Result.EnsureSuccessStatusCode());
            SendMailOeuvreAjoutee(u.id);

            return RedirectToAction("DispalySimpleArtWorkByUser");
        }

        public ActionResult DeclarerOeuvre(int id)
        {


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/PI_OTDAV_4GL5B-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/OeuvreDeclration/UpdateOeuvreEnAttente/" + id).Result;

            if (response.IsSuccessStatusCode)
            {

               
                return RedirectToAction("DispalyEnAttenteArtWorkByUser");

            }
            else
            {

                ViewBag.result = "error";
            }

            return RedirectToAction("DispalyEnAttenteArtWorkByUser");
        }


        [HttpGet]
        public int CalculerNbtTotalMusical()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/PI_OTDAV_4GL5B-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/OeuvreDeclration/CountAllMusical").Result;
            if (response.IsSuccessStatusCode)
            {
                return ViewBag.result = response.Content.ReadAsAsync<int>().Result;

            }
            else
            {

                return ViewBag.result = "error";
            }

        }

        [HttpGet]
        public int CalculerNbtTotalTheatre()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/PI_OTDAV_4GL5B-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/OeuvreDeclration/CountAllTheatre").Result;
            if (response.IsSuccessStatusCode)
            {
                return ViewBag.result = response.Content.ReadAsAsync<int>().Result;

            }
            else
            {

                return ViewBag.result = "error";
            }

        }

        [HttpGet]
        public int CalculerNbtTotalDance()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/PI_OTDAV_4GL5B-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/OeuvreDeclration/CountAllDance").Result;
            if (response.IsSuccessStatusCode)
            {
                return ViewBag.result = response.Content.ReadAsAsync<int>().Result;

            }
            else
            {

                return ViewBag.result = "error";
            }

        }

        [HttpGet]
        public int CalculerNbtTotalLitterature()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/PI_OTDAV_4GL5B-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/OeuvreDeclration/CountAllLitterature").Result;
            if (response.IsSuccessStatusCode)
            {
                return ViewBag.result = response.Content.ReadAsAsync<int>().Result;

            }
            else
            {

                return ViewBag.result = "error";
            }

        }
        [HttpGet]
        public int CalculerNbtTotalPoterie()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/PI_OTDAV_4GL5B-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/OeuvreDeclration/CountAllPoterie").Result;
            if (response.IsSuccessStatusCode)
            {
                return ViewBag.result = response.Content.ReadAsAsync<int>().Result;

            }
            else
            {

                return ViewBag.result = "error";
            }

        }

        [HttpGet]

        public int CalculerNbtTotalPeinture()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/PI_OTDAV_4GL5B-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/OeuvreDeclration/CountAllPeinture").Result;
            if (response.IsSuccessStatusCode)
            {
                return ViewBag.result = response.Content.ReadAsAsync<int>().Result;

            }
            else
            {

                return ViewBag.result = "error";
            }

        }

        [HttpGet]

        public int CalculerNbtTotalGraphic()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/PI_OTDAV_4GL5B-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/OeuvreDeclration/CountAllGraphic").Result;
            if (response.IsSuccessStatusCode)
            {
                return ViewBag.result = response.Content.ReadAsAsync<int>().Result;

            }
            else
            {

                return ViewBag.result = "error";
            }

        }

        [HttpGet]

        public int CalculerNbtTotalScenario()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/PI_OTDAV_4GL5B-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/OeuvreDeclration/CountAllScenario").Result;
            if (response.IsSuccessStatusCode)
            {
                return ViewBag.result = response.Content.ReadAsAsync<int>().Result;

            }
            else
            {

                return ViewBag.result = "error";
            }

        }

        public int CalculerNbtTotalArtWork()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/PI_OTDAV_4GL5B-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/OeuvreDeclration/CalculAll").Result;
            if (response.IsSuccessStatusCode)
            {
                return ViewBag.result = response.Content.ReadAsAsync<int>().Result;

            }
            else
            {

                return ViewBag.result = "error";
            }

        }

        //**********************************Mail********************************************************

        PI_OTDAV_Services.Services.UserServices em = new PI_OTDAV_Services.Services.UserServices();
    
        public void SendMailOeuvreAjoutee(int id)
        {

            
            id = (int)Session["id"];
            PI_OTDAV_Domain.Entities.user conn = em.GetById(id);
       
            MailMessage mailMessage = new MailMessage("aotdav@gmail.com", conn.mail);
            mailMessage.Subject = "Oeuvre Ajouter";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = string.Format("<html><head></head><body><b>Bonjour Monsieur " + conn.FirstName + "</b>  <br /> <br /> <p>Vous venez d'ajouter une nouvelle oeuvre à votre compte. <br />  N'hésitez pas à la déclarer le plutot possible pour protéger vos droits en tant que auteur.</p> <br > <p> Administration OTDV </p>  <p> Bien Cordialement </p></body></html>");

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "aotdav@gmail.com",
                Password = "otdav2018"
            };
            smtpClient.Send(mailMessage);


        }


        //*****************************************************************************************

        PI_OTDAV_Services.Services.oeuvredeclarationservice please = new PI_OTDAV_Services.Services.oeuvredeclarationservice();

       


        public JsonResult test()
        {
            var listee = please.getEnAttenteArtworkByUserId((int)Session["id"]);
            return Json(listee, JsonRequestBehavior.AllowGet);
        }



        public ActionResult DispalySimpleArtWorkByUser()
        {
            FirstAlertOeuvreDeclaraion();
            DeadlineOeuvreDeclaraion();
            List<OeuvreDeclarationController> list = new List<OeuvreDeclarationController>();
            var List = please.getSimpleArtworkByUserId((int)Session["id"]);
            int x = please.CountSimpleArtWork((int)Session["id"]);
            ViewBag.count1 = x;
            return View(List);

        }

        public ActionResult DispalySupprimerArtWorkByUser()
        {

            List<OeuvreDeclarationController> list = new List<OeuvreDeclarationController>();
            var List = please.getSupprimerArtworkByUserId((int)Session["id"]);
            return View(List);

        }


        public ActionResult DispalyAccepterArtWorkByUser()
        {
            FirstAlertOeuvreDeclaraion();
            DeadlineOeuvreDeclaraion();
            List<OeuvreDeclarationController> list = new List<OeuvreDeclarationController>();
            int x = (int)Session["id"];
            var List = please.getAccepterArtworkByUserId(x);
            int xa = please.CountAccepterArtWork(x);
            ViewBag.count3 = xa;
            return View(List);


        }
        
        public ActionResult DispalyEnAttenteArtWorkByUser()
        {
            FirstAlertOeuvreDeclaraion();
            DeadlineOeuvreDeclaraion();
            List<OeuvreDeclarationController> list = new List<OeuvreDeclarationController>();
            int x = (int)Session["id"];

            var List = please.getEnAttenteArtworkByUserId(x);
            int xea = please.CountEnAttenteArtWork(x);
            ViewBag.count2 = xea;

            return View(List);

        }

        public ActionResult Edit(int id)
        {
            return View(please.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, PI_OTDAV_Domain.Entities.oeuvredeclaration o)
        {
            try
            {
                PI_OTDAV_Domain.Entities.oeuvredeclaration od = please.GetById(id);
                od.Categorie = o.Categorie;
                od.Titre = o.Titre;
                od.Description = o.Description;
                please.Update(od);
                please.Commit();

                return RedirectToAction("DispalySimpleArtWorkByUser");
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult SupprimerOeuvreDeclarer(int id)
        {
            try
            {
                PI_OTDAV_Domain.Entities.oeuvredeclaration o = please.GetById(id);
                o.etat = "Supprimer";
                please.Update(o);
                please.Commit();
                return RedirectToAction("DispalySimpleArtWorkByUser");
            }
            catch
            {
                return View("DispalySimpleArtWorkByUser");
            }

        }

        
        [HttpGet]
        public ActionResult DeeclarerOeuvre(int id)
        {
            try
            {
                PI_OTDAV_Domain.Entities.oeuvredeclaration o = please.GetById(id);
                o.etat = "EnAttente";
                please.Update(o);
                please.Commit();
                return RedirectToAction("DispalyEnAttenteArtWorkByUser");
            }
            catch
            {
                return View("DispalySimpleArtWorkByUser");
            }

        }

        [HttpGet]
        public ActionResult SupprimerOeuvreDeclarerSimple(int id)
        {
            try
            {
                PI_OTDAV_Domain.Entities.oeuvredeclaration o = please.GetById(id);
                o.etat = "Supprimer";
                please.Update(o);
                please.Commit();
                return RedirectToAction("DispalySimpleArtWorkByUser");
            }
            catch
            {
                return View("DispalySimpleArtWorkByUser");
            }

        }


        [HttpGet]
        public ActionResult SupprimerOeuvreDeclarerEnAttente(int id)
        {
            try
            {
                PI_OTDAV_Domain.Entities.oeuvredeclaration o = please.GetById(id);
                o.etat = "Supprimer";
                please.Update(o);
                please.Commit();
                return RedirectToAction("DispalyEnAttenteArtWorkByUser");
            }
            catch
            {
                return View("DispalyEnAttenteArtWorkByUser");
            }

        }

        

        [HttpGet]
        public ActionResult SupprimerOeuvreDeclarerAccepter(int id)
        {
            try
            {
                PI_OTDAV_Domain.Entities.oeuvredeclaration o = please.GetById(id);
                o.etat = "Supprimer";
                please.Update(o);
                please.Commit();
                return RedirectToAction("DispalyAccepterArtWorkByUser");
            }
            catch
            {
                return View("DispalyAccepterArtWorkByUser");
            }

        }



        public ActionResult OeuvreDeclaratonCalandar(/*int id*/)
        {

            //eve.
            return View();
        }

        //public static List<oeuvredeclaration> ts = new List<oeuvredeclaration>();
        public static List<String> events = new List<String>();




        //*************************Tache avencée*****************************


        [HttpGet]
        public ActionResult FirstAlertOeuvreDeclaraion()
        {
            // DateTime currentdt = DateTime.Now;
            string currentdt = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            // var currentdt = DateTime.Now.ToString("yyyy-MM-dd");
            //var formatedDate = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            var listAlert = please.getAlll();
            foreach (PI_OTDAV_Domain.Entities.oeuvredeclaration oda in listAlert)
            {

                if (oda.DeadlineFirstAlerte < DateTime.Now && oda.EtatFirstAlerte == 0)
                {
                    //oda.etat = "Supprimer";
                    //Add Notif
                    PI_OTDAV_Services.Services.UserServices us = new PI_OTDAV_Services.Services.UserServices();
                    PI_OTDAV_Web.Controllers.NotificationController nc = new PI_OTDAV_Web.Controllers.NotificationController();
                    user utilisateur = us.GetById((int)Session["id"]);
                    Notification n = new Notification();
                    n.description = "Veuillez Déposer votre oeuvre"+ oda.Titre +" le plus tot possible.";
                    n.type = "Oeuvre_Declaration";
                    nc.Create(n, (int)Session["id"]);
                    //End Add Notif
                    oda.EtatFirstAlerte = 1;
                    please.Update(oda);
                    please.Commit();
                }
            }
            return null;
        }



        [HttpGet]
        public ActionResult DeadlineOeuvreDeclaraion()
        {
            string currentdt = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            var listAlert = please.getAlll();
            foreach (PI_OTDAV_Domain.Entities.oeuvredeclaration oda in listAlert)
            {

                if (oda.Deadline < DateTime.Now && oda.EtatDeadline == 0)
                {
                    //Add Notif
                    PI_OTDAV_Services.Services.UserServices us = new PI_OTDAV_Services.Services.UserServices();
                    PI_OTDAV_Web.Controllers.NotificationController nc = new PI_OTDAV_Web.Controllers.NotificationController();
                    user utilisateur = us.GetById((int)Session["id"]);
                    Notification n = new Notification();
                    n.description = "votre oeuvre" + oda.Titre + " a été supprimer par ce que vous avez dépassé le deadline.";
                    n.type = "Oeuvre_Declaration";
                    nc.Create(n, (int)Session["id"]);
                    //End Add Notif
                    oda.etat = "Supprimer";
                    oda.EtatDeadline = 1;
                    please.Update(oda);
                    please.Commit();
                }
            }
            return null;
        }
    }
}