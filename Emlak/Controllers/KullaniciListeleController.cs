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
    public class KullaniciListeleController : Controller
    {
        // GET: IlanVer
        public ActionResult Index()
        {
            ViewData["SayfaBaslik"] = "KULLANICI LİSTESİ";
            MenuModel menu = getMenu(KULLANICI.GetKullanici());
            ViewBag.Menu = menu.MenuList;
            ViewBag.Menu = menu.MenuList;
            setAktifKullanici();
            setPasifKullanici();
            return View();
        }

        public ActionResult KullaniciIslem(string id,string islem)
        {
            db.DataTableGetir("UPDATE [EMLAK].[dbo].[UYE] SET UYE_DURUMU='" + islem+"' WHERE ID='" + id + "'");

            return RedirectToAction("Index", "KullaniciListele");
        }

        private MenuModel getMenu(KULLANICI _Kullanici)
        {
            MenuModel menu = new MenuModel();
            menu.MenuList = new List<MenuModel>();

            if (_Kullanici.YETKI_ID == 1)
            {
                ViewData["Kullanici"] = _Kullanici.KULLANICI_ADI;
                menu.MenuList.Add(new MenuModel("Ana Sayfa", "home", "../Home/Index", "active"));
                menu.MenuList.Add(new MenuModel("İlan Ver", "place", "../IlanVer/Index", "passive"));
                menu.MenuList.Add(new MenuModel("Talep Bildir", "notifications", "../IlanTakip/Index", "passive"));
                menu.MenuList.Add(new MenuModel("Eşleşen Talepler", "place", "../EslesenTalep/Index", "passive"));
                menu.MenuList.Add(new MenuModel("Profil", "person", "../Profil/Index", "passive"));
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
        private void setAktifKullanici()
        {
            DataTable dt = db.DataTableGetir("SELECT K.UYE_ID,B.AD,B.SOYAD,Y.ADI AS YETKI,[KULLANICI_ADI] " +
                "FROM[EMLAK].[dbo].[KULLANICI] AS K, UYE, BIREYSEL_UYE AS B, YETKI AS Y WHERE K.UYE_ID = UYE.ID AND UYE.UYE_ID = B.ID AND Y.ID = K.YETKI_ID AND UYE.UYE_DURUMU=1");
            List<KullaniciListeModel> AktifKullanicilar= new List<KullaniciListeModel>();
            AktifKullanicilar = (from DataRow row in dt.Rows
                     select new KullaniciListeModel
                     {
                         ID = Convert.ToInt32(row["UYE_ID"].ToString()),
                         AD = row["AD"].ToString(),
                         SOYAD = row["SOYAD"].ToString(),
                         YETKI = row["YETKI"].ToString(),
                         KULLANICI_ADI = row["KULLANICI_ADI"].ToString()
                     }).ToList();
            ViewBag.AktifKullanicilar = AktifKullanicilar;
        }

        private void setPasifKullanici()
        {
            DataTable dt = db.DataTableGetir("SELECT K.UYE_ID,B.AD,B.SOYAD,Y.ADI AS YETKI,[KULLANICI_ADI] " +
                "FROM[EMLAK].[dbo].[KULLANICI] AS K, UYE, BIREYSEL_UYE AS B, YETKI AS Y WHERE K.UYE_ID = UYE.ID AND UYE.UYE_ID = B.ID AND Y.ID = K.YETKI_ID AND UYE.UYE_DURUMU=0");
            List<KullaniciListeModel> PasifKullanicilar = new List<KullaniciListeModel>();
            PasifKullanicilar = (from DataRow row in dt.Rows
                                 select new KullaniciListeModel
                                 {
                                     ID = Convert.ToInt32(row["UYE_ID"].ToString()),
                                     AD = row["AD"].ToString(),
                                     SOYAD = row["SOYAD"].ToString(),
                                     YETKI = row["YETKI"].ToString(),
                                     KULLANICI_ADI = row["KULLANICI_ADI"].ToString()
                                 }).ToList();
            ViewBag.PasifKullanicilar = PasifKullanicilar;
        }

    }
}