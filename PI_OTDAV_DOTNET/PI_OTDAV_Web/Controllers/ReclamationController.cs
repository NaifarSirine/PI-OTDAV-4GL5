using PI_OTDAV_Domain.Entities;
using PI_OTDAV_Services.Services;
using PI_OTDAV_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Mail;

namespace PI_OTDAV_Web.Controllers
{
    public class ReclamationController : Controller
    {
        public ReclamationServices rs = new ReclamationServices();
        public NotificationController nc = new NotificationController();
        public UserServices us = new UserServices();
        // GET: Reclamation
        [HttpGet]
        public ActionResult Create(int idUser)
        {
            ViewBag.userId = idUser;
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(Reclamation r, int idUser)
        {

            try
            {

                Models.User u = new Models.User();
                u.id = idUser;
                r.user = u;
                r.dateReclamation = null;
                Console.WriteLine(r);
                HttpClient Client = new HttpClient();
                HttpResponseMessage response = Client.PostAsJsonAsync<Reclamation>("http://localhost:18080/PI_OTDAV_4GL5B-web/api/reclamations/add", r).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;

                if (response.IsSuccessStatusCode)
                {
                    //Add Notif
                    user utilisateur = us.GetById(idUser);
                    Notification n = new Notification();
                    n.description = "L'utilisateur " + utilisateur.FirstName + " " + utilisateur.LastName + " a ajouté une réclamation de type:" + r.type+".";
                    n.type="Réclamation";
                    nc.Create(n,idUser);
                    //End Add Notif
                    SendMail(idUser);
                    return RedirectToAction("Display", new { idUser = idUser });
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
        public ActionResult Display(int idUser)
        {
            ViewBag.count1 = rs.GetTotalReclamations(idUser);
            ViewBag.idUser = idUser;
            ViewBag.listeRec = rs.GetReclamations(idUser);
            return View();
        }
        [HttpGet]
        public ActionResult DisplayByEtat(int userId)
        {
            ViewBag.listeEnAttente = rs.GetReclamationsEtat(0, userId);
            ViewBag.listeEnCours = rs.GetReclamationsEtat(1, userId);
            ViewBag.listeTraitée = rs.GetReclamationsEtat(2, userId);
            ViewBag.count0 = rs.GetReclamationsEtatCount(0, userId);
            ViewBag.count1 = rs.GetReclamationsEtatCount(1, userId);
            ViewBag.count2 = rs.GetReclamationsEtatCount(2, userId);
            ViewBag.userId = userId;
            return View();

        }
        public ActionResult DisplayByType(int userId)
        {
            ViewBag.listeAutre = rs.GetReclamationsType(0, userId);
            ViewBag.listeSuggestion = rs.GetReclamationsType(1, userId);
            ViewBag.listeFinancier = rs.GetReclamationsType(2, userId);
            ViewBag.listeOeuvre = rs.GetReclamationsType(3, userId);
            ViewBag.listeSysteme = rs.GetReclamationsType(4, userId);
            ViewBag.count0 = rs.GetReclamationsTypeCount(0, userId);
            ViewBag.count1 = rs.GetReclamationsTypeCount(1, userId);
            ViewBag.count2 = rs.GetReclamationsTypeCount(2, userId);
            ViewBag.count3 = rs.GetReclamationsTypeCount(3, userId);
            ViewBag.count4 = rs.GetReclamationsTypeCount(4, userId);
            ViewBag.userId = userId;
            return View();

        }
        public FileResult CreatePdf(int idUser)
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;
            //file name to be created   
            string strPDFFileName = string.Format("SamplePdf" + dTime.ToString("yyyyMMdd") + "-" + ".pdf");
            Document doc = new Document();

            //Create PDF Table with 5 columns  
            PdfPTable tableLayout = new PdfPTable(4);

            //Create PDF Table  

            //file will created in this path  
            string strAttachment = Server.MapPath("~/Downloadss/" + strPDFFileName);


            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();

            //Add Content to PDF   
            doc.Add(Add_Content_To_PDF(tableLayout, idUser));

            // Closing the document  
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;


            return File(workStream, "application/pdf", strPDFFileName);

        }
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.HELVETICA, 8, 1)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5
            });
        }

        // Method to add single cell to the body  
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.HELVETICA, 8, 1)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5
            });
        }
        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout, int idUser)
        {

            float[] headers = { 50, 24, 45, 35 }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top  

            List<reclamation> reclamation = rs.GetReclamations(idUser).ToList();


            tableLayout.AddCell(new PdfPCell(new Phrase("Liste des réclamations", new Font(Font.HELVETICA, 20, 1, Color.RED)))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            tableLayout.AddCell(new PdfPCell(new Phrase("", new Font(Font.HELVETICA, 10, 1, Color.RED)))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            ////Add header  

            AddCellToHeader(tableLayout, "Etat");
            AddCellToHeader(tableLayout, "Type");
            AddCellToHeader(tableLayout, "Description");
            AddCellToHeader(tableLayout, "Date Reclamation");

            ////Add body  

            foreach (var emp in reclamation)
            {

                AddCellToBody(tableLayout, emp.etat);
                AddCellToBody(tableLayout, emp.type);
                AddCellToBody(tableLayout, emp.description);
                AddCellToBody(tableLayout, emp.dateReclamation.ToString());

            }

            return tableLayout;
        }

        public void SendMail(int Userid)
        {
            UserServices us = new UserServices();
            user u = us.GetById(Userid);
            String date = DateTime.Now.ToString();

            MailMessage mailMessage = new MailMessage("aotdav@gmail.com", u.mail);
            mailMessage.Subject = "Mail de confirmation";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = (string)System.IO.File.ReadAllText(Server.MapPath("~/Mail/mail.html"));
            SmtpClient smtpClient = new SmtpClient();
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "aotdav@gmail.com",
                Password = "otdav2018"
            };
            //smtpClient.UseDefaultCredentials = false;
            smtpClient.Send(mailMessage);


        }
        public JsonResult GetReclamationByDate(string Date)
        {
            var reclamation = rs.GetAll().Where(e=>e.dateReclamation.ToString().Equals(Date));
            return new JsonResult { Data = reclamation, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


    }

}