using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelTakipOtomasyonu
{
    class Departmanlar
    {
        private int _departmanID;
        private string _departman;
        private string _aciklama;

        public int DepartmanID { get => _departmanID; set => _departmanID = value; }
        public string Departman { get => _departman; set => _departman = value; }
        public string Aciklama { get => _aciklama; set => _aciklama = value; }


        public static SqlDataReader DepartmanGetir(ListView lst)
        {
            lst.Items.Clear();
            Veritabani.baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select * from Departmanlar", Veritabani.baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr["departmanId"].ToString();
                ekle.SubItems.Add(dr["departman"].ToString());
                ekle.SubItems.Add(dr[2].ToString());
                lst.Items.Add(ekle);

            }
            Veritabani.baglanti.Close();

            return dr;
        }
    }
}
