namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KURUMSAL_TUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KURUMSAL_TUR()
        {
            KURUMSAL_UYE = new HashSet<KURUMSAL_UYE>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string AD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KURUMSAL_UYE> KURUMSAL_UYE { get; set; }
    }
}
