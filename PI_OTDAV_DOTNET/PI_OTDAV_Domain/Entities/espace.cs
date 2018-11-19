namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.espace")]
    public partial class espace
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public espace()
        {
            perceptioncategory = new HashSet<perceptioncategory>();
        }

        [Key]
        public int idEspace { get; set; }

        [StringLength(255)]
        public string NomEspace { get; set; }

        [StringLength(255)]
        public string adresse { get; set; }

        [StringLength(255)]
        public string details { get; set; }

        public int? formulePerception_idFormuleP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<perceptioncategory> perceptioncategory { get; set; }

        public virtual formuleperception formuleperception { get; set; }
    }
}
