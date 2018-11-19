namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.cheque")]
    public partial class cheque
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cheque()
        {
            paiment = new HashSet<paiment>();
        }

        [Key]
        public int IdCheque { get; set; }

        public int Num { get; set; }

        [StringLength(255)]
        public string Price { get; set; }

        public int agence { get; set; }

        [StringLength(255)]
        public string bank { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        public int status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<paiment> paiment { get; set; }
    }
}
