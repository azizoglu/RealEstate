namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IC_OZELLIK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IC_OZELLIK()
        {
            ILAN_IC_OZELLIK = new HashSet<ILAN_IC_OZELLIK>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ADI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ILAN_IC_OZELLIK> ILAN_IC_OZELLIK { get; set; }
    }
}
