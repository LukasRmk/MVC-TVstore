using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db.repos;
using db.ViewModels;

namespace db.Controllers
{
    public class TVController : Controller
    {
        //apibreziamos saugyklos kurios naudojamos siame valdiklyje
        TVRepository tvRepository = new TVRepository();
        ModelisRepository markeRepository = new ModelisRepository();
        // GET: Modelis
        public ActionResult Index()
        {
            return View(tvRepository.getModeliai());
        }

        // GET: Modelis/Create
        public ActionResult Create()
        {
            TVEditViewModel modelis = new TVEditViewModel();
            PopulateSelections(modelis);
            return View(modelis);
        }

        // POST: Modelis/Create
        [HttpPost]
        public ActionResult Create(TVEditViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    tvRepository.addModelis(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        // GET: Modelis/Edit/5
        public ActionResult Edit(int id)
        {
            TVEditViewModel modelis = tvRepository.getModelis(id);
            PopulateSelections(modelis);
            return View(modelis);
        }

        // POST: Modelis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TVEditViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    tvRepository.updateModelis(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        // GET: Modelis/Delete/5
        public ActionResult Delete(int id)
        {
            TVEditViewModel modelis = tvRepository.getModelis(id);
            return View(modelis);
        }

        // POST: Modelis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                TVEditViewModel modelis = tvRepository.getModelis(id);
                bool naudojama = false;

                //if (modeliuRepository.getModelisCount(id) > 0)
                //{
                //    naudojama = true;
                //    ViewBag.naudojama = "Negalima pašalinti modelio, yra sukurtų televizoriu su šiuo modeliu.";
                //    return View(modelis);
                //}

                if (!naudojama)
                {
                    tvRepository.deleteModelis(id);
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void PopulateSelections(TVEditViewModel modelis)
        {
            var markes = markeRepository.getModeliai();
            List<SelectListItem> selectListmarkes = new List<SelectListItem>();

            foreach (var item in markes)
            {
                selectListmarkes.Add(new SelectListItem()
                { Value = Convert.ToString(item.id_Modelis), Text = item.pavadinimas });
            }

            modelis.ModeliaiList = selectListmarkes;
        }
    }
}