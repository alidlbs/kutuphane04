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
namespace kutuphane
{
    public partial class GirisFormu : Form
    {
        public GirisFormu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VeritabaniIslemleri vi = new VeritabaniIslemleri();
            string[] sonuc = vi.kullaniciGirisKontrolu(kullaniciAdiTxtBx.Text, sifreTxtBx.Text);

            if (sonuc[0]=="1")
            {
                string KullaniciAdi = sonuc[1];
                int yetki = Convert.ToInt32(sonuc[2]);
                int uye_No = Convert.ToInt32(sonuc[3]);
                if (yetki == 1)
                {

                    YoneticiFormu yFrm = new YoneticiFormu();
                    this.Hide();
                    kullaniciAdiTxtBx.Text = "";
                    sifreTxtBx.Text = "";
                    yFrm.ShowDialog();
                    this.Show();
                    kullaniciAdiTxtBx.Focus();
                }
                else
                {
                    KullaniciFormu kfrm = new KullaniciFormu();
                    this.Hide();
                    kullaniciAdiTxtBx.Text = "";
                    sifreTxtBx.Text = "";
                    kfrm.kullaniciAdi = KullaniciAdi;
                    kfrm.uye_No = uye_No;
                    kfrm.ShowDialog();
                    this.Show();
                    kullaniciAdiTxtBx.Focus();
                }
            }
            else
            {              
                MessageBox.Show("Kullanıcı adı veya şifre hatalı");
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void GirisFormu_Load(object sender, EventArgs e)
        {

        }
    }
}
