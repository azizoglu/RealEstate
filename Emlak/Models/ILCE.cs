namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ILCE")]
    public partial class ILCE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ILCE()
        {
            ADRES = new HashSet<ADRES>();
            TAKIP = new HashSet<TAKIP>();
        }

        public int ID { get; set; }

        public int KODU { get; set; }

        [Required]
        [StringLength(100)]
        public string ADI { get; set; }

        public int IL_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADRES> ADRES { get; set; }

        public virtual IL IL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAKIP> TAKIP { get; set; }
    }
}
