namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ILAN")]
    public partial class ILAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ILAN()
        {
            ILAN_DIS_OZELLIK = new HashSet<ILAN_DIS_OZELLIK>();
            ILAN_IC_OZELLIK = new HashSet<ILAN_IC_OZELLIK>();
            ILAN_KONUM_OZELLIK = new HashSet<ILAN_KONUM_OZELLIK>();
            RESIM = new HashSet<RESIM>();
            SATIS = new HashSet<SATIS>();
        }

        public static string LATITUDE = "";
        public static string LONGITUDE= "";

        public int ID { get; set; }

        public int? UYE_ID { get; set; }

        public int? ADRES_ID { get; set; }

        public int? CEPHE_ID { get; set; }

        public int? KATEGORI_ID { get; set; }

        public int? ALT_KATEGORI_ID { get; set; }

        public int? KONUT_TIP_ID { get; set; }

        public int? ISINMA_TIP_ID { get; set; }

        [StringLength(150)]
        public string BASLIK { get; set; }

        public DateTime? YAYIN_SURESI { get; set; }

        public int? FIYAT { get; set; }

        public int? BINA_YASI { get; set; }

        public int? ODA_SAYISI { get; set; }

        public int? SALON_SAYISI { get; set; }

        public int? BANYO_SAYISI { get; set; }

        public int? M2 { get; set; }

        public bool? KREDIYE_UYGUNLUK { get; set; }

        public string ESYALI { get; set; }

        [StringLength(2000)]
        public string ACIKLAMA { get; set; }

        public string KOORDINAT_X { get; set; }

        public string KOORDINAT_Y { get; set; }

        public int? DURUM_ID { get; set; }

        public virtual ADRES ADRES { get; set; }

        public virtual ALT_KATEGORI ALT_KATEGORI { get; set; }

        public virtual CEPHE CEPHE { get; set; }

        public virtual DURUM DURUM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ILAN_DIS_OZELLIK> ILAN_DIS_OZELLIK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ILAN_IC_OZELLIK> ILAN_IC_OZELLIK { get; set; }

        public virtual ISINMA_TIP ISINMA_TIP { get; set; }

        public virtual KATEGORI KATEGORI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ILAN_KONUM_OZELLIK> ILAN_KONUM_OZELLIK { get; set; }

        public virtual KONUT_TIP KONUT_TIP { get; set; }

        public virtual UYE UYE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESIM> RESIM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SATIS> SATIS { get; set; }
    }
}
