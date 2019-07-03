using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace db.Models
{
    public class saskaita
    {
        public int numeris { get; set; }
        public DateTime data { get; set; }
        public float suma { get; set; }
        public int id { get; set; }
        public int fk_PirkimoSutartis { get; set; }

    }
}