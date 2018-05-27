namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DIS_OZELLIK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIS_OZELLIK()
        {
            ILAN_DIS_OZELLIK = new HashSet<ILAN_DIS_OZELLIK>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string ADI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ILAN_DIS_OZELLIK> ILAN_DIS_OZELLIK { get; set; }
    }
}
