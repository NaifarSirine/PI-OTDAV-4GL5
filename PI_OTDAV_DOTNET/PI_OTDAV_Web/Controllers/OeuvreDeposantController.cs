using PI_OTDAV_Domain.Entities;
using PI_OTDAV_Services.Services;
using PI_OTDAV_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PI_OTDAV_Web.Controllers
{
    public class OeuvreDeposantController : Controller
    {
        OeuvreDeposant od = new OeuvreDeposant();

        // GET: OeuvreDeposant
        public ActionResult Index()
        {
            var liste = od.GetAll();
            return View(liste);
        }


        [HttpPost]
        public ActionResult Index(string SearchString)
        {
            var liste = od.GetMany(x => x.titre.Contains(SearchString));
            return View(liste);

        }

        // GET: OeuvreDeposant/Details/5
        public ActionResult Details(int id)
        {
            var oeuvre = od.GetById(id);
            OeuvreDeposantViewModel odvm = new OeuvreDeposantViewModel();
            odvm.Titre = oeuvre.titre;
            odvm.Etat_depot = oeuvre.etat_depot;
            odvm.Description = oeuvre.description;
            odvm.Date_dep = oeuvre.date_dep;


            return View(odvm);
        }

        // GET: OeuvreDeposant/Create
        public ActionResult Create()
        {
            var liste = od.GetAll();
            return View();
        }

        // POST: OeuvreDeposant/Create
        [HttpPost]
        public ActionResult Create(oeuvredeposant ovd)
        {
            if (ModelState.IsValid)
            {

                od.Add(ovd);

                od.Commit();


                return RedirectToAction("Index");


            }

            return View(ovd);
        }

        // GET: OeuvreDeposant/Edit/5
        public ActionResult Edit(int id)
        {
            var oeuvre = od.GetById(id);
            OeuvreDeposantViewModel odvm = new OeuvreDeposantViewModel();
            odvm.Titre = oeuvre.titre;
            odvm.Etat_depot = oeuvre.etat_depot;
            odvm.Description = oeuvre.description;
            odvm.Date_dep = oeuvre.date_dep;


            return View(odvm);

        }

        // POST: OeuvreDeposant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OeuvreDeposantViewModel model)
        {
            oeuvredeposant o = od.GetById(id);
            o.titre = model.Titre;
            o.description = model.Description;

            o.date_dep = model.Date_dep;
            o.image = model.Image;
            o.etat_depot = model.Etat_depot;
            od.Update(o);
            od.Commit();

            return RedirectToAction("Index");
        }


        // GET: OeuvreDeposant/Delete/5
        public ActionResult Delete(int id)
        {
            var oeuvre = od.GetById(id);
            OeuvreDeposantViewModel odvm = new OeuvreDeposantViewModel();
            odvm.Titre = oeuvre.titre;
            odvm.Etat_depot = oeuvre.etat_depot;
            odvm.Description = oeuvre.description;
            odvm.Date_dep = oeuvre.date_dep;


            return View(odvm);
        }

        // POST: OeuvreDeposant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OeuvreDeposantViewModel model)
        {
            oeuvredeposant o = od.GetById(id);
            o.titre = model.Titre;
            o.description = model.Description;

            o.date_dep = model.Date_dep;
            o.image = model.Image;
            o.etat_depot = model.Etat_depot;
            od.Delete(o);
            od.Commit();

            return RedirectToAction("Index");
        }
    }
}

