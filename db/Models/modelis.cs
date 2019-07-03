using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace db.Models
{
    public class modelis
    {
        [DisplayName("Dydis")]
        [Required]
        public int dydis { get; set; }
        [DisplayName("Ekrano Tipas")]
        [Required]
        public string ekranoTipas { get; set; }
        [DisplayName("Pavadinimas")]
        [Required]
        public string pavadinimas { get; set; }
        [DisplayName("ID")]
        [Required]
        public int id_Modelis { get; set; }
        [DisplayName("Gamintojas")]
        [Required]
        public virtual Gamintojas Gamintojas { get; set; }
    }
}