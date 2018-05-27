namespace Emlak.ModelView
{
    using Emlak.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public class IlanKayitModel
    {

        private static IlanKayitModel IlanKayit;

        public static IlanKayitModel GetIlanKayit()
        {
            if (IlanKayit == null)
                IlanKayit = new IlanKayitModel();

            return IlanKayit;
        }

        public static void SetIlanKayit(IlanKayitModel _IlanKayitModel)
        {
            IlanKayit = _IlanKayitModel;
        }

        public ADRES Adres { get; set; }
        public ILAN Ilan { get; set; }

        public enum Esya
        {
            EVET, HAYIR
        }

        public Esya _Esya { get; set; }

        public static IEnumerable<SelectListItem> GetEsya()
        {
            yield return new SelectListItem { Text = "EVET", Value = "EVET" };
            yield return new SelectListItem { Text = "HAYIR", Value = "HAYIR" };
        }
    }
}
