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
          DataTable KitapLİsteleFormu = new DataTable();

        private void KitapListeleFormu_Load(object sender, EventArgs e)
        {
            VeritabaniIslemleri vi = new VeritabaniIslemleri();
            dataGridView1.DataSource = vi.KitapiUyeListesi();
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
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
    }
    }

