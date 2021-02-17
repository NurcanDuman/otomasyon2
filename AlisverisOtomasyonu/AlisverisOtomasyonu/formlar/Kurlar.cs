using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AlisverisOtomasyonu.formlar
{
    public partial class Kurlar : Form
    {
        public Kurlar()
        {
            InitializeComponent();
        }

        private void Kurlar_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(bugun);
            DateTime tarih = DateTime.Now;

            string usdSatis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            string usdAlis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;

            string euroSatis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            string euroAlis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;

            string chfSatis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='CHF']/BanknoteSelling").InnerXml;
            string chfAlis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='CHF']/BanknoteBuying").InnerXml;

            string jpySatis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='JPY']/BanknoteSelling").InnerXml;
            string jpyAlis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='JPY']/BanknoteBuying").InnerXml;

            string gbpSatis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            string gbpAlis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteBuying").InnerXml;

            string cnySatis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='CNY']/ForexSelling").InnerXml;
            string cnyAlis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='CNY']/ForexBuying").InnerXml;

            

            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Tarih";
            dataGridView1.Columns[1].Name = "Döviz Kodu";
            dataGridView1.Columns[2].Name = "Birim";
            dataGridView1.Columns[3].Name = "Döviz Cinsi";
            dataGridView1.Columns[4].Name = "Döviz Alış";
            dataGridView1.Columns[5].Name = "Döviz Satış";

            int i = dataGridView1.Rows.Add(6);
            i = 0;

            dataGridView1.Rows[i].Cells[0].Value = tarih;
            dataGridView1.Rows[i].Cells[1].Value = "USD";
            dataGridView1.Rows[i].Cells[2].Value = "1";
            dataGridView1.Rows[i].Cells[3].Value = "USD";
            dataGridView1.Rows[i].Cells[4].Value = usdSatis;
            dataGridView1.Rows[i].Cells[5].Value = usdAlis;

            i = 1;

            dataGridView1.Rows[i].Cells[0].Value = " ";
            dataGridView1.Rows[i].Cells[1].Value = "EURO";
            dataGridView1.Rows[i].Cells[2].Value = "1";
            dataGridView1.Rows[i].Cells[3].Value = "EURO";
            dataGridView1.Rows[i].Cells[4].Value = euroSatis;
            dataGridView1.Rows[i].Cells[5].Value = euroAlis;

            i = 2;

            dataGridView1.Rows[i].Cells[0].Value = " ";
            dataGridView1.Rows[i].Cells[1].Value = "CHF";
            dataGridView1.Rows[i].Cells[2].Value = "1";
            dataGridView1.Rows[i].Cells[3].Value = "İSVİÇRE FRANGI";
            dataGridView1.Rows[i].Cells[4].Value = chfSatis;
            dataGridView1.Rows[i].Cells[5].Value = chfAlis;

            i = 3;

            dataGridView1.Rows[i].Cells[0].Value = " ";
            dataGridView1.Rows[i].Cells[1].Value = "JPY";
            dataGridView1.Rows[i].Cells[2].Value = "100";
            dataGridView1.Rows[i].Cells[3].Value = "JAPON YENİ";
            dataGridView1.Rows[i].Cells[4].Value = jpySatis;
            dataGridView1.Rows[i].Cells[5].Value = jpyAlis;

            i = 4;

            dataGridView1.Rows[i].Cells[0].Value = " ";
            dataGridView1.Rows[i].Cells[1].Value = "GBP";
            dataGridView1.Rows[i].Cells[2].Value = "1";
            dataGridView1.Rows[i].Cells[3].Value = "İNGİLİZ STERLİNİ";
            dataGridView1.Rows[i].Cells[4].Value = gbpSatis;
            dataGridView1.Rows[i].Cells[5].Value = gbpAlis;

            i = 5;

            dataGridView1.Rows[i].Cells[0].Value = " ";
            dataGridView1.Rows[i].Cells[1].Value = "CNY";
            dataGridView1.Rows[i].Cells[2].Value = "1";
            dataGridView1.Rows[i].Cells[3].Value = "ÇİN YUANI";
            dataGridView1.Rows[i].Cells[4].Value = cnySatis;
            dataGridView1.Rows[i].Cells[5].Value = cnyAlis;


        }
    }
}
