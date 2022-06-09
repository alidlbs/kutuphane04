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
using System.Data;
using System.Data.SqlClient;
namespace rehber
{
    public partial class RehberiListele : Form
    {
        public RehberiListele()
        {
            InitializeComponent();
        }

        private void RehberiListele_Load(object sender, EventArgs e)
        {
            DataTable rehberLİste = new DataTable();
            try
            {
                SqlConnection baglanti = new SqlConnection("server=DESKTOP-D3LPI3L\\SQLEXPRESS;Database=TelefonRehberiMSSqlIle;Integrated Security=true;");
                SqlCommand kayitListesi = new SqlCommand("SELECT Id,Ad AS [İsim],Soyad AS [Soyisim],Telefon FROM liste;", baglanti);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(kayitListesi);
                baglanti.Open();
                sqlDataAdapter.Fill(rehberLİste);
                baglanti.Close();
                if(rehberLİste.Rows.Count>0)
                {
                    dataGridView1.DataSource = rehberLİste;
                    dataGridView1.Columns[0].Visible = false;

                }
                else
                {
                    MessageBox.Show("rehber liste boş", "kayıt yok",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message, "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}