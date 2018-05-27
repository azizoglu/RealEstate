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
    public class ProfilController : Controller
    {
        // GET: Profil
        public ActionResult Index()
        {
            ProfilModel profil = new ProfilModel();
            profil.Kullanici = KULLANICI.GetKullanici();
            getBireyselUye();
            setIlIlceList();
            ViewData["SayfaBaslik"] = "PROFİL";
            MenuModel menu = getMenu(KULLANICI.GetKullanici());
            ViewBag.Menu = menu.MenuList;
            ViewBag.Menu = menu.MenuList;
            return View(profil);
        }

        public ActionResult ProfilGuncelle(ProfilModel _UyeModel)
        {
            DbBaglanti dbBaglanti = new DbBaglanti();
            DataTable dtResult = dbBaglanti.DataTableGetir("UYE_GUNCELLE "+KULLANICI.GetKullanici().UYE_ID+",'" + _UyeModel.BireyselUye.AD + "','" + _UyeModel.BireyselUye.SOYAD + "','"
                + _UyeModel.BireyselUye.CINSIYET + "','" + _UyeModel.BireyselUye.TEL_NO + "'," + "'" + _UyeModel.BireyselUye.EMAIL + "','" +
                _UyeModel.BireyselUye.ADRES + "','" + _UyeModel.BireyselUye.IL_ID + "','" + _UyeModel.BireyselUye.ILCE_ID + "','" +
                _UyeModel.Kullanici.KULLANICI_ADI + "','" + _UyeModel.Kullanici.SIFRE + "'");
            if (dtResult.Rows[0]["RESULT"].ToString() == "KAYIT BAŞARILI")
            {
                ViewData["result"] = dtResult.Rows[0]["RESULT"].ToString();
                return View("Index");
            }
            else
            {
                ViewData["result"] = dtResult.Rows[0]["RESULT"].ToString();
                return View("UyeKayit");
            }
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
                menu.MenuList.Add(new MenuModel("Eşleşen Talepler", "place", "../EslesenTalep/Index", "passive"));
                menu.MenuList.Add(new MenuModel("Profil", "person", "../Profil/Index", "active"));
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

        DbBaglanti dbEmlak = new DbBaglanti();
        private void getBireyselUye()
        {
            DataTable dtUye = dbEmlak.DataTableGetir("SELECT B.ID,B.AD,B.SOYAD,B.CINSIYET,B.TEL_NO,B.EMAIL,B.ADRES FROM [EMLAK].[dbo].[UYE]," +
                "BIREYSEL_UYE AS B WHERE UYE.UYE_ID=B.ID AND UYE.ID="+KULLANICI.GetKullanici().UYE_ID);
            List<BIREYSEL_UYE> BireyselUye = new List<BIREYSEL_UYE>();

            BireyselUye = (from DataRow row in dtUye.Rows
                     select new BIREYSEL_UYE
                     {
                         ID = Convert.ToInt32(row["ID"].ToString()),
                         AD = row["AD"].ToString(),
                         SOYAD = row["SOYAD"].ToString(),
                         CINSIYET = row["CINSIYET"].ToString(),
                         TEL_NO = row["TEL_NO"].ToString(),
                         EMAIL = row["EMAIL"].ToString(),
                         ADRES = row["ADRES"].ToString()

                     }).ToList();


            ViewBag.BireyselUye = BireyselUye[0];
        }
    }
}