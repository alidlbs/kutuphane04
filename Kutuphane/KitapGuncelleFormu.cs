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
    public partial class KitapGuncelleFormu : Form
    {
        public KitapGuncelleFormu()
        {
            InitializeComponent();
            ComboboxDoldur();
            cmbBx_KitapListesi.SelectedIndex = -1;
        }
        VeritabaniIslemleri vi = new VeritabaniIslemleri();
        void ComboboxDoldur()
        {

            cmbBx_KitapListesi.DataSource = new BindingSource(vi.KitapComboboxDataTable(), null);
            cmbBx_KitapListesi.DisplayMember = "KitapAdi";
            cmbBx_KitapListesi.ValueMember = "Kitap_id";
        }
        private void KitapGuncelleFormu_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kitapAdi = kitapaditxtBx.Text;
            string kitapYazari = kitapYazaritxtBx.Text;
            string kitapYayinEvi = kitapYayinEvitxtBx.Text;
            string kitapBasimYili = kitapBasimYilitxtBx.Text;
            string KitapSayisi = kitapsayisitxtBx.Text;
             if (vi.KitapGuncelleme(cmbBx_KitapListesi.SelectedValue.ToString(), kitapAdi, kitapYazari,  kitapYayinEvi, kitapBasimYili, KitapSayisi))
            {
                MessageBox.Show("Üye bilgileri başarılı bir şekilde Güncellendi", "Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ComboboxDoldur();
            }
            else
            {
                MessageBox.Show("Veri tabanı baglantı hatası oluşdu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
                        kitapYazaritxtBx.Text = sonuc[2];
                        kitapYayinEvitxtBx.Text = sonuc[3];
                       kitapBasimYilitxtBx.Text = sonuc[4];
                        kitapsayisitxtBx.Text = sonuc[5];
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
    }
}
