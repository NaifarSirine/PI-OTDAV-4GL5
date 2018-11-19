namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.location")]
    public partial class location
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string Armoire { get; set; }

        [Required]
        [StringLength(255)]
        public string Casier { get; set; }

        [Required]
        [StringLength(255)]
        public string Departement { get; set; }

        [StringLength(255)]
        public string Remarque { get; set; }

        [Required]
        [StringLength(255)]
        public string Salle { get; set; }

        public int? OeuvreD_id { get; set; }

        public virtual oeuvredeclaration oeuvredeclaration { get; set; }
    }
}
