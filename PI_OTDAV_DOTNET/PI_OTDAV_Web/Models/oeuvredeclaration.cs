using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI_OTDAV_Web.Models
{
    public class oeuvredeclaration
    {

        public int id { get; set; }
        public string categorie { get; set; }
        public DateTime? dateFin { get; set; }
        public DateTime? dateInitial { get; set; }
        public DateTime? deadline { get; set; }
        public DateTime? deadlineFirstAlerte { get; set; }
        public string description { get; set; }
        public int etatDeadline { get; set; }
        public int etatFirstAlerte { get; set; }
        public string support { get; set; }
        public string titre { get; set; }
        public string etat { get; set; }
        public string path { get; set; }
        [JsonIgnore]
        public int? user_ID { get; set; }
        //public virtual user user { get; set; }

        public virtual Models.User user { get; set; }

    }
}