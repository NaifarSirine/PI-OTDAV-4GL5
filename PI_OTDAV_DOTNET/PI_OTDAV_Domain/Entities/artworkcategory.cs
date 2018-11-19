namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.artworkcategory")]
    public partial class artworkcategory
    {
        public int id { get; set; }

        [StringLength(255)]
        public string details { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        [Column(TypeName = "bit")]
        public bool? status { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int updatedID { get; set; }
    }
}
