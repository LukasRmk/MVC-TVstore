using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db.repos;
using db.Models;

namespace db.Controllers
{
    public class GamintojasController : Controller
    {
        //apibreziamos saugyklos kurios naudojamos siame valdiklyje
        gamintojasRepository imoneRepository = new gamintojasRepository();
        // GET: Marke
        public ActionResult Index()
        {
            //grazinamas markiu sarašas
            return View(imoneRepository.getKlientai());
        }

        // GET: Marke/Create
        public ActionResult Create()
        {
            Gamintojas imone = new Gamintojas();
            return View(imone);
        }

        // POST: Marke/Create
        [HttpPost]
        public ActionResult Create(Gamintojas collection)
        {
            try
            {
                // išsaugo nauja markę duomenų bazėje
                if (ModelState.IsValid)
                {
                    imoneRepository.addKlientas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Marke/Edit/5
        public ActionResult Edit(int id)
        {
            return View(imoneRepository.getKlientas(id));
        }

        // POST: Marke/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Gamintojas collection)
        {
            try
            {
                // atnajina markes informacija
                if (ModelState.IsValid)
                {
                    imoneRepository.updateKlientas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Marke/Delete/5
        public ActionResult Delete(int id)
        {
            return View(imoneRepository.getKlientas(id));
        }

        // POST: Marke/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                bool naudojama = false;
                //if (imoneRepository.getImoneCount(id) > 0)
                //{
                //    naudojama = true;
                //    ViewBag.naudojama = "Negalima pašalinti yra sukurtų modelių su šia marke.";
                //    return View(imoneRepository.getImone(id));
                //}

                if (!naudojama)
                {
                    imoneRepository.deleteKlientas(id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}