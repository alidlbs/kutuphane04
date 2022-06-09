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
namespace kutuphane
{
    public partial class KullaniciFormu : Form
    {
        public KullaniciFormu()
        {
            InitializeComponent();
        }
        public string kullaniciAdi = "";
        public int uye_No = 0;
        private void KullaniciFormu_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=DESKTOP-QNPE5CA\\SQLEXPRESS;Database=Kutuphane;Integrated Security=true;");
            SqlCommand AlinanKitaplariGetir = new SqlCommand("SELECTUyeler.Uye_No,Kitaplar.Kitap_id, Kitaplar.KitapSayisi, Uyeler.Adi AS [Üye Adı], Uyeler.Soyadi AS[Üye Soyadı], Uyeler.Eposta AS[Üye E - Posta Adresi], Kitaplar.KitapAdi AS[KitapAdi], Kitaplar.KitapYazari AS[KitapYazari], Kitaplar.KitapYayinEvi AS[BasimEvi], Kitaplar.KitapBasimYili AS[BasımYılı], AlinanKitaplar.AlisTarihi AS[Ödünç Alma Tarihi] FROM Uyeler, Kitaplar, AlinanKitaplar WHERE AlinanKitaplar.Kitap_id = Kitaplar.Kitap_id AND AlinanKitaplar.Uye_No = Uyeler.Uye_No AND AlinanKitaplar. Kitaplar, AlinanKitaplar AND AlinanKitaplar.TeslimTarihi IS NOT Null ANDAlinanKitaplar.Uye_No =\'" + uye_No.ToString() + "\';", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(AlinanKitaplariGetir);
            baglanti.Open();
            da.Fill(dt);
            baglanti.Close();

        }
        private void teslimEttigimKitaplarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Form item in this.MdiChildren)
                {
                item.Close();
                 }  
            KullaniciAlinanKitaplariListeleFormu frm = new KullaniciAlinanKitaplariListeleFormu();
                frm.uye_No = uye_No;
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            
        }

        private void henüzTeslimEtmediğimKitaplarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form item in this.MdiChildren)
            {
                item.Close();
            }
            KullaniciVerilenKitaplariListeleFormu frm = new KullaniciVerilenKitaplariListeleFormu();
            frm.uye_No = uye_No;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.ShowDialog();
        }
    }
}
