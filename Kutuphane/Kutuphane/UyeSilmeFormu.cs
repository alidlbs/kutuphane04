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
    public partial class UyeSilmeFormu : Form
    {
        public UyeSilmeFormu()
        {
            InitializeComponent();
        }

        void ComboboxDoldur()

        {

            SqlConnection baglanti = new SqlConnection("Server=DESKTOP-9G7COM2;Database=Kutuphane;Integrated Securty=True;");
            SqlCommand uyeleriSil = new SqlCommand("SELECT Uye_No , Adi AS [Üye Adı], Soyadi AS [Üye Soyadı], Eposta AS [Üye E-Posta  Adresi],Telefon AS [Üye Telefon],DoğumTarihi AS [Üye Doğum Günü],UyelikTarihi AS [Üyelik Tarihi],Adres AS [Üye Adresi]FROM Uyeler; ", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(uyeleriSil);
            baglanti.Open();
            da.Fill(dt);
            baglanti.Close();
            comboBox1.DataSource = new BindingSource(dt, null);
            comboBox1.DisplayMember = "Üye E-Posta Adresi";
            comboBox1.ValueMember = "Uye_No";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Üye Adı: " + adTxtBx.Text + "\nÜye soyadı:" + soyadiTxtBx.Text + "\n olan kullanıcıy silmek istediğinize emin misin", "dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                SqlConnection baglanti = new SqlConnection("server=DESKTOP-9G7COM2;Database=Kutuphane;Integrated Securty=True;");
                SqlCommand AlınanKitaplardanSil = new SqlCommand("DELETE FROM AlinanKitaplar WHERE Uye_No\'" + comboBox1.SelectedValue.ToString() + "\';", baglanti);
                SqlCommand kullaniciyiSil = new SqlCommand("DELETE FROM Kullanicilar WHERE  Uye_No\'" + comboBox1.SelectedValue.ToString() + "\';", baglanti);
                SqlCommand uyeyiSil = new SqlCommand("DELETE FROM Uyeler WHERE  Uye_No\'" + comboBox1.SelectedValue.ToString() + "\';", baglanti);
                baglanti.Open();
                kullaniciyiSil.ExecuteNonQuery();
                AlınanKitaplardanSil.ExecuteNonQuery();
                uyeyiSil.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("silindi");
                ComboboxDoldur();
            }
       
        }


    }
}
