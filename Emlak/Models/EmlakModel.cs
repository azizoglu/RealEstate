namespace Emlak.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmlakModel : DbContext
    {
        public EmlakModel()
            : base("name=EmlakEntities")
        {
        }

        public virtual DbSet<ADRES> ADRES { get; set; }
        public virtual DbSet<ALT_KATEGORI> ALT_KATEGORI { get; set; }
        public virtual DbSet<BIREYSEL_UYE> BIREYSEL_UYE { get; set; }
        public virtual DbSet<CEPHE> CEPHE { get; set; }
        public virtual DbSet<DIS_OZELLIK> DIS_OZELLIK { get; set; }
        public virtual DbSet<DURUM> DURUM { get; set; }
        public virtual DbSet<IC_OZELLIK> IC_OZELLIK { get; set; }
        public virtual DbSet<IL> IL { get; set; }
        public virtual DbSet<ILAN> ILAN { get; set; }
        public virtual DbSet<ILAN_DIS_OZELLIK> ILAN_DIS_OZELLIK { get; set; }
        public virtual DbSet<ILAN_IC_OZELLIK> ILAN_IC_OZELLIK { get; set; }
        public virtual DbSet<ILAN_KONUM_OZELLIK> ILAN_KONUM_OZELLIK { get; set; }
        public virtual DbSet<ILCE> ILCE { get; set; }
        public virtual DbSet<ISINMA_TIP> ISINMA_TIP { get; set; }
        public virtual DbSet<KATEGORI> KATEGORI { get; set; }
        public virtual DbSet<KONUM_OZELLIK> KONUM_OZELLIK { get; set; }
        public virtual DbSet<KONUT_TIP> KONUT_TIP { get; set; }
        public virtual DbSet<KULLANICI> KULLANICI { get; set; }
        public virtual DbSet<KURUMSAL_TUR> KURUMSAL_TUR { get; set; }
        public virtual DbSet<KURUMSAL_UYE> KURUMSAL_UYE { get; set; }
        public virtual DbSet<MAHALLE> MAHALLE { get; set; }
        public virtual DbSet<RESIM> RESIM { get; set; }
        public virtual DbSet<SATIS> SATIS { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TAKIP> TAKIP { get; set; }
        public virtual DbSet<TALEP> TALEP { get; set; }
        public virtual DbSet<TALEP_DURUM> TALEP_DURUM { get; set; }
        public virtual DbSet<UYE> UYE { get; set; }
        public virtual DbSet<YETKI> YETKI { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADRES>()
                .HasMany(e => e.ILAN)
                .WithOptional(e => e.ADRES)
                .HasForeignKey(e => e.ADRES_ID);

            modelBuilder.Entity<ALT_KATEGORI>()
                .HasMany(e => e.ILAN)
                .WithOptional(e => e.ALT_KATEGORI)
                .HasForeignKey(e => e.ALT_KATEGORI_ID);

            modelBuilder.Entity<BIREYSEL_UYE>()
                .HasMany(e => e.UYE)
                .WithRequired(e => e.BIREYSEL_UYE)
                .HasForeignKey(e => e.UYE_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CEPHE>()
                .HasMany(e => e.ILAN)
                .WithOptional(e => e.CEPHE)
                .HasForeignKey(e => e.CEPHE_ID);

            modelBuilder.Entity<DIS_OZELLIK>()
                .HasMany(e => e.ILAN_DIS_OZELLIK)
                .WithOptional(e => e.DIS_OZELLIK)
                .HasForeignKey(e => e.DIS_OZELLIK_ID);

            modelBuilder.Entity<DURUM>()
                .HasMany(e => e.ILAN)
                .WithOptional(e => e.DURUM)
                .HasForeignKey(e => e.DURUM_ID);

            modelBuilder.Entity<IC_OZELLIK>()
                .HasMany(e => e.ILAN_IC_OZELLIK)
                .WithOptional(e => e.IC_OZELLIK)
                .HasForeignKey(e => e.IC_OZELLIK_ID);

            modelBuilder.Entity<IL>()
                .Property(e => e.KODU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<IL>()
                .HasMany(e => e.ADRES)
                .WithOptional(e => e.IL)
                .HasForeignKey(e => e.IL_ID);

            modelBuilder.Entity<IL>()
                .HasMany(e => e.ILCE)
                .WithRequired(e => e.IL)
                .HasForeignKey(e => e.IL_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IL>()
                .HasMany(e => e.TAKIP)
                .WithOptional(e => e.IL)
                .HasForeignKey(e => e.IL_ID);


            modelBuilder.Entity<ILAN>()
                .HasMany(e => e.ILAN_DIS_OZELLIK)
                .WithOptional(e => e.ILAN)
                .HasForeignKey(e => e.ILAN_ID);

            modelBuilder.Entity<ILAN>()
                .HasMany(e => e.ILAN_IC_OZELLIK)
                .WithOptional(e => e.ILAN)
                .HasForeignKey(e => e.ILAN_ID);

            modelBuilder.Entity<ILAN>()
                .HasMany(e => e.ILAN_KONUM_OZELLIK)
                .WithOptional(e => e.ILAN)
                .HasForeignKey(e => e.ILAN_ID);

            modelBuilder.Entity<ILAN>()
                .HasMany(e => e.RESIM)
                .WithOptional(e => e.ILAN)
                .HasForeignKey(e => e.ILAN_ID);

            modelBuilder.Entity<ILAN>()
                .HasMany(e => e.SATIS)
                .WithOptional(e => e.ILAN)
                .HasForeignKey(e => e.SATILAN_ILAN_ID);

            modelBuilder.Entity<ILCE>()
                .HasMany(e => e.ADRES)
                .WithOptional(e => e.ILCE)
                .HasForeignKey(e => e.ILCE_ID);

            modelBuilder.Entity<ILCE>()
                .HasMany(e => e.TAKIP)
                .WithOptional(e => e.ILCE)
                .HasForeignKey(e => e.ILCE_ID);

            modelBuilder.Entity<ISINMA_TIP>()
                .HasMany(e => e.ILAN)
                .WithOptional(e => e.ISINMA_TIP)
                .HasForeignKey(e => e.ISINMA_TIP_ID);

            modelBuilder.Entity<KATEGORI>()
                .HasMany(e => e.ILAN)
                .WithOptional(e => e.KATEGORI)
                .HasForeignKey(e => e.KATEGORI_ID);

            modelBuilder.Entity<KONUM_OZELLIK>()
                .HasMany(e => e.ILAN_KONUM_OZELLIK)
                .WithOptional(e => e.KONUM_OZELLIK)
                .HasForeignKey(e => e.KONUM_OZELLIK_ID);

            modelBuilder.Entity<KONUT_TIP>()
                .HasMany(e => e.ILAN)
                .WithOptional(e => e.KONUT_TIP)
                .HasForeignKey(e => e.KONUT_TIP_ID);

            modelBuilder.Entity<KURUMSAL_TUR>()
                .HasMany(e => e.KURUMSAL_UYE)
                .WithOptional(e => e.KURUMSAL_TUR)
                .HasForeignKey(e => e.KURUMSAL_TUR_ID);


            modelBuilder.Entity<MAHALLE>()
                .HasMany(e => e.TAKIP)
                .WithOptional(e => e.MAHALLE)
                .HasForeignKey(e => e.MAHALLE_ID);

            modelBuilder.Entity<TALEP_DURUM>()
                .HasMany(e => e.TALEP)
                .WithOptional(e => e.TALEP_DURUM)
                .HasForeignKey(e => e.TALEP_DURUM_ID);

            modelBuilder.Entity<UYE>()
                .HasMany(e => e.ILAN)
                .WithOptional(e => e.UYE)
                .HasForeignKey(e => e.UYE_ID);

            modelBuilder.Entity<UYE>()
                .HasMany(e => e.KULLANICI)
                .WithOptional(e => e.UYE)
                .HasForeignKey(e => e.UYE_ID);

            modelBuilder.Entity<UYE>()
                .HasMany(e => e.SATIS)
                .WithOptional(e => e.UYE)
                .HasForeignKey(e => e.SATIN_ALAN_ID);

            modelBuilder.Entity<UYE>()
                .HasMany(e => e.SATIS1)
                .WithOptional(e => e.UYE1)
                .HasForeignKey(e => e.SATIS_GERCEKLESTIREN_ID);

            modelBuilder.Entity<UYE>()
                .HasMany(e => e.TALEP)
                .WithOptional(e => e.UYE)
                .HasForeignKey(e => e.TALEP_EDEN_ID);

            modelBuilder.Entity<UYE>()
                .HasMany(e => e.TALEP1)
                .WithOptional(e => e.UYE1)
                .HasForeignKey(e => e.ILAN_SAHIP_ID);

            modelBuilder.Entity<YETKI>()
                .HasMany(e => e.KULLANICI)
                .WithOptional(e => e.YETKI)
                .HasForeignKey(e => e.YETKI_ID);
        }
    }
}
