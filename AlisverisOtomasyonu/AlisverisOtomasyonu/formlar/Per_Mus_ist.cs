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

namespace AlisverisOtomasyonu.formlar
{
    public partial class Per_Mus_ist : Form
    {
        public Per_Mus_ist()
        {
            InitializeComponent();
        }
        otomasyonEntities db = new otomasyonEntities();
        private void Per_Mus_ist_Load(object sender, EventArgs e)
        {
            lblGuncelM.Text = db.Musteri.Count().ToString();
            lblGuncelP.Text = db.Yetkili.Count().ToString();
            DateTime bugun = DateTime.Today;
            lblBugunM.Text = db.Musteri.Count(x => x.M_Tarih == bugun).ToString();
            lblBugunP.Text = db.Yetkili.Count(x => x.Y_Tarih == bugun).ToString();
            lblUM.Text = db.eskiMusteri.Count(x => x.tarih == bugun).ToString();
            lblAP.Text = db.EskiPersonel.Count(x => x.tarih == bugun).ToString();
        }
    }
}
