namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KONUM_OZELLIK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KONUM_OZELLIK()
        {
            ILAN_KONUM_OZELLIK = new HashSet<ILAN_KONUM_OZELLIK>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string ADI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ILAN_KONUM_OZELLIK> ILAN_KONUM_OZELLIK { get; set; }
    }
}
