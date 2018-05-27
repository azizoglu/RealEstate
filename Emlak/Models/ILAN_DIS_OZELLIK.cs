namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ILAN_DIS_OZELLIK
    {
        public int ID { get; set; }

        public int? DIS_OZELLIK_ID { get; set; }

        public int? ILAN_ID { get; set; }

        public virtual DIS_OZELLIK DIS_OZELLIK { get; set; }

        public virtual ILAN ILAN { get; set; }
    }
}
