namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.perciption")]
    public partial class perciption
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public perciption()
        {
            repartition = new HashSet<repartition>();
        }

        [Key]
        public int idPerception { get; set; }

        [Column(TypeName = "bit")]
        public bool Statuts { get; set; }

        public double montant { get; set; }

        public double montantotale { get; set; }

        public int? OeuvreD_id { get; set; }

        public int? idFormuleP { get; set; }

        public virtual formuleperception formuleperception { get; set; }

        public virtual oeuvredeclaration oeuvredeclaration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<repartition> repartition { get; set; }
    }
}
