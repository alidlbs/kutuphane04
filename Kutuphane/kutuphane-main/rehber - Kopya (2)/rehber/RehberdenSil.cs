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
namespace rehber
{
    public partial class RehberdenSil : Form
    {
        public RehberdenSil()
        {
            InitializeComponent();
        }
        string[,] RehberiListele = new string[100, 3];
        private void RehberdenSil_Load(object sender, EventArgs e)
        {
            if (File.Exists(".\\rehber.ntp2") == true)
            {
                try
                {
                    StreamReader rehberokuyucusu = new StreamReader(".\\rehber.ntp2");
                    int i = 0;
                    while (rehberokuyucusu.EndOfStream == false)
                    {   
                        string[] kisibilgileri = rehberokuyucusu.ReadLine().Split('#');
                        cmbBx_AdListesi.Items.Add(kisibilgileri[0]);
                        RehberiListele[i, 0] = kisibilgileri[0];
                        RehberiListele[i, 1] = kisibilgileri[1];
                        RehberiListele[i, 2] = kisibilgileri[2];
                        i++;
                    }
                    rehberokuyucusu.Close();
                    if (i == 0)
                    {
                        MessageBox.Show("Rehber listesi Boş", "Kayıt Yok", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Close();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Rehber Kayıt Dosyasına Ulaşılamıyor", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {

            if (cmbBx_AdListesi.SelectedIndex > -1)
            {
                DialogResult dr = MessageBox.Show("adı:" + txtBx_Ad.Text + "\n Soyadı:" + txtBx_Soyad.Text + "\n Telefonu:" + txtBx_Tel.Text + "\n Olankisi:    ");
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        StreamWriter rehberyazici = new StreamWriter(".\\rehber.ntp2");
                        for (int i = 0; i < RehberiListele.Length; i++)
                        {
                            if (RehberiListele[i, 0] != null)
                            {
                                if (i != cmbBx_AdListesi.SelectedIndex)
                                {
                                    rehberyazici.WriteLine(RehberiListele[i, 0] + "#" + RehberiListele[i, 1] + "#" + RehberiListele[i, 2]);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        rehberyazici.Close();
                        MessageBox.Show("Silme işlemi tamamlandı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    MessageBox.Show("Güncelleme için  ad secmelisiniz");    

                }
            }
        }

        private void cmbBx_AdListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBx_Ad.Text = RehberiListele[cmbBx_AdListesi.SelectedIndex, 0];
            txtBx_Soyad.Text = RehberiListele[cmbBx_AdListesi.SelectedIndex, 1];
            txtBx_Tel.Text = RehberiListele[cmbBx_AdListesi.SelectedIndex, 2];
        }

        private void btn_Vazgec_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

