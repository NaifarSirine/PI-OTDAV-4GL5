using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI_OTDAV_Web.Models
{
    public class Notification
    {
        public int idNotification { get; set; }

        public DateTime? dateNotification { get; set; }

        public string description { get; set; }

        public string etat { get; set; }

        public string type { get; set; }
        [JsonIgnore]
        public int? idDestination { get; set; }
        [JsonIgnore]
        public int? idUser { get; set; }

        public virtual User user { get; set; }

        public virtual User destination { get; set; }
    }
}