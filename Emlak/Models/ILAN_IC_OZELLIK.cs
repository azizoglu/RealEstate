namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ILAN_IC_OZELLIK
    {
        public int ID { get; set; }

        public int? IC_OZELLIK_ID { get; set; }

        public int? ILAN_ID { get; set; }

        public virtual IC_OZELLIK IC_OZELLIK { get; set; }

        public virtual ILAN ILAN { get; set; }
    }
}
