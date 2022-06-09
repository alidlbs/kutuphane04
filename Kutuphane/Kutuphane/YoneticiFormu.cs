using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Kutuphane
{
    public partial class YoneticiFormu : Form
    {
        public YoneticiFormu()
        {
            InitializeComponent();
        }

        private void üyeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach ( Form item in this.MdiChildren)
            {
                item.Close();
            }

            UyeEklemeFormu frm = new UyeEklemeFormu();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }
    }
}
