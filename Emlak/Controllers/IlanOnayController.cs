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
    public class IlanOnayController : Controller
    {
        // GET: IlanVer
        public ActionResult Index()
        {
            ViewData["SayfaBaslik"] = "İLAN ONAY";
            MenuModel menu = getMenu(KULLANICI.GetKullanici());
            ViewBag.Menu = menu.MenuList;
            ViewBag.Menu = menu.MenuList;
            setIlanTalepleri();
            setOnaylananIlanlar();
            return View();
        }

        public ActionResult IlanOnay(string id,string islem)
        {
            db.DataTableGetir("UPDATE [EMLAK].[dbo].[ILAN] SET DURUM_ID='"+islem+"' WHERE ID='" + id + "'");

            return RedirectToAction("Index", "IlanOnay");
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
                menu.MenuList.Add(new MenuModel("İlan Onay", "place", "../IlanOnay/Index", "active"));
                menu.MenuList.Add(new MenuModel("Kullanıcı Listele", "person", "../KullaniciListele/Index", "passive"));
            }
            else
            {
                ViewData["Kullanici"] = "Giriş Yap";
                menu.MenuList.Add(new MenuModel("Ana Sayfa", "home", "../Home/Index", "active"));
            }

            return menu;
        }

        DbBaglanti db = new DbBaglanti();
        private void setIlanTalepleri()
        {
            DataTable dt = db.DataTableGetir("SELECT I.ID,I.BASLIK, IL.ADI AS IL, ILCE.ADI AS ILCE, A.DETAY,[YAYIN_SURESI],[FIYAT],[KOORDINAT_X],[KOORDINAT_Y] " +
                            "FROM[EMLAK].[dbo].[ILAN] AS I, ADRES AS A, IL, ILCE WHERE I.ADRES_ID = A.ID AND IL.ID = A.IL_ID AND ILCE.ID = A.ILCE_ID AND I.DURUM_ID=1");
            List<IlanTalepModel> TalepEdilenIlanlar= new List<IlanTalepModel>();
            TalepEdilenIlanlar = (from DataRow row in dt.Rows
                     select new IlanTalepModel
                     {
                         ID = Convert.ToInt32(row["ID"].ToString()),
                         BASLIK = row["BASLIK"].ToString(),
                         IL = row["IL"].ToString(),
                         ILCE = row["ILCE"].ToString(),
                         DETAY = row["DETAY"].ToString(),
                         YAYIN_SURESI = row["YAYIN_SURESI"].ToString(),
                         FIYAT = row["FIYAT"].ToString(),
                         KOORDINAT_X = row["KOORDINAT_X"].ToString(),
                         KOORDINAT_Y = row["KOORDINAT_Y"].ToString()
                     }).ToList();

            ViewBag.TalepEdilenIlanlar = TalepEdilenIlanlar;
        }

        private void setOnaylananIlanlar()
        {
            DataTable dt = db.DataTableGetir("SELECT I.ID,I.BASLIK, IL.ADI AS IL, ILCE.ADI AS ILCE, A.DETAY,[YAYIN_SURESI],[FIYAT],[KOORDINAT_X],[KOORDINAT_Y] " +
                            "FROM[EMLAK].[dbo].[ILAN] AS I, ADRES AS A, IL, ILCE WHERE I.ADRES_ID = A.ID AND IL.ID = A.IL_ID AND ILCE.ID = A.ILCE_ID AND I.DURUM_ID=2");
            List<IlanTalepModel> OnaylananIlanlar = new List<IlanTalepModel>();
            OnaylananIlanlar = (from DataRow row in dt.Rows
                                  select new IlanTalepModel
                                  {
                                      ID = Convert.ToInt32(row["ID"].ToString()),
                                      BASLIK = row["BASLIK"].ToString(),
                                      IL = row["IL"].ToString(),
                                      ILCE = row["ILCE"].ToString(),
                                      DETAY = row["DETAY"].ToString(),
                                      YAYIN_SURESI = row["YAYIN_SURESI"].ToString(),
                                      FIYAT = row["FIYAT"].ToString(),
                                      KOORDINAT_X = row["KOORDINAT_X"].ToString(),
                                      KOORDINAT_Y = row["KOORDINAT_Y"].ToString()
                                  }).ToList();
            ViewBag.OnaylananIlanlar = OnaylananIlanlar;
        }

    }
}