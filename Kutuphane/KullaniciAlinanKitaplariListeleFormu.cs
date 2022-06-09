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
    public partial class KullaniciAlinanKitaplariListeleFormu : Form
    {
        public KullaniciAlinanKitaplariListeleFormu()
        {
            InitializeComponent();
        }
        public int uye_No = 0;
        private void KullaniciAlinanKitaplariListeleFormu_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=DESKTOP-QNPE5CA\\SQLEXPRESS;Database=Kutuphane;Integrated Security=true;");
            SqlCommand AlinanKitaplariGetir = new SqlCommand("SELECTUyeler.Uye_No,Kitaplar.Kitap_id, Kitaplar.KitapSayisi, Uyeler.Adi AS [Üye Adı], Uyeler.Soyadi AS[Üye Soyadı], Uyeler.Eposta AS[Üye E - Posta Adresi], Kitaplar.KitapAdi AS[KitapAdi], Kitaplar.KitapYazari AS[KitapYazari], Kitaplar.KitapYayinEvi AS[BasimEvi], Kitaplar.KitapBasimYili AS[BasımYılı], AlinanKitaplar.AlisTarihi AS[Ödünç Alma Tarihi] FROM Uyeler, Kitaplar, AlinanKitaplar WHERE AlinanKitaplar.Kitap_id = Kitaplar.Kitap_id AND AlinanKitaplar.Uye_No = Uyeler.Uye_No AND AlinanKitaplar. Kitaplar, AlinanKitaplar AND AlinanKitaplar.TeslimTarihi IS NOT Null ANDAlinanKitaplar.Uye_No =\'"+uye_No.ToString()+"\';", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(AlinanKitaplariGetir);
            baglanti.Open();
            da.Fill(dt);
            baglanti.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
        }
    }
}
