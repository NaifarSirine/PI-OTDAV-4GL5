namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.oeuvredeposant")]
    public partial class oeuvredeposant
    {
        public int id { get; set; }

        public DateTime? date_dep { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string etat_depot { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [StringLength(255)]
        public string titre { get; set; }
    }
}
