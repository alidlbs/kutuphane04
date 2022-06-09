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
    public partial class KitapListeleFormu : Form
    {
        public KitapListeleFormu()
        {
            InitializeComponent();
        }

        private void KitapListeleFormu_Load(object sender, EventArgs e)
        {

            DataTable KitaplariLİste = new DataTable();
            try
            {
                SqlConnection baglanti = new SqlConnection("server=DESKTOP-QNPE5CA\\SQLEXPRESS;Database=Kutuphane;Integrated Security=true;");
                SqlCommand kayitListesi = new SqlCommand("SELECT Kitap_id,KitapAdi AS [KitapAdı],KitapYazarAdi AS [YazarAdı],KitapBasimEvi AS [BasımEvi],KitapBasimYili AS [BasımYılı],KitapSayisi FROM Kitaplar;", baglanti);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(kayitListesi);
                baglanti.Open();
                sqlDataAdapter.Fill(KitaplariLİste);
                baglanti.Close();
                if (KitaplariLİste.Rows.Count > 0)
                {
                    dataGridView1.DataSource = KitaplariLİste;
                    dataGridView1.Columns[0].Visible = false;

                }
                else
                {
                    MessageBox.Show("rehber liste boş", "kayıt yok", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
            }
        }
    }
    }

