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
    public partial class KitapAlFormu : Form
    {
        public KitapAlFormu()
        {
            InitializeComponent();
        }
        public string Kitap_id;
        public int KitapSayisi;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Kitabı vermeye eminmisin");
            SqlConnection baglantı = new SqlConnection("server=DESKTOP-QNPE5CA\\SQLEXPRESS;Database=Kutuphane;Integrated Security=true;");
            SqlCommand uyeEklemeKomutu = new SqlCommand("INSERT INTO AlinanKitaplar(Uye_No,Kitap_id,AlisTarihi)VALUES(\'"+ Kitap_id + "\',\'" + DateTime.Now.ToShortDateString() + "\');", baglantı);
            SqlCommand eksil = new SqlCommand("UPDATE Kitaplar SET KitapSayisi=\'" + ++KitapSayisi + "\' WHERE Kitap_id=\'" + Kitap_id + "\'", baglantı);

            baglantı.Open();
            uyeEklemeKomutu.ExecuteNonQuery();
            eksil.ExecuteNonQuery();
            baglantı.Close();
        }

        private void KitapAlFormu_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=DESKTOP-QNPE5CA\\SQLEXPRESS;Database=Kutuphane;Integrated Security=true;");
            SqlCommand al = new SqlCommand("SELECT Uyeler.Uye_No,Kitaplar.Kitap_id, Kitaplar.KitapSayisi, Uyeler.Adi AS [Üye Adı], Uyeler.Soyadi AS[Üye Soyadı], Uyeler.Eposta AS[Üye E - Posta Adresi], Kitaplar.KitapAdi AS[KitapAdi], Kitaplar.KitapYazari AS[KitapYazari], Kitaplar.KitapYayinEvi AS[BasimEvi], Kitaplar.KitapBasimYili AS[BasımYılı], AlinanKitaplar.AlisTarihi AS[Ödünç Alma Tarihi] FROM Uyeler, Kitaplar, AlinanKitaplar WHERE AlinanKitaplar.Kitap_id = Kitaplar.Kitap_id AND AlinanKitaplar.Uye_No = Uyeler.Uye_No AND AlinanKitaplar.TeslimTarihi is Null;", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(al);
            baglanti.Open();
            da.Fill(dt);
            baglanti.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
        }
    }
}
