using Emlak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emlak.ModelView
{
    public class IlanTakipModel
    {
        public int ID { get; set; }

        public ADRES Adres { get; set; }

        public string KOORDINAT_X { get; set; }
        public string KOORDINAT_Y { get; set; }
    }
}