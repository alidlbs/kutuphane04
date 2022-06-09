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
    public partial class RehberiGuncelle : Form
    {
        public RehberiGuncelle()
        {
            InitializeComponent();
        }
        string[,] RehberiListele = new string[100, 3];
        private void RehberiGuncelle_Load(object sender, EventArgs e)
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

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            if (cmbBx_AdListesi.SelectedIndex > -1)
            {
                if (txtBx_Ad.TextLength > 0 && txtBx_Soyad.TextLength > 0 && txtBx_Tel.TextLength > 0)
                {
                    try
                    {
                        StreamWriter rehberYazici = new StreamWriter(".\\rehber.ntp2");
                        for (int i = 0; i < RehberiListele.Length; i++)
                        {
                            if (RehberiListele[i, 0] != null)
                            {
                                if (i != cmbBx_AdListesi.SelectedIndex)
                                {
                                    rehberYazici.WriteLine(RehberiListele[i, 0] + "#" + RehberiListele[i, 1] + "#" + RehberiListele[i, 2]);
                                }
                                else
                                {
                                    rehberYazici.WriteLine(txtBx_Ad.Text + "#" + txtBx_Soyad.Text + "#" + txtBx_Tel.Text);
                                }

                            }
                           

                            else
                            {
                                break;
                            }
                        }
                        rehberYazici.Close();
                        MessageBox.Show("Güncelleme İşlemi tamamlandı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ad, Soyad ve Telefon alanlarının tümü gerekli alanlardır, boş geçilemezler!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Güncelleme için bir ad seçmelisiniz!");
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

