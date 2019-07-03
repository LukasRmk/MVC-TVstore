using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db.repos;
using db.ViewModels;

namespace db.Controllers
{
    public class AtaskaituController : Controller
    {
        AtaskaituRepository ataskaituRepository = new AtaskaituRepository();
        // GET: Ataskaita
        // Gali būti nenurodytos datos dėl to prie kintamuju ? 
        public ActionResult Index(DateTime? nuo, DateTime? iki)
        {
            // išrenka paslaugas
            PirkimuAtaskaitaViewModel ataskaita = ataskaituRepository.getBedraSumaUzsakytuPaslaugu(nuo, iki);
            ataskaita.sutartys = ataskaituRepository.getUzsakytosPaslaugos(nuo, iki);
            //išsaugomos numatytos reiksmes datos intervalui
            ataskaita.nuo = nuo == null ? null : nuo;
            ataskaita.iki = iki == null ? null : iki;

            return View(ataskaita);
        }
    }
}