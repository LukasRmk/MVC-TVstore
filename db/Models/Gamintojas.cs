using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace db.Models
{
    public class Gamintojas
    {
        [Required]
        public string pavadinimas { get; set; }
        public int id_Gamintojas { get; set; }
    }
}