using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelTakipOtomasyonu
{
     class Veritabani
    {
        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-1QU3AO4;Initial Catalog=Personel_Takip;Integrated Security=True;");

        public static void ESG(SqlCommand cmd,string sql)
        {
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }
        public static DataTable Listele_Ara(DataGridView gridView, string sql)
        {
            DataTable dt = new DataTable();
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, baglanti);
            da.Fill(dt);
            gridView.DataSource = dt;
            baglanti.Close();

            return dt;

        }
    }
}
