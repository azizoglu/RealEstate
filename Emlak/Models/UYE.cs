namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UYE")]
    public partial class UYE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UYE()
        {
            ILAN = new HashSet<ILAN>();
            KULLANICI = new HashSet<KULLANICI>();
            SATIS = new HashSet<SATIS>();
            SATIS1 = new HashSet<SATIS>();
            TALEP = new HashSet<TALEP>();
            TALEP1 = new HashSet<TALEP>();
        }

        public int ID { get; set; }

        public int UYE_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string UYE_TURU { get; set; }

        public bool UYE_DURUMU { get; set; }

        public virtual BIREYSEL_UYE BIREYSEL_UYE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ILAN> ILAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KULLANICI> KULLANICI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SATIS> SATIS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SATIS> SATIS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TALEP> TALEP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TALEP> TALEP1 { get; set; }
    }
}
