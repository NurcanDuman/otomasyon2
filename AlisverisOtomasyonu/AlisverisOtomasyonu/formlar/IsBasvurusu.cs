using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AlisverisOtomasyonu.formlar
{
    public partial class IsBasvurusu : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-QC0UANKG\\MSSQLSERVERR; initial catalog=otomasyon; Integrated Security=TRUE");

        public IsBasvurusu()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Today;
            
            conn.Open();

            SqlCommand cmd = new SqlCommand("insert into IsBasvurulari (ad, soyad, tel, okul, brans, tc, basvuru)" +
                "values(@ad,@soyad,@tel,@okul,@brans,@tc,@basvuru)", conn);
            cmd.Parameters.AddWithValue("@ad", txtAd.Text);
            cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@tel", txtTel.Text);
            cmd.Parameters.AddWithValue("@okul", txtOkul.Text);
            cmd.Parameters.AddWithValue("@brans", txtBrans.Text);
            cmd.Parameters.AddWithValue("@tc", txtTC.Text);
            cmd.Parameters.AddWithValue("@basvuru", bugun);

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("İş Başvurunuz Gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
        }
    }
}
