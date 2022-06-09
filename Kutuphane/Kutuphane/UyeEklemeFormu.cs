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

namespace Kutuphane
{
    public partial class UyeEklemeFormu : Form
    {
        public UyeEklemeFormu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uye_adi = adTxtbx.Text;
            string uye_soyadi = soyadiTxtbx.Text;
            string tel = TelTxtbx.Text;
            string adres = adresrichTxtbx.Text;
            string eposta = epostTxtbx.Text;
            string dogumTarihi = dogumTarihidateTimePicker.Value.ToShortDateString();
            string uyelikTarihi = uyelikTarihiDateTimePicker.Value.ToShortDateString();
            string kullaniciAdi = kullaniciAdiTxtbx.Text;
            string sifre = sifreTxtbx.Text;
            string yonetici = "0";
            if (yoneticiChkbx.Checked == true)
            {
                yonetici = "1";
            }
            string uye_no = "-1";
            SqlConnection baglantı = new SqlConnection("server=DESKTOP-9G7COM2;Database=Kutuphane;Integrated Securty=True; ");
            SqlCommand uyeEklemeKomutu = new SqlCommand("INSERT INTO Uyeler(Adi,Soyadi,Telefon,Adres,Eposta,UyelikTarihi,DoğumTarihi)VALUES(\'" + uye_adi + "\',\'" + uye_soyadi + "\',\'" + tel + "\',\'" + adres + "\',\'" +
                eposta + "\',\'" + uyelikTarihi + "\',\'" + dogumTarihi + "\');", baglantı);
            SqlCommand uyeNoGetir = new SqlCommand("Select Uye_No FROM Uyeler WHERE Adi=\'" + uye_adi + "\' AND Soyadi = \'" + uye_soyadi + "\' AND Telefon=\'" + tel + "\';", baglantı);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(uyeNoGetir);
            baglantı.Open();
            uyeEklemeKomutu.ExecuteNonQuery();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            uye_no = dr[0].ToString();

            SqlCommand kullaniciEkleKomutu = new SqlCommand("INSERT INTO Kullanicilar(kullaniciAdi,sifre,uye_no,yonetici) VALUES (\'" + kullaniciAdi + "\'"+sifre+"\',\'"+uye_no+"\',\'"+yonetici+"\');",baglantı);
            kullaniciEkleKomutu.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("kullanıcı eklendı");

        }
    }
}
