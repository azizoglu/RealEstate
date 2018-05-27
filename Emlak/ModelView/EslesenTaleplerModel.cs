using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emlak.ModelView
{
    public class EslesenTaleplerModel
    {
        public int ID { get; set; }
        public string BASLIK { get; set; }
        public string KATEGORI { get; set; }
        public string IL { get; set; }
        public string ILCE { get; set; }
        public string KOORDINAT_X { get; set; }
        public string KOORDINAT_Y { get; set; }
    }
}