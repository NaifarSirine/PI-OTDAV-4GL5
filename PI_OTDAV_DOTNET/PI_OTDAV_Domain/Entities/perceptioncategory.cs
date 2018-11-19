namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.perceptioncategory")]
    public partial class perceptioncategory
    {
        [Key]
        public int idPerceptionCategory { get; set; }

        [StringLength(255)]
        public string NomCategory { get; set; }

        [StringLength(255)]
        public string PSC { get; set; }

        [StringLength(255)]
        public string SCT { get; set; }

        [StringLength(255)]
        public string detailsCategory { get; set; }

        public int? espace_idEspace { get; set; }

        public virtual espace espace { get; set; }
    }
}
