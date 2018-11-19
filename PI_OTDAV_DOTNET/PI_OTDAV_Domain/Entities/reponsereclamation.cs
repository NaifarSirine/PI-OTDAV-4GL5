namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.reponsereclamation")]
    public partial class reponsereclamation
    {
        [Key]
        public int idReponse { get; set; }

        public DateTime? dateReponse { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int? idReclamation { get; set; }

        public int? userId { get; set; }

        public virtual reclamation reclamation { get; set; }

        public virtual user user { get; set; }
    }
}
