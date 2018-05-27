using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emlak.ModelView
{
    public class TakipListesiModel
    {
        public int ID { get; set; }
        public string IL { get; set; }
        public string ILCE { get; set; }
        public string DETAY { get; set; }

        public string KOORDINAT_X { get; set; }
        public string KOORDINAT_Y { get; set; }
    }
}