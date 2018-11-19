namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.repartitioncategory")]
    public partial class repartitioncategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int details { get; set; }

        public int name { get; set; }

        public int stauts { get; set; }

        public int type { get; set; }
    }
}
