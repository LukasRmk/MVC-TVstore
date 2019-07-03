using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db.repos;
using db.ViewModels;

namespace db.Controllers
{
    public class PirkimasController : Controller
    {
        //apibreziamos saugyklos kurios naudojamos siame valdiklyje
        PirkimoRepository pirkimoRepository = new PirkimoRepository();
        TVRepository tvRepository = new TVRepository();
        // GET: Modelis
        public ActionResult Index()
        {
            return View(pirkimoRepository.getModeliai());
        }

        // GET: Modelis/Create
        public ActionResult Create()
        {
            PirkimoEditViewModel modelis = new PirkimoEditViewModel();
            PopulateSelections(modelis);
            return View(modelis);
        }

        // POST: Modelis/Create
        [HttpPost]
        public ActionResult Create(PirkimoEditViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    pirkimoRepository.addModelis(collection);
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
            PirkimoEditViewModel modelis = pirkimoRepository.getModelis(id);
            PopulateSelections(modelis);
            return View(modelis);
        }

        // POST: Modelis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PirkimoEditViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    pirkimoRepository.updateModelis(collection);
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
            PirkimoEditViewModel modelis = pirkimoRepository.getModelis(id);
            return View(modelis);
        }

        // POST: Modelis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                PirkimoEditViewModel modelis = pirkimoRepository.getModelis(id);
                bool naudojama = false;

                if (!naudojama)
                {
                    pirkimoRepository.deleteModelis(id);
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void PopulateSelections(PirkimoEditViewModel modelis)
        {
            var tv = tvRepository.getModeliai();
            List<SelectListItem> selectListmarkes = new List<SelectListItem>();

            foreach (var item in tv)
            {
                selectListmarkes.Add(new SelectListItem()
                { Value = Convert.ToString(item.id_Televizorius), Text = item.SerN });
            }

            modelis.TVList = selectListmarkes;
        }
    }
}