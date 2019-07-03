using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace db.ViewModels
{
    public class PirkimoViewModel
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Pirkimo Data")]
        public DateTime PirkimoData { get; set; }
        [DisplayName("Sutarties Nr.")]
        public int SutartiesNumeris { get; set; }
        [DisplayName("Paslaugos")]
        public string PapildomosPaslaugos { get; set; }
        [DisplayName("Sas. Nr.")]
        public int SaskaitosNumeris { get; set; }
        [DisplayName("Paslaugu Kaina")]
        public decimal PapildomuPaslauguKaina { get; set; }
        [DisplayName("ID")]
        public int id_Pirkimo_sutartis { get; set; }
        [DisplayName("TV")]
        public string televizorius { get; set; }
    }
}