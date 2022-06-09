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
    public partial class KitapVerUyeSecFormu : Form
    {
        public string Kitap_id;
        public string KitapAdi;
        public string KitapYazari;
        public string KitapYayinEvi;
        public string KitapBasimYili;
        public int KitapSayisi;
        public KitapVerUyeSecFormu()
        {
            InitializeComponent();
           
        }
        void ComboboxDoldur()
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-QNPE5CA\\SQLEXPRESS;Database=Kutuphane;Integrated Security=true;");
            SqlCommand uyeleriGetir = new SqlCommand("SELECT Uye_No,Adi AS[Üye Adı],Soyadi[SoyAdı],Eposta AS[Üye E-Posta Adresi],Telefon AS[Üye Telefonu],DogumTarihi AS[ÜyeDogumGünü],UyelikTarihi AS[ÜyelikTarihi],Adres AS[Üye Adresi] FROM Uyeler;", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(uyeleriGetir);
            baglanti.Open();
            da.Fill(dt);
            baglanti.Close();
            comboBox1.DataSource = new BindingSource(dt, null);
            comboBox1.DisplayMember = "Üye E-Posta Adresi";
            comboBox1.ValueMember = "Uye_No";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex != -1)
            {
                try
                {
                    SqlConnection baglanti = new SqlConnection("server=DESKTOP-QNPE5CA\\SQLEXPRESS;Database=Kutuphane;Integrated Security=true;");
                    SqlCommand uyeleriGetir = new SqlCommand("SELECT Uye_No,Adi AS[Üye Adı],Soyadi[SoyAdı],Eposta AS[Üye E-Posta Adresi]FROM Uyeler WHERE Uye_No=\'" + comboBox1.SelectedValue.ToString() + "\';", baglanti);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(uyeleriGetir);
                    baglanti.Open();
                    da.Fill(dt);
                    baglanti.Close();
                    DataRow dr = dt.Rows[0];
                    string uye_No = dr[0].ToString();
                    string adi = dr[1].ToString();
                    string soyadi = dr[2].ToString();


                    textBox1.Text = adi;
                    textBox2.Text = soyadi;

                }
                catch
                {

                }
            }
        }

        private void KitapVerUyeSecFormu_Load(object sender, EventArgs e)
        {
            ComboboxDoldur();
            comboBox1.SelectedIndex = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
                DialogResult dr = MessageBox.Show("Kitabı vermeye eminmisin");
                SqlConnection baglantı = new SqlConnection("server=DESKTOP-QNPE5CA\\SQLEXPRESS;Database=Kutuphane;Integrated Security=true;");
                SqlCommand uyeEklemeKomutu = new SqlCommand("INSERT INTO AlinanKitaplar(Uye_No,Kitap_id,AlisTarihi)VALUES(\'" + comboBox1.SelectedValue + "\',\'" + Kitap_id + "\',\'" + DateTime.Now.ToShortDateString() +  "\');", baglantı);
                SqlCommand eksil = new SqlCommand("UPDATE Kitaplar SET KitapSayisi=\'" + --KitapSayisi + "\' WHERE Kitap_id=\'" + Kitap_id + "\'", baglantı);
            
                baglantı.Open();
                uyeEklemeKomutu.ExecuteNonQuery();
                eksil.ExecuteNonQuery();
                baglantı.Close();

        }
    }
}
