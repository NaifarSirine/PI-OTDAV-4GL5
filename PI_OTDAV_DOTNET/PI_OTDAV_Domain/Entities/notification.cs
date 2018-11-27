namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.notification")]
    public partial class notification
    {
        [Key]
        public int idNotification { get; set; }

        public DateTime? dateNotification { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int? idDestination { get; set; }

        public int? idUser { get; set; }
        [ForeignKey("idUser")]
        public virtual user user { get; set; }
        [ForeignKey("idDestination")]
        public virtual user destination { get; set; }
    }
}
