using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane
{
    public partial class UyeEklemeFormu : Form
    {
        public UyeEklemeFormu()
        {
            InitializeComponent();
        }
           VeritabaniIslemleri vi = new VeritabaniIslemleri();
        private void button1_Click(object sender, EventArgs e)
        {
            string Adi = adTxtBx.Text;
            string Soyadi = soyadiTxtBx.Text;
            string Tel =telTxtBx.Text;
            string Adres = adresRichTtxBx.Text;
            string Eposta = epostaTxtBx.Text;
            string DogumTarihi = dogumTarihiDateTimePicker.Value.ToShortDateString();
            string UyelikTarihi = uyelikTarihiDateTimePicker.Value.ToShortDateString();
            string KullaniciAdi = kullanıcıAdiTxtBx.Text;
            string Sifre = sifreTxtBx.Text;
            string Yonetici = "0";
            if (yoneticiChkbx.Checked == true)
            {
                Yonetici = "1";
            }
            
            if(vi.YoneticiUyeEkleme(Adi,Soyadi,Tel,Adres,Eposta,DogumTarihi,UyelikTarihi,KullaniciAdi,Sifre,Yonetici))
            {
                MessageBox.Show("kullanıcı eklendi");
            }
            else
            {
                MessageBox.Show("kullanıcı eklenemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UyeEklemeFormu_Load(object sender, EventArgs e)
        {

        }

        private void yoneticiChkbx_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
