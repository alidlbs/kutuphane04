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
    public partial class UyeGuncellemeFormu : Form
    {
        public UyeGuncellemeFormu()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                try
                {
                    SqlConnection baglanti = new SqlConnection("server=DESKTOP-9G7COM2;Database=Kutuphane;Integrated Securty=True;");
                    SqlCommand uyeleriGetir = new SqlCommand("SELECT Uye_No,Adi AS [Üye Adı],Soyadi AS [Üye Soyadi],Eposta AS [Üye E-posta Adresi],Telefon AS  [Üye Telefonu],DogumTarihi AS [Üye Doğum Günü],UyelikTarihi AS [Üyelik Tarihi],Adres AS [Üye Adresi] FROM Uyeler  WHERE Uye_No=\'" + comboBox1.SelectedValue.ToString() + "\';", baglanti);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(uyeleriGetir);
                    baglanti.Open();
                    da.Fill(dt);
                    baglanti.Close();
                    DataRow dr = dt.Rows[0];
                    string uye_no = dr[0].ToString();
                    string adi = dr[1].ToString();
                    string soyadi = dr[2].ToString();
                    string eposta = dr[3].ToString();
                    string tel = dr[4].ToString();
                    string dogumtarihi = dr[5].ToString();
                    string uyeliktarihi = dr[6].ToString();
                    string adres = dr[7].ToString();

                    adTxtBx.Text = adi;
                    soyadiTxtBx.Text = soyadi;
                    epostaTxtBx.Text = eposta;
                    telTxtBx.Text = tel;
                    dogumtarihiDateTimePicker.Value = DateTime.Parse(dogumtarihi);
                    uyelikTarihiDateTimePicker.Value = DateTime.Parse(uyeliktarihi);
                    adresrichTxtBx.Text = adres;

                }
                catch 
                {

                    throw;
                }


            }


           

        }


        void ComboboxDoldur()

        {

            SqlConnection baglanti = new SqlConnection("Server=DESKTOP-9G7COM2;Database=Kutuphane;Integrated Securty=True;");
            SqlCommand uyeleriGetir = new SqlCommand("SELECT Uye_No , Adi AS [Üye Adı], Soyadi AS [Üye Soyadı], Eposta AS [Üye E-Posta  Adresi],Telefon AS [Üye Telefon],DoğumTarihi AS [Üye Doğum Günü],UyelikTarihi AS [Üyelik Tarihi],Adres AS [Üye Adresi]FROM Uyeler; ", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(uyeleriGetir);
            baglanti.Open();
            da.Fill(dt);
            baglanti.Close();
            comboBox1.DataSource = new BindingSource(dt, null);
            comboBox1.DisplayMember = "Üye E-Posta Adresi";
            comboBox1.ValueMember = "Uye_No";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string uye_adi = adTxtBx.Text;
            string uye_soyadi = soyadiTxtBx.Text;
            string tel = telTxtBx.Text;
            string adres = adresrichTxtBx.Text;
            string eposta = epostaTxtBx.Text;
            string dogumTarihi =dogumtarihiDateTimePicker.Value.ToShortDateString();
            string uyelikTarihi = uyelikTarihiDateTimePicker.Value.ToShortDateString();
            SqlConnection baglantı = new SqlConnection("Server=DESKTOP-9G7COM2;Database=Kutuphane;Integrated Securty=True;");
            SqlCommand uyeleriGuncellemeKomutu = new SqlCommand("UPDATE Uyeler SET Adi=\'" + uye_adi + "\',Soyadi=\'" + uye_soyadi + "\',Telefon=\'" + tel + "\',Adres=\'" + adres + "\',Eposta=\'" + eposta + "\',UyelikTarihi=\'" + uyelikTarihi + "\',DoğumTarihi=\'" + dogumTarihi + "\' WHERE Uye_No=\'" + comboBox1.SelectedValue.ToString() + "\';",baglantı);
            baglantı.Open();
            uyeleriGuncellemeKomutu.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("güncellendi");
            ComboboxDoldur();


        }

        private void UyeGuncellemeFormu_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            ComboboxDoldur();
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    }

    
