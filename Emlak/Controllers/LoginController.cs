using Emlak.Database;
using Emlak.Models;
using Emlak.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Emlak.Controllers
{
    public class LoginController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            setIlIlceList();
            return View();
        }

        public ActionResult UyeKayit()
        { 
            UyeKayitModel UyeModel = new UyeKayitModel();
            setIlIlceList();
            return View(UyeModel);
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



        public ActionResult UyeKayitAction(UyeKayitModel _UyeModel)
        {
            DbBaglanti dbBaglanti = new DbBaglanti();
            DataTable dtResult= dbBaglanti.DataTableGetir("UYE_EKLE '" +_UyeModel.BireyselUye.AD+"','"+ _UyeModel.BireyselUye.SOYAD+ "','"
                + _UyeModel.BireyselUye.CINSIYET+ "','"+_UyeModel.BireyselUye.TEL_NO+"'," +"'"+ _UyeModel.BireyselUye.EMAIL+"','"+
                _UyeModel.BireyselUye.ADRES+"','"+ _UyeModel.BireyselUye.IL_ID+"','"+ _UyeModel.BireyselUye.ILCE_ID+"','"+
                _UyeModel.Kullanici.KULLANICI_ADI+"','"+_UyeModel.Kullanici.SIFRE+ "'");
            if (dtResult.Rows[0]["RESULT"].ToString()=="KAYIT BAŞARILI")
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



        /*** Kullanıcı Giriş Kontrolü ***/
        DbBaglanti dbEmlak = new DbBaglanti();
        public ActionResult LoginAction(KULLANICI kullanici)
        {
            if (kullanici!= null)
            {
                DataTable dt = dbEmlak.DataTableGetir("KULLANICI_KONTROL '"+kullanici.KULLANICI_ADI+"','"+kullanici.SIFRE+"'");
                if (dt.Rows.Count>0)
                {
                    KULLANICI Kullanici=KULLANICI.GetKullanici();
                    Kullanici.UYE_ID = Convert.ToInt32(dt.Rows[0]["UYE_ID"].ToString());
                    Kullanici.KULLANICI_ADI = dt.Rows[0]["KULLANICI_ADI"].ToString();
                    Kullanici.SIFRE = dt.Rows[0]["SIFRE"].ToString();
                    Kullanici.YETKI_ID = Convert.ToInt32(dt.Rows[0]["YETKI_ID"].ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["result"]= "Kullanıcı Bulunamadı";
                   
                }
            }
            return View("Index");
        }
    }
}