using Newtonsoft.Json;
using PI_OTDAV_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI_OTDAV_Web.Models
{
        public class Reclamation
        {
            public Reclamation()
            {
              
            }
          
 
            public int idReclamation { get; set; }
          
            public DateTime? dateReclamation { get; set; }
            public string description { get; set; }
            public string etat { get; set; }
            public string type { get; set; }
            [JsonIgnore]
            public int? userId { get; set; }
            public virtual Models.User user { get; set; }


    }
    

}