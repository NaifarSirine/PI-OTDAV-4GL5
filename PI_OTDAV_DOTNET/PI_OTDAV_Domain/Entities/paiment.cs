namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.paiment")]
    public partial class paiment
    {
        public int ID { get; set; }

        public DateTime? Date { get; set; }

        public int Price { get; set; }

        public int Status { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public int? bankcard_IdBank { get; set; }

        public int? cheque_IdCheque { get; set; }

        public int? oeuvreDec_id { get; set; }

        public int? userId { get; set; }

        public int? virement_IdVirement { get; set; }

        public virtual bankcard bankcard { get; set; }

        public virtual cheque cheque { get; set; }

        public virtual oeuvredeclaration oeuvredeclaration { get; set; }

        public virtual user user { get; set; }

        public virtual virement virement { get; set; }
    }
}
