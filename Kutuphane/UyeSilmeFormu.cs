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
    public partial class UyeSilmeFormu : Form
    {
        public UyeSilmeFormu()
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
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Uye Adi:" + adTxtBx.Text + "\nÜye Soyadı:" + soyadiTxtBx.Text + "\n olan üyeyi silmek istediğinize eminmisiniz?\n(Silme işlemi üyenin daha önce aldıgı kitaplara ait bilgileri ve" + "üyeye ait kullanıcı bilgisini de silecektir.))", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dr==DialogResult.Yes)
            {
                if (vi.YoneticiUyeSilme(comboBox1.SelectedValue.ToString()))
                {
                    MessageBox.Show("Üye başarılı bir şekilde silindi", "Silinci", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ComboboxDoldur();
                }
                else
                {
                    MessageBox.Show("Veri tabanı Hatası oluşdu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);       
                }
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                string[] sonuc = vi.YoneticiUyeNoyaGoreUyeBilgisi(comboBox1.SelectedValue.ToString());
                if (sonuc[1] != "-1")
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
                    MessageBox.Show("Veri tabanı hatası oluştu", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        
           
        
   
        private void UyeSilmeFormu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

