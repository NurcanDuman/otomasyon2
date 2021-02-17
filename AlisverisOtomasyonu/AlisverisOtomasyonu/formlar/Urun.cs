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
using System.IO;

namespace AlisverisOtomasyonu.formlar
{
    public partial class Urun : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-QC0UANKG\\MSSQLSERVERR; initial catalog=otomasyon; Integrated Security=TRUE");
        public Urun()
        {
            InitializeComponent();
        }

        private void Urun_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnUrunTemizle_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            Ekle();
            Listele();
        }
        
        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            Sil();
            Listele();
        }
        
        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void Ekle()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Urun (U_Ad, U_Fiyat, U_UretimYeri, U_Stok, U_Kategori, U_Foto)" +
                "values(@ad,@fiyat,@uretim,@stok,@kategori,@foto)", conn);
            cmd.Parameters.AddWithValue("@ad", txtUrunAd.Text);
            cmd.Parameters.AddWithValue("@fiyat", txtUrunFiyat.Text);
            cmd.Parameters.AddWithValue("@uretim", txtUrunUretimYeri.Text);
            cmd.Parameters.AddWithValue("@stok", txtUrunStok.Text);
            cmd.Parameters.AddWithValue("@kategori", comboBoxEdit1.Text);
            cmd.Parameters.AddWithValue("@foto", Path.GetFileName(yeniyol));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Ürün Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Sil()
        {
            DialogResult onay = MessageBox.Show("Silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {

            }

            conn.Open();
            string id = gridView1.GetFocusedRowCellValue("id").ToString();
            SqlCommand cmd = new SqlCommand("delete from Urun where id='" + id + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        private void Guncelle()
        {
            conn.Open();
            string id = gridView1.GetFocusedRowCellValue("id").ToString();
            SqlCommand cmd = new SqlCommand("update Urun set U_Ad='" + txtUrunAd.Text + "',U_Fiyat='" + txtUrunFiyat.Text + "',U_UretimYeri='" + txtUrunUretimYeri.Text + "',U_Stok='" + txtUrunStok.Text + "',U_Kategori='" + comboBoxEdit1.Text + "',U_Foto='" + Path.GetFileName(yeniyol) + "' where id='" + id + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();
        }

        
        private void Listele()
        {
            string komut = "select * from Urun";
            SqlDataAdapter da = new SqlDataAdapter(komut, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
            txtUrunAd.Text = " ";
            comboBoxEdit1.Text = " ";
            txtUrunFiyat.Text = " ";
            txtUrunStok.Text = " ";
            txtUrunUretimYeri.Text = " ";
        }

        public string yeniyol;
        private void btnResimE_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*jpg;*png;*nef | Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyaYolu = dosya.FileName;
            yeniyol = "C:\\Users\\Nurcan Duman\\source\\repos\\AlisverisOtomasyonu\\AlisverisOtomasyonu" + "\\resimler\\" + Guid.NewGuid().ToString() + ".jpg";
            File.Copy(dosyaYolu, yeniyol);
            pictureBox1.ImageLocation = yeniyol;
            
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            txtUrunAd.Text = dr["U_Ad"].ToString();
            txtUrunFiyat.Text = dr["U_Fiyat"].ToString();
            txtUrunUretimYeri.Text = dr["U_UretimYeri"].ToString();
            txtUrunStok.Text = dr["U_Stok"].ToString();
            comboBoxEdit1.Text = dr["U_Kategori"].ToString();
            yeniyol = "C:\\Users\\Nurcan Duman\\source\\repos\\AlisverisOtomasyonu\\AlisverisOtomasyonu" + "\\resimler\\" + dr["U_Foto"].ToString();
            pictureBox1.ImageLocation = yeniyol;

        }
    }
}
