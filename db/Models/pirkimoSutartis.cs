using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace db.Models
{
    public class pirkimoSutartis
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PirkimoData { get; set; }
        public int SutartiesNumeris { get; set; }

        public string PapildomosPaslaugos { get; set; }
        public int SaskaitosNumeris { get; set; }
        public decimal PapildomuPaslauguKaina { get; set; }
        public int id_Pirkimo_sutartis { get; set; }
        public virtual televizorius Televizorius { get; set; }
    }
}