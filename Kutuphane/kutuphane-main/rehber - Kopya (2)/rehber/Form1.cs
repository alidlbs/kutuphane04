using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rehber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tn_Ekle_Click(object sender, EventArgs e)
        {
            RehbereEkle rehberekle = new RehbereEkle();
            rehberekle.StartPosition = FormStartPosition.CenterParent;
            rehberekle.ShowDialog();
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            RehberdenSil rsil = new RehberdenSil();
            rsil.StartPosition = FormStartPosition.CenterParent;
            rsil.ShowDialog();
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            RehberiGuncelle rgüncelle = new RehberiGuncelle();
            rgüncelle.StartPosition = FormStartPosition.CenterParent;
            rgüncelle.ShowDialog();
        }

        private void btn_Listele_Click(object sender, EventArgs e)
        {
            RehberiListele rlistele = new RehberiListele();
            rlistele.StartPosition = FormStartPosition.CenterParent;
            rlistele.ShowDialog();
        }
    }
}
