using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace db.Models
{
    public class mokejimas
    {
        public int id { get; set; }
        public DateTime data { get; set; }
        public float suma { get; set; }
        public int fk_Saskaita { get; set; }
        public int fk_Klientas { get; set; }

    }
}