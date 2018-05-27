namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ADRES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ADRES()
        {
            ILAN = new HashSet<ILAN>();
        }

        public int ID { get; set; }

        public int? IL_ID { get; set; }

        public int? ILCE_ID { get; set; }

        public string MAHALLE { get; set; }

        [StringLength(200)]
        public string DETAY { get; set; }

        public virtual IL IL { get; set; }

        public virtual ILCE ILCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ILAN> ILAN { get; set; }
    }
}
