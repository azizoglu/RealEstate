using Emlak.Database;
using Emlak.Models;
using Emlak.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emlak.Controllers
{
    public class IlanTakipController : Controller
    {
        // GET: IlanTakip
        public ActionResult Index(string lat, string lon)
        {
            ViewData["SayfaBaslik"] = "TALEP BİLDİR";
            MenuModel menu = getMenu(KULLANICI.GetKullanici());
            ViewBag.Menu = menu.MenuList;
            ViewBag.Menu = menu.MenuList;
            setIlIlceList();
            getTakipListesi();
            if (lat != null && lon != null)
            {
                ILAN.LATITUDE = lat;
                ILAN.LONGITUDE = lon;
            }
            return View(new IlanTakipModel());
        }
        public ActionResult IlanKonum()
        {
            ViewData["SayfaBaslik"] = "TALEP KONUM";
            MenuModel menu = getMenu(KULLANICI.GetKullanici());
            ViewBag.Menu = menu.MenuList;
            ViewBag.Menu = menu.MenuList;
            return View();
        }

        [HttpPost]
        public ActionResult TakipIslem(string id,string islem)
        {
            DataTable dt = dbEmlak.DataTableGetir("UPDATE TAKIP SET AKTIF='"+islem+"' WHERE ID='"+id+"'");
            return RedirectToAction("Index", "IlanTakip");
        }

        [HttpPost]
        public ActionResult TakipKayit(IlanTakipModel _IlanTakipModel)
        {
            DataTable dt = dbEmlak.DataTableGetir("TAKIP_KAYIT @UYE_ID="+KULLANICI.GetKullanici().UYE_ID+",@IL_ID=" + _IlanTakipModel.Adres.IL_ID + ",@ILCE_ID=" +
                _IlanTakipModel.Adres.ILCE_ID + ",@DETAY ='" + _IlanTakipModel.Adres.DETAY + "',@KOORDINAT_X='" +
                ILAN.LATITUDE + "',@KOORDINAT_Y='" + ILAN.LONGITUDE + "'");
            return RedirectToAction("Index", "Home");
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
                menu.MenuList.Add(new MenuModel("Talep Bildir", "notifications", "../IlanTakip/Index", "active"));
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
                menu.MenuList.Add(new MenuModel("Ana Sayfa", "home", "../Home/Index", "active"));
            }

            return menu;
        }

        DbBaglanti dbEmlak = new DbBaglanti();
        private void setIlIlceList()
        {
            DataTable dtIl = dbEmlak.DataTableGetir("SELECT*FROM IL");
            List<IL> Iller = new List<IL>();
            Iller = (from DataRow row in dtIl.Rows
                     select new IL
                     {
                         ID = Convert.ToInt32(row["ID"].ToString()),
                         ADI = row["ADI"].ToString()

                     }).ToList();

            DataTable dtIlce = dbEmlak.DataTableGetir("SELECT*FROM ILCE");
            List<ILCE> Ilceler = new List<ILCE>();
            Ilceler = (from DataRow row in dtIlce.Rows
                       select new ILCE
                       {
                           ID = Convert.ToInt32(row["ID"].ToString()),
                           ADI = row["ADI"].ToString()

                       }).ToList();

            ViewBag.Iller = new SelectList(Iller, "ID", "ADI");
            ViewBag.Ilceler = new SelectList(Ilceler, "ID", "ADI");
        }

        DbBaglanti db = new DbBaglanti();
        private void getTakipListesi()
        {
            DataTable dt = db.DataTableGetir("SELECT T.[ID], IL.ADI AS IL, ILCE.ADI AS ILCE,[DETAY],[KOORDINAT_X],[KOORDINAT_Y] " +
                "FROM[EMLAK].[dbo].[TAKIP] as T, IL, ILCE WHERE T.IL_ID = IL.ID AND T.ILCE_ID = ILCE.ID AND T.AKTIF=1");
            List<TakipListesiModel> TakipListesi = new List<TakipListesiModel>();
            TakipListesi = (from DataRow row in dt.Rows
                                 select new TakipListesiModel
                                 {
                                     ID = Convert.ToInt32(row["ID"].ToString()),
                                     IL = row["IL"].ToString(),
                                     ILCE= row["ILCE"].ToString(),
                                     DETAY = row["DETAY"].ToString(),
                                     KOORDINAT_X= row["KOORDINAT_X"].ToString(),
                                     KOORDINAT_Y = row["KOORDINAT_Y"].ToString()
                                 }).ToList();
            ViewBag.TakipListesi = TakipListesi;
        }
    }
}