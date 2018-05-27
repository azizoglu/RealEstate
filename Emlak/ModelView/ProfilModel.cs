namespace Emlak.ModelView
{
    using Emlak.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public class ProfilModel
    {
        public KULLANICI Kullanici { get; set; }
        public BIREYSEL_UYE BireyselUye { get; set; }
        public ADRES Adres { get; set; }

        public enum Cinsiyet
        {
            ERKEK, KADIN
        }

        public Cinsiyet _Cinsiyet { get; set; }

        public static IEnumerable<SelectListItem> GetCinsiyetler()
        {
            yield return new SelectListItem { Text = "ERKEK", Value = "ERKEK" };
            yield return new SelectListItem { Text = "KADIN", Value = "KADIN" };
        }
    }
}
