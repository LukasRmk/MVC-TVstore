using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace db.ViewModels
{
    public class ModelisEditViewModel
    {
        [DisplayName("Dydis")]
        public int dydis { get; set; }
        [DisplayName("Ekrano Tipas")]
        public string ekranoTipas { get; set; }
        [DisplayName("Pavadinimas")]
        public string pavadinimas { get; set; }
        [DisplayName("ID")]
        public int id_Modelis { get; set; }
        [DisplayName("Gamintojas")]
        [Required]
        public int fk_gamintojas { get; set; }
        public IList<SelectListItem> GamintojaiList { get; set; }

    }
}