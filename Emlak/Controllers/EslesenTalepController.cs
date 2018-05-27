using Emlak.Database;
using Emlak.Models;
using Emlak.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emlak.Controllers
{
    public class EslesenTalepController : Controller
    {
        // GET: IlanVer
        public ActionResult Index()
        {
            ViewData["SayfaBaslik"] = "EŞLEŞEN TALEPLER";
            MenuModel menu = getMenu(KULLANICI.GetKullanici());
            ViewBag.Menu = menu.MenuList;
            ViewBag.Menu = menu.MenuList;
            getEslesenTalepler();
            return View();
        }


        private MenuModel getMenu(KULLANICI _Kullanici)
        {
            MenuModel menu = new MenuModel();
            menu.MenuList = new List<MenuModel>();

            if (_Kullanici.YETKI_ID == 1)
            {
                ViewData["Kullanici"] = _Kullanici.KULLANICI_ADI;
                menu.MenuList.Add(new MenuModel("Ana Sayfa", "home", "../Home/Index", "passive"));
                menu.MenuList.Add(new MenuModel("İlan Ver", "place", "../IlanVer/Index", "passive"));
                menu.MenuList.Add(new MenuModel("Talep Bildir", "notifications", "../IlanTakip/Index", "passive"));
                menu.MenuList.Add(new MenuModel("Eşleşen Talepler", "place", "../EslesenTalep/Index", "active"));
                menu.MenuList.Add(new MenuModel("Profil", "person", "", "passive"));
            }
            else if (_Kullanici.YETKI_ID == 2)
            {
                ViewData["Kullanici"] = _Kullanici.KULLANICI_ADI;
                menu.MenuList.Add(new MenuModel("Ana Sayfa", "home", "../Home/Index", "passive"));
                menu.MenuList.Add(new MenuModel("İlan Onay", "place", "../IlanOnay/Index", "passive"));
                menu.MenuList.Add(new MenuModel("Kullanıcı Listele", "person", "../KullaniciListele/Index", "active"));
            }
            else
            {
                ViewData["Kullanici"] = "Giriş Yap";
                menu.MenuList.Add(new MenuModel("Ana Sayfa", "home", "../Home/Index", "active"));
            }

            return menu;
        }

        DbBaglanti db = new DbBaglanti();
        private void getEslesenTalepler()
        {
            DataTable dt = db.DataTableGetir("ESLESEN_TALEPLER '"+KULLANICI.GetKullanici().UYE_ID+"'");
            List<EslesenTaleplerModel> EslesenTalepler= new List<EslesenTaleplerModel>();
            EslesenTalepler= (from DataRow row in dt.Rows
                     select new EslesenTaleplerModel
                     {
                         ID = Convert.ToInt32(row["ID"].ToString()),
                         BASLIK = row["BASLIK"].ToString(),
                         KATEGORI = row["KATEGORI"].ToString(),
                         IL = row["IL"].ToString(),
                         ILCE = row["ILCE"].ToString(),
                         KOORDINAT_X = row["KOORDINAT_X"].ToString(),
                         KOORDINAT_Y = row["KOORDINAT_Y"].ToString()
                     }).ToList();
            ViewBag.EslesenTalepler = EslesenTalepler;
        }
    }
}