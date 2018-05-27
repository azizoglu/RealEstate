using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Emlak.Database
{
    public class DbBaglanti
    {
        public SqlConnection baglan()//veritabanina baglanti kurar
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-E0RQODF; Initial Catalog=EMLAK; Integrated Security=true");
            baglanti.Open();
            SqlConnection.ClearPool(baglanti);
            SqlConnection.ClearAllPools();

            return baglanti;
        }


        public int idu(string sqlcumle)//insert update ve delete islemlerini yapar
        {

            SqlConnection baglan = this.baglan();
            SqlCommand sorgu = new SqlCommand(sqlcumle, baglan);
            int sonuc = 0;
            try
            {
                sonuc = sorgu.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            sorgu.Dispose();
            baglan.Close();
            baglan.Dispose();
            return (sonuc);
        }


        public DataTable DataTableGetir(string sql)// veri çeker
        {
            SqlConnection baglan = this.baglan();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, baglan);
            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            adapter.Dispose();
            baglan.Close();
            baglan.Dispose();
            return dt;

        }

        public DataRow DataRowGetir(string sql)// ilk satir verisini çeker
        {
            DataTable tablo = DataTableGetir(sql);
            if (tablo.Rows.Count == 0)
                return null;
            return tablo.Rows[0];
        }
    }
}