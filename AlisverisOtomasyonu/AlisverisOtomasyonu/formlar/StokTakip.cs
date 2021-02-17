using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlisverisOtomasyonu.Entity;
using System.Data.SqlClient;

namespace AlisverisOtomasyonu.formlar
{
    public partial class StokTakip : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-QC0UANKG\\MSSQLSERVERR; initial catalog=otomasyon; Integrated Security=TRUE");
        public StokTakip()
        {
            InitializeComponent();
        }

        otomasyonEntities db = new otomasyonEntities();
        private void StokTakip_Load(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand komut = new SqlCommand("select U_Ad,U_Stok from Urun",conn);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Ürünler"].Points.AddXY(dr[0].ToString(), dr[1]);
            }
            conn.Close();
        }
    }
}
