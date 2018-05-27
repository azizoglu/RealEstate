namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TALEP")]
    public partial class TALEP
    {
        public int ID { get; set; }

        public int? ILAN_ID { get; set; }

        public int? ILAN_SAHIP_ID { get; set; }

        public int? TALEP_EDEN_ID { get; set; }

        public int? TALEP_DURUM_ID { get; set; }

        public virtual TALEP_DURUM TALEP_DURUM { get; set; }

        public virtual UYE UYE { get; set; }

        public virtual UYE UYE1 { get; set; }
    }
}
