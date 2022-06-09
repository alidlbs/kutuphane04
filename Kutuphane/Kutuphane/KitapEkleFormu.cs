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

            if (kitapaditxtBx.TextLength > 0 && kitapyazaraditxtBx.TextLength > 0 && kitapbasimevitxtBx.TextLength > 0 && kitapsayisitxtBx.TextLength>0 && KitapBasimYilitxtBx.TextLength>0)
            {
                try
                {

                    SqlConnection baglanti = new SqlConnection("server=DESKTOP-QNPE5CA\\SQLEXPRESS;Database=TelefonRehberiMSSqlIle;Integrated Security=true;");
                    SqlCommand kayitEkleme = new SqlCommand("INSERT INTO Kitaplar(KitapAdi,KitapYazarAdi,KitapBasimEvi,KitapBasimYili,KitapSayisi)VALUES(\'" + kitapaditxtBx.Text + "\',\'" + kitapyazaraditxtBx.Text + "\',\'" + kitapbasimevitxtBx.Text + "\',\'" + KitapBasimYilitxtBx.Text + "\',\'" + kitapsayisitxtBx.Text + "\');", baglanti);
                    baglanti.Open();
                    kayitEkleme.ExecuteNonQuery();
                    baglanti.Close();
                    DialogResult dr = MessageBox.Show("Rehbere kayıt eklendi,Yeni kayıt eklemek istermisiniz?", "ekleme başarılı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                       kitapaditxtBx.Text = "";
                       kitapyazaraditxtBx.Text = "";
                       kitapbasimevitxtBx.Text = "";
                        kitapsayisitxtBx.Text = "";
                       KitapBasimYilitxtBx.Text = "";
                        kitapaditxtBx.Select();
                    }
                    else
                    {
                        Close();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("ad,soyad,telefon tümü gerekli alanlardır,Boş gecirilemez!", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Vazgec_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
