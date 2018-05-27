namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YETKI")]
    public partial class YETKI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public YETKI()
        {
            KULLANICI = new HashSet<KULLANICI>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string ADI { get; set; }

        [StringLength(150)]
        public string ACIKLAMA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KULLANICI> KULLANICI { get; set; }
    }
}
