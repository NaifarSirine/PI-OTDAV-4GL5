namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.reclamation")]
    public partial class reclamation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reclamation()
        {
            reponsereclamations = new HashSet<reponsereclamation>();
        }

        [Key]
        public int idReclamation { get; set; }

        public DateTime? dateReclamation { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        [StringLength(255)]
        public string fichier_a_joindre { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int? userId { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reponsereclamation> reponsereclamations { get; set; }
    }
}
