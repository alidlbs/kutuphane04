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
using System.IO;
namespace kutuphane
   
{
    public partial class KitapGuncellemeFormu : Form
    {

        public KitapGuncellemeFormu()
        {
            InitializeComponent();

        }
        DataTable KitaplariListele = new DataTable();

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbBx_KitapListesi.SelectedIndex > -1)
            {
                DialogResult dr = MessageBox.Show("KitapAdı:" + kitapaditxtBx.Text + "\n KitapYazarAdi:" + kitapyazaraditxtBx.Text + "\n KitapBasimEvi:" +kitapbasimevitxtBx.Text + "\nKitapBasimYili:" + KitapBasimYilitxtBx.Text + "\nKitapSayisi:" + kitapsayisitxtBx.Text + "\n Olankisi Silmek istediginize eminmisiniz?", "Silme islemini Onayla", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection baglanti = new SqlConnection("server=DESKTOP-QNPE5CA\\SQLEXPRESS;Database=Kutuphane;Integrated Security=true;");
                        SqlCommand kayitSil = new SqlCommand("UPDATE  Kitaplar SET KitapAdi=\'" + kitapaditxtBx.Text + "\' KitapYazarAdi=\'" + kitapyazaraditxtBx.Text + "\',  KitapBasimEvi=\'" +kitapbasimevitxtBx.Text + "\',  KitapBasimYili\'" + KitapBasimYilitxtBx.Text+ "\',  KitapSayisi=\'" + kitapsayisitxtBx.Text + "\'WHERE Kitap_id=\'" + cmbBx_KitapListesi.SelectedValue + "\';", baglanti);
                        baglanti.Open();
                        kayitSil.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Güncelle işlemi tamamlandı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Güncellemek icin bir ad secmelisiniz");
            }
        }

        private void cmbBx_KitapListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBx_KitapListesi.SelectedIndex > -1)
            {
                try
                {
                    DataRow[] satir = KitaplariListele.Select("ıd=" + cmbBx_KitapListesi.SelectedValue.ToString());
                    kitapaditxtBx.Text = satir[0]["KitapAdı"].ToString();
                    kitapyazaraditxtBx.Text = satir[0]["Yazarı"].ToString();
                    kitapbasimevitxtBx.Text = satir[0]["BasımEvi"].ToString();
                    KitapBasimYilitxtBx.Text = satir[0]["BasımYılı"].ToString();
                    kitapsayisitxtBx.Text = satir[0]["KitapSayısı"].ToString();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
        }

        private void KitapGuncellemeFormu_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("server=DESKTOP-QNPE5CA\\SQLEXPRESS;Database=Kutuphane;Integrated Security=true;");
                SqlCommand kayitlistele = new SqlCommand("SELECT Kitap_id,KitapAdi AS [KitapAdı],KitapYazarAdi AS [YazarAdı],KitapBasimEvi AS [BasımEvi],KitapBasimYili AS [BasımYılı],KitapSayisi FROM Kitaplar;", baglanti);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(kayitlistele);
                baglanti.Open();
                sqlDataAdapter.Fill(KitaplariListele);
                baglanti.Close();

                if (KitaplariListele.Rows.Count > 0)
                {
                    cmbBx_KitapListesi.DisplayMember = "isim";
                    cmbBx_KitapListesi.ValueMember = "Kitap_id";
                    cmbBx_KitapListesi.DataSource = new BindingSource(KitaplariListele, null);
                }
                else
                {
                    MessageBox.Show("Rehber listesi bos", "Kayıt yok", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }
            }

            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
    

   