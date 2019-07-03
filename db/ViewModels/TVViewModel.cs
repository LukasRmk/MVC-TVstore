using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace db.ViewModels
{
    public class TVViewModel
    {
        [DisplayName("Ser. Numeris")]
        public string SerN { get; set; }
        [DisplayName("Ekrano Daznis")]
        public string ekranoDaznis { get; set; }
        [DisplayName("Rezoliucija")]
        public string rezoliucija { get; set; }
        [DisplayName("Imtuvas")]
        public string imtuvas { get; set; }
        [DisplayName("id")]
        public int id_Televizorius { get; set; }
        [DisplayName("Modelis")]
        public string Modelis { get; set; }
    }
}