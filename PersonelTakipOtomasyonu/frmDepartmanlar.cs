using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelTakipOtomasyonu
{
    public partial class frmDepartmanlar : Form
    {
        public frmDepartmanlar()
        {
            InitializeComponent();
        }
        private void txtTemizle()
        {
            txtDepartmanId.Clear();
            txtDepartman.Clear();
            txtAciklama.Clear();
        }
        private void frmDepartmanlar_Load(object sender, EventArgs e)
        {
            Departmanlar.DepartmanGetir(listView1);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            Departmanlar d = new Departmanlar();
            d.Departman = txtDepartman.Text;
            d.Aciklama = txtAciklama.Text;

            string sql = "insert into Departmanlar values('"+d.Departman+"','"+d.Aciklama+"')";
            SqlCommand cmd = new SqlCommand();
            Veritabani.ESG(cmd, sql);
            MessageBox.Show("Departman Eklendi");
                       
            Departmanlar.DepartmanGetir(listView1);
           txtTemizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Departmanlar d = new Departmanlar();
            d.DepartmanID = Convert.ToInt32(txtDepartmanId.Text);
            d.Departman = txtDepartman.Text;
            d.Aciklama = txtAciklama.Text;
            string sql = "update Departmanlar set Departman='" + d.Departman + "',departmanAciklama='" + d.Aciklama + "' where departmanId=" + d.DepartmanID + "";
            SqlCommand cmd = new SqlCommand();
            Veritabani.ESG(cmd, sql);
            MessageBox.Show("Departman Güncellendi");
            Departmanlar.DepartmanGetir(listView1);
            txtTemizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Departmanlar d = new Departmanlar();
            d.DepartmanID = Convert.ToInt32(txtDepartmanId.Text);
            string sql = "delete from Departmanlar where departmanId=" + d.DepartmanID + "";
            SqlCommand cmd = new SqlCommand();
            Veritabani.ESG(cmd, sql);
            MessageBox.Show("Departman Silindi");
            Departmanlar.DepartmanGetir(listView1);
            txtTemizle();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDepartmanId.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txtDepartman.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtAciklama.Text = listView1.SelectedItems[0].SubItems[2].Text;

            listView1.SelectedIndexChanged -= listView1_SelectedIndexChanged;
            listView1.SelectedItems.Clear();
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
        }
    }
}
