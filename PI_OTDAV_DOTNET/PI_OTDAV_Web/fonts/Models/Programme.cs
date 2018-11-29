using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI_OTDAV_Web.Models
{
    public class Programme
    {
        public int id { get; set; }
        public float part { get; set; }
        public float montant { get; set; }
        public string titre { get; set; }
        public string titre_exploi { get; set; }
        public int minuteur { get; set; }
        public DateTime? date_diff { get; set; }


    }
}