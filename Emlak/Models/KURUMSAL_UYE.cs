namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KURUMSAL_UYE
    {
        public int ID { get; set; }

        public int? KURUMSAL_TUR_ID { get; set; }

        [StringLength(100)]
        public string RESMI_AD { get; set; }

        [StringLength(100)]
        public string KISA_AD { get; set; }

        [StringLength(100)]
        public string YETKILI_AD { get; set; }

        [StringLength(100)]
        public string YETKILI_SOYAD { get; set; }

        public DateTime? DOGUM_TARIHI { get; set; }

        [StringLength(15)]
        public string TEL_NO { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        public int? IL_ID { get; set; }

        public int? ILCE_ID { get; set; }

        [StringLength(150)]
        public string ADRES { get; set; }

        public virtual KURUMSAL_TUR KURUMSAL_TUR { get; set; }
    }
}
