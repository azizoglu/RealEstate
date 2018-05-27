namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ILAN_KONUM_OZELLIK
    {
        public int ID { get; set; }

        public int? KONUM_OZELLIK_ID { get; set; }

        public int? ILAN_ID { get; set; }

        public virtual ILAN ILAN { get; set; }

        public virtual KONUM_OZELLIK KONUM_OZELLIK { get; set; }
    }
}
