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
    public partial class UyeListeleme : Form
    {
        public UyeListeleme()
        {
            InitializeComponent();
        }

        private void UyeListeleme_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-9G7COM2;Database=Kutuphane;Integrated Securty=True;");
            SqlCommand uyeleriGetir = new SqlCommand("SELECT Uye_No,Adi AS [Üye adı],Soyadi AS [Üye Soyadı],Eposta AS [Üye  E-Posta Adresi],Telefon AS [Üye Telefonu],DogumTarihi AS [Üye Doğum Günü],UyelikTarihi] AS [Üyelik Tarihi],Adres AS [Üye Adresi]FROM Uyeler;", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(uyeleriGetir);
            baglanti.Open();
            da.Fill(dt);
            baglanti.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;

        }
    }
}
