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
    public partial class UyeGuncellemeFormu : Form
    {
        public UyeGuncellemeFormu()
        {
            InitializeComponent();
            ComboboxDoldur();
            comboBox1.SelectedIndex = -1;
        }
        VeritabaniIslemleri vi = new VeritabaniIslemleri();
        void ComboboxDoldur()
        {
            
            comboBox1.DataSource = new BindingSource(vi.YoneticiComboboxDataTable(), null);
            comboBox1.DisplayMember = "Üye E-Posta Adresi";
            comboBox1.ValueMember = "Uye_No";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex !=-1)
            {
                string[] sonuc = vi.YoneticiUyeNoyaGoreUyeBilgisi(comboBox1.SelectedValue.ToString());
                if(sonuc[1] !="-1")
                {
                    try
                    {
                        adTxtBx.Text = sonuc[1];
                        soyadiTxtBx.Text = sonuc[2];
                        epostaTxtBx.Text = sonuc[3];
                        telTxtBx.Text = sonuc[4];
                        dogumTarihiDateTimePicker.Value = DateTime.Parse(sonuc[5]);
                        uyelikTarihiDateTimePicker.Value = DateTime.Parse(sonuc[6]);
                        adresRichTtxBx.Text = sonuc[7];
                    }
                    catch
                    { }
                }
                else
                {
                    MessageBox.Show("Veri tabanı baglandı hatası oluşdu", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string uye_adi = adTxtBx.Text;
            string uye_soyadi = soyadiTxtBx.Text;
            string tel = telTxtBx.Text;
            string adres = adresRichTtxBx.Text;
            string eposta = epostaTxtBx.Text;
            string dogumTarihi = dogumTarihiDateTimePicker.Value.ToShortDateString();
            string uyelikTarihi = uyelikTarihiDateTimePicker.Value.ToShortDateString();
            if(vi.YoneticiUyeGuncelleme(comboBox1.SelectedValue.ToString(),uye_adi,uye_soyadi,tel,adres,eposta,dogumTarihi,uyelikTarihi))
            {
                MessageBox.Show("Üye bilgileri başarılı bir şekilde Güncellendi", "Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ComboboxDoldur();
            }
            else
            {
                MessageBox.Show("Veri tabanı baglantı hatası oluşdu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void UyeGuncellemeFormu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
