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

namespace AlisverisOtomasyonu
{
    public partial class Giris : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-QC0UANKG\\MSSQLSERVERR; initial catalog=otomasyon; Integrated Security=TRUE");
        public Giris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text;
            string sifre = txtSifre.Text;
            conn.Open();
            
                SqlCommand cmd = new SqlCommand("Select * from Yetkili", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                 while (dr.Read())
                 {
                    if (ad == dr["Y_Ad"].ToString() && sifre == dr["Y_Sifre"].ToString())
                    {
                        AnaSayfa anaSayfa = new AnaSayfa();
                        anaSayfa.Show();
                        this.Hide();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış");
                        break;
                    }
                 }
                    
            conn.Close();
        }

        private void llblKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formlar.IsBasvurusu frm = new formlar.IsBasvurusu();
            frm.Show();
            this.Hide();
        }
    }
}
