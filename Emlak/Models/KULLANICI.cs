namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KULLANICI")]
    public partial class KULLANICI
    {
        private static KULLANICI Kullanici;

        public static KULLANICI GetKullanici()
        {
            if (Kullanici== null)
                Kullanici= new KULLANICI();

            return Kullanici;
        }
        public int ID { get; set; }

        public int UYE_ID { get; set; }

        public int? YETKI_ID { get; set; }

        [StringLength(150)]
        public string KULLANICI_ADI { get; set; }

        [StringLength(50)]
        public string SIFRE { get; set; }

        public virtual UYE UYE { get; set; }

        public virtual YETKI YETKI { get; set; }
    }
}
