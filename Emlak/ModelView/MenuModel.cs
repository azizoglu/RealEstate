using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emlak.ModelView
{
    public class MenuModel
    {
        public string ADI { get; set; }
        public string ICON { get; set; }
        public string ADRES { get; set; }
        public string AKTIF { get; set; }
        public MenuModel()
        {

        }
        public MenuModel(string _ADI, string _ICON, string _ADRES,string _AKTIF)
        {
            ADI = _ADI;
            ICON = _ICON;
            ADRES = _ADRES;
            AKTIF = _AKTIF;
        }

        public List<MenuModel> MenuList { get; set; }
    }
}