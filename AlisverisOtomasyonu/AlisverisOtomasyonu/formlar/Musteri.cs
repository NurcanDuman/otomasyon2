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
    public partial class Musteri : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-QC0UANKG\\MSSQLSERVERR; initial catalog=otomasyon; Integrated Security=TRUE");
        public Musteri()
        {
            InitializeComponent();
        }

        private void Musteri_Load(object sender, EventArgs e)
        {
            Listele();
            ilEkle();
        }
        private void btnMusteriE_Click(object sender, EventArgs e)
        {
            Ekle();
            Listele();
        }

        private void btnMusteriT_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnMusteriS_Click(object sender, EventArgs e)
        {
            Sil();
            Listele();
        }

        private void btnMusteriG_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void Ekle()
        {
            DateTime bugun = DateTime.Today;
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Musteri (M_Ad, M_Soyad, M_il, M_ilce, M_Tel, M_Mail, M_Adres, M_Tarih)" +
                "values(@ad,@soyad,@il,@ilce,@tel,@mail,@adres,@tarih)", conn);
            cmd.Parameters.AddWithValue("@ad", txtAd.Text);
            cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@il", cmbil.Text);
            cmd.Parameters.AddWithValue("@ilce", cmbilce.Text);
            cmd.Parameters.AddWithValue("@tel", mtxtTel.Text);
            cmd.Parameters.AddWithValue("@mail", mtxtMail.Text);
            cmd.Parameters.AddWithValue("@adres", txtAdres.Text);
            cmd.Parameters.AddWithValue("@tarih", bugun);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Müşteri Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void Guncelle()
        {
            conn.Open();
            string id = gridView1.GetFocusedRowCellValue("id").ToString();
            SqlCommand cmd = new SqlCommand("Update Musteri set M_Ad='" + txtAd.Text + "',M_Soyad='" + txtSoyad.Text + "',M_il='" + cmbil.Text + "',M_ilce='" + cmbilce.Text + "',M_Tel='" + mtxtTel.Text + "',M_Mail='" + mtxtMail.Text + "',M_Adres='" + txtAdres.Text + "' where id='" + id + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();
        }
        
        private void Sil()
        {
            DialogResult onay = MessageBox.Show("Müşteriyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {

            }

            conn.Open();
            string id = gridView1.GetFocusedRowCellValue("id").ToString();
            SqlCommand cmd = new SqlCommand("delete from Musteri where id='" + id + "'", conn);
            cmd.ExecuteNonQuery();
            
            DateTime bugun = DateTime.Today;
            SqlCommand cmdd = new SqlCommand("insert into eskiMusteri (ad, soyad, tarih)" +
                "values(@ad,@soyad,@tarih)", conn);
            cmdd.Parameters.AddWithValue("@ad", gridView1.GetFocusedRowCellValue("M_Ad").ToString());
            cmdd.Parameters.AddWithValue("@soyad", gridView1.GetFocusedRowCellValue("M_Soyad").ToString());
            cmdd.Parameters.AddWithValue("@tarih", bugun);

            cmdd.ExecuteNonQuery();
            conn.Close();
            
        }
        private void Listele()
        {
            string komut = "select * from Musteri";
            SqlDataAdapter da = new SqlDataAdapter(komut, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
            txtAd.Text = " ";
            txtSoyad.Text = " ";
            mtxtTel.Text = " ";
            mtxtMail.Text = " ";
            txtAdres.Text = " ";
            cmbil.Text = " ";
            cmbilce.Text = " ";
        }

        void ilEkle()
        {
            
            conn.Open();
            SqlCommand komut = new SqlCommand("select * from iller", conn);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[1]);
            }
            conn.Close();

            
        }
        
        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();
            conn.Open();
            SqlCommand komut = new SqlCommand("Select * from ilceler where sehir=@p1", conn);
            komut.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbilce.Properties.Items.Add(dr[1]);
            }
            conn.Close();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            txtAd.Text = dr["M_Ad"].ToString();
            txtSoyad.Text = dr["M_Soyad"].ToString();
            cmbil.Text = dr["M_il"].ToString();
            cmbilce.Text = dr["M_ilce"].ToString();
            mtxtTel.Text = dr["M_Tel"].ToString();
            mtxtMail.Text = dr["M_Mail"].ToString();
            txtAdres.Text = dr["M_Adres"].ToString();
        }
    }
}
