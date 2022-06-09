using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
namespace kutuphane
{
    public partial class KitapSilmeFormu : Form
    {
        public KitapSilmeFormu()
        {
            InitializeComponent();
            ComboboxDoldur();
          
        }
        VeritabaniIslemleri vi = new VeritabaniIslemleri();
        void ComboboxDoldur()
        {
            cmbBx_KitapListesi.DataSource = new BindingSource(vi.KitapComboboxDataTable(), null);
            cmbBx_KitapListesi.DisplayMember = "KitapAdi";
            cmbBx_KitapListesi.ValueMember = "Kitap_id";
        }
        private void KitapSilmeFormu_Load(object sender, EventArgs e)
        {

            
        }

        private void cmbBx_KitapListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBx_KitapListesi.SelectedIndex != -1)
            {
                string[] sonuc = vi.KitapaGoreUyeBilgisi(cmbBx_KitapListesi.SelectedValue.ToString());
                if (sonuc[1] != "-1")
                {
                    try
                    {
                        kitapaditxtBx.Text = sonuc[1];
                       kitapyazaraditxtBx.Text = sonuc[2];
                        kitapbasimevitxtBx.Text = sonuc[3];
                        KitapBasimYilitxtBx.Text = sonuc[4];
                        kitapsayisitxtBx.Text = sonuc[5];
                    }
                    catch
                    { }
                }
                else
                {
                    MessageBox.Show(" Uyeyi Sildi", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("KitapAdi:" + kitapaditxtBx.Text + "\nKitapYazari:" + kitapyazaraditxtBx.Text + "\n olan üyeyi silmek istediğinize eminmisiniz?\n(Silme işlemi üyenin daha önce aldıgı kitaplara ait bilgileri ve" + "üyeye ait kullanıcı bilgisini de silecektir.))", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                if (vi.KitapiUyeSilme(cmbBx_KitapListesi.SelectedValue.ToString()))
                {
                    MessageBox.Show("Üye başarılı bir şekilde silindi", "Silinci", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ComboboxDoldur();
                }
                else
                {
                    MessageBox.Show("Silindi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    }
