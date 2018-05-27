namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BIREYSEL_UYE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BIREYSEL_UYE()
        {
            UYE = new HashSet<UYE>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string AD { get; set; }

        [StringLength(50)]
        public string SOYAD { get; set; }

        [StringLength(10)]
        public string CINSIYET { get; set; }

        [StringLength(15)]
        public string TEL_NO { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(150)]
        public string ADRES { get; set; }

        public int IL_ID { get; set; }

        public int ILCE_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UYE> UYE { get; set; }
    }
}
