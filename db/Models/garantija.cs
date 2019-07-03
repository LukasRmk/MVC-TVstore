using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace db.Models
{
    public class garantija
    {
        public int id { get; set; }
        public int garantinisTerminas { get; set; }
        public string serNum { get; set; }
        public DateTime isigyjimoData { get; set; }
        public float kaina { get; set; }
        public int fk_PirkimoSutartis { get; set; }

    }
}