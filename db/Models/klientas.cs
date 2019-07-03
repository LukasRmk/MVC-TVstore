using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace db.Models
{
    public class klientas
    {
        public int id { get; set; }
        [DisplayName("Vardas")]
        [Required]
        public string vardas { get; set; }
        [DisplayName("Pavarde")]
        [Required]
        public string pavarde { get; set; }
        [DisplayName("Asmens Kodas")]
        [Required]
        public int klientoKodas { get; set; }
        public int fk_Garantija { get; set; }

    }
}