namespace PI_OTDAV_Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("basepi.user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            notifications = new HashSet<notification>();
            notifications1 = new HashSet<notification>();
            oeuvredeclarations = new HashSet<oeuvredeclaration>();
            paiments = new HashSet<paiment>();
            reclamations = new HashSet<reclamation>();
            reponsereclamations = new HashSet<reponsereclamation>();
        }

        public int ID { get; set; }

        public DateTime? AcceptationDate { get; set; }

        public int? AccountStatuts { get; set; }

        public int? AccountType { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        [StringLength(255)]
        public string CIN { get; set; }

        [StringLength(255)]
        public string CommercialRegisterNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateCin { get; set; }

        [StringLength(255)]
        public string FirstName { get; set; }

        public int? Fonction { get; set; }

        [StringLength(255)]
        public string Gouverment { get; set; }

        [StringLength(255)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        public int Phone { get; set; }

        public int Points { get; set; }

        public int PostelCode { get; set; }

        public int? RaisonSocial { get; set; }

        public DateTime? RegistrationDate { get; set; }

        [StringLength(255)]
        public string UserName { get; set; }

        [StringLength(255)]
        public string mail { get; set; }

        public int? meberMemberShipCategory_id { get; set; }

        public virtual membershipcategory membershipcategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notification> notifications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notification> notifications1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oeuvredeclaration> oeuvredeclarations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<paiment> paiments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reclamation> reclamations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reponsereclamation> reponsereclamations { get; set; }
    }
}
