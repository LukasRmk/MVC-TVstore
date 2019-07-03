using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db.repos;
using db.Models;

namespace db.Controllers
{
    public class DarbuotojasController : Controller
    {
        //Apibrežiamos saugyklos kurios naudojamos šiame valdiklyje
        // GET: Darbuotojas
        DarbuotojasRepository darbuotojasRepository = new DarbuotojasRepository();
        public ActionResult Index()
        {
            //gražinamas darbuotoju sarašo vaizdas
            return View(darbuotojasRepository.getDarbuotojai());
        }

        // GET: Darbuotojas/Create
        public ActionResult Create()
        {
            //Grazinama darbuotojo kūrimo forma
            pardavejas darbuotojas = new pardavejas();
            return View(darbuotojas);
        }

        // POST: Darbuotojas/Create
        [HttpPost]
        public ActionResult Create(pardavejas collection)
        {
            try
            {
                // Patikrinama ar tokiod arbuotojo nėra duomenų bazėje
                pardavejas tmpDarbuotojas = darbuotojasRepository.getDarbuotojas(collection.tabelioNumeris);

                if (tmpDarbuotojas.tabelioNumeris != null)
                {
                    ModelState.AddModelError("tabelis", "Darbuotojas su tokiu tabelio numeriu jau egzistuoja duomenų bazėje.");
                    return View(collection);
                }
                //Jei darbuotojo su tabelio nr neranda prideda naują
                if (ModelState.IsValid)
                {
                    darbuotojasRepository.addDarbuotojas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Darbuotojas/Edit/5
        public ActionResult Edit(int id)
        {
            //grazinama darbuotojo redagavimo forma
            return View(darbuotojasRepository.getDarbuotojas(id));
        }

        // POST: Darbuotojas/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, pardavejas collection)
        {
            try
            {
                // Atnaujina darbuotojo informacija
                if (ModelState.IsValid)
                {
                    darbuotojasRepository.updateDarbuotojas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Darbuotojas/Delete/5
        public ActionResult Delete(int id)
        {
            return View(darbuotojasRepository.getDarbuotojas(id));
        }

        // POST: Darbuotojas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                bool naudojama = false;

                if (darbuotojasRepository.getDarbuotojasSutarciuCount(id) > 0)
                {
                    naudojama = true;
                    ViewBag.naudojama = "Darbuotojas turi sudarytų sutarčių, pašalinti negalima.";
                    return View(darbuotojasRepository.getDarbuotojas(id));
                }

                if (!naudojama)
                {
                    darbuotojasRepository.deleteDarbuotojas(id);
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