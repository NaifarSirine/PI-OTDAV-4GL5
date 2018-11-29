namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.programme")]
    public partial class programme
    {
        public int id { get; set; }

        public float part { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_diff { get; set; }

        public int minuteur { get; set; }

        public float montant { get; set; }

        [StringLength(255)]
        public string titre { get; set; }

        [StringLength(255)]
        public string titre_exploi { get; set; }
    }
}
