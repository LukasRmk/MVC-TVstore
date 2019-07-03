using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace db.Models
{
    public class televizorius
    {
        public string SerN { get; set; }
        public string ekranoDaznis { get; set; }
        public string rezoliucija { get; set; }
        public string imtuvas { get; set; }
        public int id_Televizorius { get; set; }
        public virtual modelis Modelis { get; set; }

    }
}