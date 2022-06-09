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
    public partial class UyeListelemeFormu : Form
    {
        public UyeListelemeFormu()
        {
            InitializeComponent();
        }

        private void UyeListelemeFormu_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-QNPE5CA\\SQLEXPRESS;Database=Kutuphane;Integrated Security=true;");
            SqlCommand uyeleriGetir=new SqlCommand("SELECT Uye_No,Adi AS[Üye Adı],Soyadi[SoyAdı],Eposta AS[Üye E-Posta Adresi],Telefon AS[Üye Telefonu],DogumTarihi AS[ÜyeDogumGünü],UyelikTarihi AS[ÜyelikTarihi],Adres AS[Üye Adresi] FROM Uyeler;", baglanti);
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
