namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SATIS
    {
        public int ID { get; set; }

        public int? SATILAN_ILAN_ID { get; set; }

        public int? SATIN_ALAN_ID { get; set; }

        public int? SATIS_GERCEKLESTIREN_ID { get; set; }

        public virtual ILAN ILAN { get; set; }

        public virtual UYE UYE { get; set; }

        public virtual UYE UYE1 { get; set; }
    }
}
