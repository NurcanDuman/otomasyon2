using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace AlisverisOtomasyonu
{
    public partial class AnaSayfa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.Urun frm = new formlar.Urun();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnUrunS_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.Urun frm = new formlar.Urun();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnUrunG_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.Urun frm = new formlar.Urun();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnUrunL_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.Urun frm = new formlar.Urun();
            frm.MdiParent = this;
            frm.Show();
        }
        
        private void btnMusteriG_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.Musteri frm = new formlar.Musteri();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnMusteriS_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.Musteri frm = new formlar.Musteri();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnMusteriE_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.Musteri frm = new formlar.Musteri();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnMusteriL_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.Musteri frm = new formlar.Musteri();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnStok_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.StokTakip frm = new formlar.StokTakip();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnSiparis_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.Per_Mus_ist frm = new formlar.Per_Mus_ist();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnKur_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.Kurlar frm = new formlar.Kurlar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnPersonelL_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.Personel frm = new formlar.Personel();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnPersonelE_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.Personel frm = new formlar.Personel();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnPersonelS_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.Personel frm = new formlar.Personel();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnPersonelG_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.Personel frm = new formlar.Personel();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnHesapM_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.HesapMakinesi frm = new formlar.HesapMakinesi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnAnayfa_ItemClick(object sender, ItemClickEventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void btnCikis_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }
        
    }
}