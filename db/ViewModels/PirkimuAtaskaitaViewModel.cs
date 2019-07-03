using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel;
using System.Web;
using db.ViewModels;

namespace db.ViewModels
{
    public class PirkimuAtaskaitaViewModel
    {
        public List<AtaskaitaViewModel> sutartys { get; set; }
        [DisplayName("Sudarytų sutarčių vertė")]
        public decimal visoSumaSutartciu { get; set; }
        [DisplayName("Sudarytų kiekis")]
        public int sutarciusk { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? nuo { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? iki { get; set; }
    }
}