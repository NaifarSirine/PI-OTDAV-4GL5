using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PI_OTDAV_Web.Models
{
    public class OeuvreDeposantViewModel
    {
        public int Id { get; set; }
        [Column(TypeName = "date")]
        [Display(Name = "Date Début")]

        [DataType(DataType.Date)]
        public DateTime? Date_dep { get; set; }


        public string Description { get; set; }


        public string Etat_depot { get; set; }

        public string Image { get; set; }


        public string Titre { get; set; }
    }
}