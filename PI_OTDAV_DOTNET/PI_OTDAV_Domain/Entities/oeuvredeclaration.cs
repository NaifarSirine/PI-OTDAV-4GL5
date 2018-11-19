namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.oeuvredeclaration")]
    public partial class oeuvredeclaration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public oeuvredeclaration()
        {
            location = new HashSet<location>();
            perciption = new HashSet<perciption>();
            paiment = new HashSet<paiment>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string Categorie { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateFin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateInitial { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Deadline { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeadlineFirstAlerte { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public int EtatDeadline { get; set; }

        public int EtatFirstAlerte { get; set; }

        [StringLength(255)]
        public string Support { get; set; }

        [Required]
        [StringLength(255)]
        public string Titre { get; set; }

        [Required]
        [StringLength(255)]
        public string etat { get; set; }

        [StringLength(255)]
        public string path { get; set; }

        public int? user_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<location> location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<perciption> perciption { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<paiment> paiment { get; set; }
    }
}
