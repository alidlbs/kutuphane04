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

namespace Kutuphane
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
            SqlConnection baglanti = new SqlConnection("Server=DESKTOP-9G7COM2;Database=Kutuphane;Integrated Security=True;");
            SqlCommand komut = new SqlCommand("SELECT  * FROM  Kullanicilar WHERE KullaniciAdi=\'" + kullaniciAdiTxtBx.Text + "\' AND  Sifre=\'" + sifreTxtBx.Text + "\';", baglanti);
            baglanti.Open();
            SqlDataReader okuyucu = komut.ExecuteReader();
            if (okuyucu.HasRows)
            {
               
                MessageBox.Show("Kullanıcı adı ve şifre doğru");
                baglanti.Close();
            }
            else
            {
             
                baglanti.Close();
                MessageBox.Show("Kullanıcı adı ya da şifre hatalı");
            }
            okuyucu.Read();
            string kullaniciAdi = okuyucu.GetString(0);
            int yetki = Convert.ToInt32(okuyucu.GetString(2));
            if (yetki==1)
            {
                baglanti.Close();
                YoneticiFormu yFrm = new YoneticiFormu();
                this.Hide();
                kullaniciAdiTxtBx.Text = "";
                sifreTxtBx.Text = "";
                yFrm.ShowDialog();
                this.Show();
            }

            else
            {
                this.Hide();
                kullaniciAdiTxtBx.Text = "";
                sifreTxtBx.Text = "";
                this.Show();
            }
        }
       
    }
    
}
