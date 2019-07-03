using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace db.ViewModels
{
    public class ModeliaiViewModel
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
        public string gamintojas { get; set; }
    }
}