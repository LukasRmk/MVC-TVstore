using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace db.ViewModels
{
    public class TVEditViewModel
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
        public int fk_Modelis { get; set; }

        public IList<SelectListItem> ModeliaiList { get; set; }
    }
}