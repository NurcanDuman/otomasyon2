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
    public partial class Personel : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-QC0UANKG\\MSSQLSERVERR; initial catalog=otomasyon; Integrated Security=TRUE");

        public Personel()
        {
            InitializeComponent();
        }

        private void btnMusteriE_Click(object sender, EventArgs e)
        {
            Ekle();
            Listele();
        }

        private void Ekle()
        {
            DateTime bugun = DateTime.Today;
            conn.Open();
            string dTarih = dateEdit1.EditValue.ToString();
            SqlCommand cmd = new SqlCommand("insert into Yetkili (Y_Ad, Y_Soyad, Y_Sifre, Y_TC, Y_DTarih, Y_Tel, Y_Tarih)" +
                "values(@ad,@soyad,@sifre,@tc,@dt,@tel,@tarih)", conn);
            cmd.Parameters.AddWithValue("@ad", txtAd.Text);
            cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
            cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@tc", txtTC.Text);
            cmd.Parameters.AddWithValue("@dt", dTarih);
            cmd.Parameters.AddWithValue("@tel", mtxtTel.Text);
            cmd.Parameters.AddWithValue("@tarih", bugun);
            
            cmd.ExecuteNonQuery();
            MessageBox.Show("Personel Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string id = gridView2.GetFocusedRowCellValue("id").ToString();
            SqlCommand cmdd = new SqlCommand("delete from IsBasvurulari where id='" + id + "'", conn);
            cmdd.ExecuteNonQuery();

            conn.Close();

        }

        private void Listele()
        {
            string komut = "select * from Yetkili";
            SqlDataAdapter da = new SqlDataAdapter(komut, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
            txtAd.Text = " ";
            txtSoyad.Text = " ";
            mtxtTel.Text = " ";
            txtTC.Text = " ";
            dateEdit1.Text = " ";
            txtSifre.Text = " ";
        }

        private void Personel_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnMusterS_Click(object sender, EventArgs e)
        {
            Sil();
            Listele();
        }

        private void Sil()
        {
            DialogResult onay = MessageBox.Show("Personeli işten çıkartmak istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {

            }
            conn.Open();
            string id = gridView1.GetFocusedRowCellValue("id").ToString();
            SqlCommand cmd = new SqlCommand("delete from Yetkili where id='" + id + "'", conn);
            cmd.ExecuteNonQuery();

            DateTime bugun = DateTime.Today;
            SqlCommand cmdd = new SqlCommand("insert into EskiPersonel (ad, soyad, tel, tarih)" +
                "values(@ad,@soyad,@tel,@tarih)", conn);
            cmdd.Parameters.AddWithValue("@ad", gridView1.GetFocusedRowCellValue("Y_Ad").ToString());
            cmdd.Parameters.AddWithValue("@soyad", gridView1.GetFocusedRowCellValue("Y_Soyad").ToString());
            cmdd.Parameters.AddWithValue("@tel", gridView1.GetFocusedRowCellValue("Y_Tel").ToString());
            cmdd.Parameters.AddWithValue("@tarih", bugun);

            cmdd.ExecuteNonQuery();
            conn.Close();


        }

        private void btnMusteriG_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void Guncelle()
        {
            conn.Open();
            string id = gridView1.GetFocusedRowCellValue("id").ToString();
            SqlCommand cmd = new SqlCommand("Update Yetkili set Y_Ad='" + txtAd.Text + "',Y_Sifre='" + txtSifre.Text + "',Y_Soyad='" + txtSoyad.Text + "',Y_Tel='" + mtxtTel.Text + "',Y_TC='" + txtTC.Text + "' where id='" + id + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();
        }
        
        private void btnMusterT_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnBasvuru_Click(object sender, EventArgs e)
        {
            string komut = "select * from IsBasvurulari";
            SqlDataAdapter da = new SqlDataAdapter(komut, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl2.DataSource = ds.Tables[0];
        }

        private void btnAl_Click(object sender, EventArgs e)
        {
            txtAd.Text = gridView2.GetFocusedRowCellValue("ad").ToString();
            txtSoyad.Text = gridView2.GetFocusedRowCellValue("soyad").ToString();
            mtxtTel.Text = gridView2.GetFocusedRowCellValue("tel").ToString();
            txtTC.Text = gridView2.GetFocusedRowCellValue("tc").ToString();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            txtAd.Text = dr["Y_Ad"].ToString();
            txtSifre.Text = dr["Y_Sifre"].ToString();
            txtSoyad.Text = dr["Y_Soyad"].ToString();
            mtxtTel.Text = dr["Y_Tel"].ToString();
            txtTC.Text = dr["Y_TC"].ToString();
            dateEdit1.Text = dr["Y_DTarih"].ToString();
        }
    }
}
