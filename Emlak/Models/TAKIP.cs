namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAKIP")]
    public partial class TAKIP
    {
        public int ID { get; set; }

        public int? IL_ID { get; set; }

        public int? ILCE_ID { get; set; }

        public int? MAHALLE_ID { get; set; }

        [StringLength(200)]
        public string DETAY { get; set; }

        public virtual IL IL { get; set; }

        public virtual ILCE ILCE { get; set; }

        public virtual MAHALLE MAHALLE { get; set; }
    }
}
