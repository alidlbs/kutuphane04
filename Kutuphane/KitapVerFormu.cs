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
    public partial class KitapVerFormu : Form
    {
        public KitapVerFormu()
        {
            InitializeComponent();
        }
        DataTable KitapLİsteleFormu = new DataTable();
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            KitapVerUyeSecFormu frm = new KitapVerUyeSecFormu();
            frm.Kitap_id = dataGridView1.SelectedCells[0].Value.ToString();
            frm.KitapAdi = dataGridView1.SelectedCells[1].Value.ToString();
            frm.KitapYazari = dataGridView1.SelectedCells[2].Value.ToString();
            frm.KitapYayinEvi = dataGridView1.SelectedCells[3].Value.ToString();
            frm.KitapBasimYili = dataGridView1.SelectedCells[4].Value.ToString();
            frm.KitapSayisi = Convert.ToInt32(dataGridView1.SelectedCells[5].Value);
            frm.ShowDialog();

        }

        private void KitapVerFormu_Load(object sender, EventArgs e)
        {
            DataTable KitapLİsteleFormu = new DataTable();
            try
            {
                SqlConnection baglanti = new SqlConnection("server=DESKTOP-QNPE5CA\\SQLEXPRESS;Database=Kutuphane;Integrated Security=true;");
                SqlCommand kayitListesi = new SqlCommand("SELECT Kitap_id,KitapAdi AS [KitapAdi],KitapYazari AS [YazarAdi],KitapYayinEvi AS [BasımEvi],KitapBasimYili AS [BasımYılı],KitapSayisi " +
                    "FROM Kitaplar;", baglanti);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(kayitListesi);
                baglanti.Open();
                sqlDataAdapter.Fill(KitapLİsteleFormu);
                baglanti.Close();
                if (KitapLİsteleFormu.Rows.Count > 0)
                {
                    dataGridView1.DataSource = KitapLİsteleFormu;
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


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (Form item in this.MdiChildren)
            {
                item.Close();
            }
            KitapVerUyeSecFormu frm = new KitapVerUyeSecFormu();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
