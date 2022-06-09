using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;


namespace kutuphane
{
    public partial class KitapEkleFormu : Form
    {
        public KitapEkleFormu()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
VeritabaniIslemleri vi = new VeritabaniIslemleri();

            string KitapAdi = kitapaditxtBx.Text;
            string KitapYazari = kitapyazaraditxtBx.Text;
            string KitapYayinEvi = kitapbasimevitxtBx.Text;
            string KitapBasimYili = KitapBasimYilitxtBx.Text;
            string KitapSayisi = kitapsayisitxtBx.Text;
            if (kitapaditxtBx.TextLength > 0 && kitapyazaraditxtBx.TextLength > 0 && kitapbasimevitxtBx.TextLength > 0 && kitapsayisitxtBx.TextLength > 0 && KitapBasimYilitxtBx.TextLength > 0)
            {

                try
                {
                if (vi.KitapUyeEkleme(KitapAdi, KitapYazari, KitapYayinEvi, KitapBasimYili, KitapSayisi))
                {
                    MessageBox.Show("Kitap Ekleme Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Veri Tabanına bağlantı başarısız", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Basım Yılı Veya Kitap Adetini Sayısal olarak giriniz !", "Hata", MessageBoxButtons.OK);

            }
        }
        }


        private void btn_Vazgec_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KitapEkleFormu_Load(object sender, EventArgs e)
        {

        }

        private void yoneticiChkbx_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

}
