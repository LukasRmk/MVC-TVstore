using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace db.Models
{
    public class platintojas
    {
        [DisplayName("Pavadinimas")]
        [Required]
        public string pavadinimas { get; set; }
        [DisplayName("Adresas")]
        [Required]
        public string adresas { get; set; }
        [DisplayName("Pasto Kodas")]
        [Required]
        public int pastoKodas { get; set; }
        [DisplayName("E. Pastas")]
        [Required]
        public string epastas { get; set; }
        [DisplayName("ID")]
        [Required]
        public int id { get; set; }
        public int fk_Televizorius { get; set; }
        public int fk_Miestas { get; set; }

    }
}