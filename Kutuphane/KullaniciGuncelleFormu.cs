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
using System.IO;
namespace kutuphane
{
    public partial class KullaniciGuncelleFormu : Form
    {
        public KullaniciGuncelleFormu()
        {
            InitializeComponent();
            ComboboxDoldur();
            comboBox1.SelectedIndex = -1;
        }
        VeritabaniIslemleri vi = new VeritabaniIslemleri();
        private void KullaniciGuncelleFormu_Load(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                string[] sonuc = vi.KullaniciAdinaGoreCagirma(comboBox1.SelectedValue.ToString());
                if (sonuc[1] != "-1")
                {
                    try
                    {
                        AdtxtBx.Text = sonuc[0];
                        SifretxtBx.Text = sonuc[1];

                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Veri tabanı Bağlantı hatası oluştu", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {



            SqlConnection baglanti = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KutuphaneOtomasyonuu.mdf;Integrated Security=True");

            string kullanici_adi = AdtxtBx.Text;
            string Sifre = SifretxtBx.Text;
            string yonetici = "0";

            if (yoneticiChkbx.Checked == true)
            {
                yonetici = "1";
            }
            string kadadi = comboBox1.SelectedValue.ToString();
            if (vi.KullaniciGuncelleme(kadadi, Sifre, yonetici))
            {
                MessageBox.Show("Üye bilgileri başarılı bir şekilde güncellendi ", "Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ComboboxDoldur();
            }
            else
            {
                MessageBox.Show("Veri Tabanı Baglantı Hatası oluştu ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void ComboboxDoldur()
        {
            comboBox1.DataSource = new BindingSource(vi.KullaniciComboBoxDataTable(), null); //ComboBox'ımız içerisine veritablomuzdaki bilgileri ekleme
            comboBox1.DisplayMember = "Kullanıcı Adı"; //Combobox'da görüntülenecek değer
            comboBox1.ValueMember = "Kullanıcı Adı"; //Combobox'dan seçilen değer
            comboBox1.SelectedIndex = -1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
