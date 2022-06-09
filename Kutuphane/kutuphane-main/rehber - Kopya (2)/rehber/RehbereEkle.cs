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
namespace rehber
{
    public partial class RehbereEkle : Form
    {
        public RehbereEkle()
        {
            InitializeComponent();
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            if (txtBx_Ad.TextLength > 0 && txtBx_Soyad.TextLength > 0 && txtBx_Tel.TextLength > 0)
            {
                try
                {
                   
                         SqlConnection baglanti = new SqlConnection("server=DESKTOP-D3LPI3L\\SQLEXPRESS;Database=TelefonRehberiMSSqlIle;Integrated Security=true;");
                    SqlCommand kayitEkleme = new SqlCommand("INSERT INTO liste(Ad,Soyad,Telefon)VALUES(\'" + txtBx_Ad.Text + "\',\'" + txtBx_Soyad.Text + "\',\'" + txtBx_Tel.Text + "\');", baglanti);
                    baglanti.Open();
                    kayitEkleme.ExecuteNonQuery();
                    baglanti.Close();
                    DialogResult dr = MessageBox.Show("Rehbere kayıt eklendi,Yeni kayıt eklemek istermisiniz?", "ekleme başarılı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        txtBx_Ad.Text = "";
                        txtBx_Soyad.Text = "";
                        txtBx_Tel.Text = "";
                        txtBx_Ad.Select();
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

