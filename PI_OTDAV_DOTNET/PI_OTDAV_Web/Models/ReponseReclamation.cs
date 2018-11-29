using Newtonsoft.Json;
using PI_OTDAV_Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PI_OTDAV_Web.Models
{
    public class ReponseReclamation
    {
            public int idReponse { get; set; }

            [DisplayFormat(DataFormatString = "{dd/MM/yyyy,hh:mm:ss}")]
            public DateTime? dateReponse { get; set; }

            public string description { get; set; }

            [JsonIgnore]
            public int? idReclamation { get; set; }

            public virtual Reclamation reclamation { get; set; }

            [JsonIgnore]
            public int? userId { get; set; }

            public virtual User user { get; set; }
        }
    }


