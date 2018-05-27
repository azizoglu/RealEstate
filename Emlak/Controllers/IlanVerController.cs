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
    public class IlanVerController : Controller
    {
        // GET: IlanVer
        public ActionResult Index(string lat, string lon)
        {
            ViewData["SayfaBaslik"] = "İLAN TALEP";
            MenuModel menu = getMenu(KULLANICI.GetKullanici());
            ViewBag.Menu = menu.MenuList;
            ViewBag.Menu = menu.MenuList;
            setIlIlceList();
            setKategoriList();
            setKonutTipList();
            setCepheList();
            setIsinmaTipList();
            if (lat!=null && lon!=null)
            {
                ILAN.LATITUDE = lat;
                ILAN.LONGITUDE = lon;
            }
            return View(IlanKayitModel.GetIlanKayit());
        }

        public ActionResult IlanKonum()
        {
            ViewData["SayfaBaslik"] = "İLAN KONUM";
            MenuModel menu = getMenu(KULLANICI.GetKullanici());
            ViewBag.Menu = menu.MenuList;
            ViewBag.Menu = menu.MenuList;
            return View();
        }
        

        [HttpPost]
        public ActionResult IlanTalep(IlanKayitModel _IlanKayitModel , string txtYayinSuresi, HttpPostedFileBase file)
        {
            string FileName = "Default_Emlak.png";
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/Resources/Images"), pic);
                file.SaveAs(path);
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                FileName = file.FileName;
            }
            _IlanKayitModel.Ilan.YAYIN_SURESI = Convert.ToDateTime(txtYayinSuresi);
            int uye_id = KULLANICI.GetKullanici().UYE_ID;
            DataTable dt = dbEmlak.DataTableGetir("ILAN_TALEP @UYE_ID=" + uye_id + ",@IL_ID=" + _IlanKayitModel.Adres.IL_ID + ",@ILCE_ID=" +
                _IlanKayitModel.Adres.ILCE_ID + ",@MAHALLE='',@DETAY ='" + _IlanKayitModel.Adres.DETAY + "',@CEPHE_ID=" +
                _IlanKayitModel.Ilan.CEPHE_ID + ",@KATEGORI_ID=" + _IlanKayitModel.Ilan.KATEGORI_ID + ",@KONUT_TIP_ID=" + _IlanKayitModel.Ilan.KONUT_TIP_ID + ",@ISINMA_TIP_ID =" +
                _IlanKayitModel.Ilan.ISINMA_TIP_ID + ",@BASLIK='" + _IlanKayitModel.Ilan.BASLIK + "',@YAYIN_SURESI='" + _IlanKayitModel.Ilan.YAYIN_SURESI + "',@FIYAT=" +
                _IlanKayitModel.Ilan.FIYAT + ",@BINA_YASI=" + _IlanKayitModel.Ilan.BINA_YASI + ",@ODA_SAYISI=" + _IlanKayitModel.Ilan.ODA_SAYISI + ",@SALON_SAYISI=" + _IlanKayitModel.Ilan.SALON_SAYISI + ",@BANYO_SAYISI="+
                _IlanKayitModel.Ilan.BANYO_SAYISI + ",@M2=" + _IlanKayitModel.Ilan.M2 + ",@ESYALI='" + _IlanKayitModel.Ilan.ESYALI + "',@ACIKLAMA='" + _IlanKayitModel.Ilan.ACIKLAMA + "',@KOORDINAT_X='" +
                ILAN.LATITUDE + "',@KOORDINAT_Y='" + ILAN.LONGITUDE+ "',@RESIM='" + FileName+"'");
            if (dt.Rows[0]["RESULT"].ToString()=="KAYIT BAŞARILI")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "IlanVer");
            }
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

        private void setKategoriList()
        {
            DataTable dtKategori = dbEmlak.DataTableGetir("SELECT*FROM KATEGORI");
            List<KATEGORI> Kategori = new List<KATEGORI>();
            Kategori = (from DataRow row in dtKategori.Rows
                            select new KATEGORI
                            {
                                ID = Convert.ToInt32(row["ID"].ToString()),
                                ADI = row["ADI"].ToString()

                            }).ToList();

            ViewBag.Kategoriler = new SelectList(Kategori, "ID", "ADI");
        }
        private void setKonutTipList()
        {
            DataTable dtKonutTipi = dbEmlak.DataTableGetir("SELECT*FROM KONUT_TIP");
            List<KONUT_TIP> KonutTipleri = new List<KONUT_TIP>();
            KonutTipleri = (from DataRow row in dtKonutTipi.Rows
                       select new KONUT_TIP
                       {
                           ID = Convert.ToInt32(row["ID"].ToString()),
                           TIPI = row["TIPI"].ToString()

                       }).ToList();

            ViewBag.KonutTipleri = new SelectList(KonutTipleri, "ID", "TIPI");
        }

        private void setCepheList()
        {
            DataTable dtCephe = dbEmlak.DataTableGetir("SELECT*FROM CEPHE");
            List<CEPHE> Cepheler = new List<CEPHE>();
            Cepheler = (from DataRow row in dtCephe.Rows
                            select new CEPHE
                            {
                                ID = Convert.ToInt32(row["ID"].ToString()),
                                ADI = row["ADI"].ToString()

                            }).ToList();

            ViewBag.Cepheler = new SelectList(Cepheler, "ID", "ADI");
        }

        private void setIsinmaTipList()
        {
            DataTable dtIsinmaTip = dbEmlak.DataTableGetir("SELECT*FROM ISINMA_TIP");
            List<ISINMA_TIP> IsinmaTipleri = new List<ISINMA_TIP>();
            IsinmaTipleri = (from DataRow row in dtIsinmaTip.Rows
                        select new ISINMA_TIP
                        {
                            ID = Convert.ToInt32(row["ID"].ToString()),
                            TIPI = row["TIPI"].ToString()

                        }).ToList();

            ViewBag.IsinmaTipleri = new SelectList(IsinmaTipleri, "ID", "TIPI");
        }

        private MenuModel getMenu(KULLANICI _Kullanici)
        {
            MenuModel menu = new MenuModel();
            menu.MenuList = new List<MenuModel>();

            if (_Kullanici.YETKI_ID == 1)
            {
                ViewData["Kullanici"] = _Kullanici.KULLANICI_ADI;
                menu.MenuList.Add(new MenuModel("Ana Sayfa", "home", "../Home/Index", "passive"));
                menu.MenuList.Add(new MenuModel("İlan Ver", "place", "../IlanVer/Index", "active"));
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
                menu.MenuList.Add(new MenuModel("Ana Sayfa", "home", "../Home/Index", "active"));
            }

            return menu;
        }

    }
}