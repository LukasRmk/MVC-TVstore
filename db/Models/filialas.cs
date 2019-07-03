using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace db.Models
{
    public class filialas
    {
        public string adresas { get; set; }
        public int pastoKodas { get; set; }
        public string direktorius { get; set; }
        public int id { get; set; }
        public int fk_miestas { get; set; }

    }
}