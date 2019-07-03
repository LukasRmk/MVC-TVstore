using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel;
using System.Web;
using db.ViewModels;

namespace db.ViewModels
{
    public class AtaskaitaViewModel
    {
        [DisplayName("Sutartis")]
        public int id { get; set; }
        [DisplayName("Data")]
        public DateTime sutartiesData { get; set; }
        [DisplayName("Sutarties Nr.")]
        public int SutartiesNumeris { get; set; }
        [DisplayName("Sudarytų sutarčių vertė")]
        public decimal kaina { get; set; }
        [DisplayName("Pardavejas")]
        public string pardavejas { get; set; }
    }
}