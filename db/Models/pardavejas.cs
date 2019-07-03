using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace db.Models
{
    public class pardavejas
    {
        public int id { get; set; }

        [DisplayName("Vardas")]
        [Required]
        public string vardas { get; set; }
        [DisplayName("Pavarde")]
        [Required]
        public string pavarde { get; set; }
        [DisplayName("Tabelio Nr.")]
        [Required]
        public int tabelioNumeris { get; set; }
        [DisplayName("Darbo Sutarties Nr.")]
        [Required]
        public int darboSutartiesNr { get; set; }
        public int fk_Filialas { get; set; }

    }
}