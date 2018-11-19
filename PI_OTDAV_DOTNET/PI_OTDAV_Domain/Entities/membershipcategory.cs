namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.membershipcategory")]
    public partial class membershipcategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public membershipcategory()
        {
            user = new HashSet<user>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string details { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        [Column(TypeName = "bit")]
        public bool? status { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> user { get; set; }
    }
}
