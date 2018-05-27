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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["SayfaBaslik"] = "Ana Sayfa";
            MenuModel menu = getMenu(KULLANICI.GetKullanici());
            ViewBag.Menu = menu.MenuList;
            getAktifIlanlar();
            return View();
        }


        DbBaglanti db = new DbBaglanti();
        private void getAktifIlanlar()
        {
            DataTable dtAktifIlanlar = db.DataTableGetir("SELECT I.[ID],B.AD,B.SOYAD,IL.ADI AS IL,ILCE.ADI AS ILCE,K.ADI AS KATEGORI,[BASLIK],[YAYIN_SURESI],[FIYAT],[ACIKLAMA] "+
                "FROM[EMLAK].[dbo].[ILAN] AS I, ADRES AS A, KATEGORI AS K, UYE, BIREYSEL_UYE AS B, IL, ILCE " +
                "WHERE I.ADRES_ID = A.ID AND I.KATEGORI_ID = K.ID AND I.UYE_ID = UYE.ID AND UYE.UYE_ID = B.ID AND IL.ID = A.IL_ID AND ILCE.ID = A.ILCE_ID AND I.DURUM_ID = 2");
            List<IlanDashboard> Ilanlar = new List<IlanDashboard>();
            Ilanlar = (from DataRow row in dtAktifIlanlar.Rows
                                 select new IlanDashboard
                                 {
                                     ID = Convert.ToInt32(row["ID"].ToString()),
                                     AD = row["AD"].ToString(),
                                     SOYAD = row["SOYAD"].ToString(),
                                     IL = row["IL"].ToString(),
                                     ILCE = row["ILCE"].ToString(),
                                     KATEGORI = row["KATEGORI"].ToString(),
                                     BASLIK = row["BASLIK"].ToString(),
                                     YAYIN_SURESI = row["YAYIN_SURESI"].ToString(),
                                     FIYAT = row["FIYAT"].ToString(),
                                     ACIKLAMA = row["ACIKLAMA"].ToString()
                                 }).ToList();
            ViewBag.Ilanlar = Ilanlar;
        }

        private MenuModel getMenu(KULLANICI _Kullanici)
        {
            MenuModel menu = new MenuModel();
            menu.MenuList = new List<MenuModel>();

            if (_Kullanici.YETKI_ID==1)
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
                menu.MenuList.Add(new MenuModel("Ana Sayfa", "home", "../Home/Index", "active"));
                menu.MenuList.Add(new MenuModel("İlan Onay", "place", "../IlanOnay/Index", "passive"));
                menu.MenuList.Add(new MenuModel("Kullanıcı Listele", "person", "../KullaniciListele/Index", "passive"));
            }
            else
            {
                ViewData["Kullanici"] = "Giriş Yap";
                menu.MenuList.Add(new MenuModel("Ana Sayfa", "home", "./Home/Index", "active"));
            }

            return menu;
        }
    }
}