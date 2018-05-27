namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RESIM")]
    public partial class RESIM
    {
        public int ID { get; set; }

        public int? ILAN_ID { get; set; }

        [StringLength(50)]
        public string AD { get; set; }

        public string LINK { get; set; }

        public virtual ILAN ILAN { get; set; }
    }
}
