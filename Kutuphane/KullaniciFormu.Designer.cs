
namespace kutuphane
{
    partial class KullaniciFormu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ödünçToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teslimEttigimKitaplarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.henüzTeslimEtmediğimKitaplarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kütüphanedekiKitapListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ödünçToolStripMenuItem,
            this.kütüphanedekiKitapListesiToolStripMenuItem,
            this.hakkındaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ödünçToolStripMenuItem
            // 
            this.ödünçToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teslimEttigimKitaplarToolStripMenuItem,
            this.henüzTeslimEtmediğimKitaplarToolStripMenuItem});
            this.ödünçToolStripMenuItem.Name = "ödünçToolStripMenuItem";
            this.ödünçToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.ödünçToolStripMenuItem.Text = "Teslim ettigim Kitaplar";
            // 
            // teslimEttigimKitaplarToolStripMenuItem
            // 
            this.teslimEttigimKitaplarToolStripMenuItem.Name = "teslimEttigimKitaplarToolStripMenuItem";
            this.teslimEttigimKitaplarToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.teslimEttigimKitaplarToolStripMenuItem.Text = "Teslim ettigim Kitaplar";
            this.teslimEttigimKitaplarToolStripMenuItem.Click += new System.EventHandler(this.teslimEttigimKitaplarToolStripMenuItem_Click);
            // 
            // henüzTeslimEtmediğimKitaplarToolStripMenuItem
            // 
            this.henüzTeslimEtmediğimKitaplarToolStripMenuItem.Name = "henüzTeslimEtmediğimKitaplarToolStripMenuItem";
            this.henüzTeslimEtmediğimKitaplarToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.henüzTeslimEtmediğimKitaplarToolStripMenuItem.Text = "Henüz Teslim Etmediğim Kitaplar";
            this.henüzTeslimEtmediğimKitaplarToolStripMenuItem.Click += new System.EventHandler(this.henüzTeslimEtmediğimKitaplarToolStripMenuItem_Click);
            // 
            // kütüphanedekiKitapListesiToolStripMenuItem
            // 
            this.kütüphanedekiKitapListesiToolStripMenuItem.Name = "kütüphanedekiKitapListesiToolStripMenuItem";
            this.kütüphanedekiKitapListesiToolStripMenuItem.Size = new System.Drawing.Size(164, 20);
            this.kütüphanedekiKitapListesiToolStripMenuItem.Text = "Kütüphanedeki Kitap Listesi";
            // 
            // hakkındaToolStripMenuItem
            // 
            this.hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            this.hakkındaToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.hakkındaToolStripMenuItem.Text = "Hakkında";
            this.hakkındaToolStripMenuItem.Click += new System.EventHandler(this.hakkındaToolStripMenuItem_Click);
            // 
            // KullaniciFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 385);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "KullaniciFormu";
            this.Text = "KullaniciFormu";
            this.Load += new System.EventHandler(this.KullaniciFormu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ödünçToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teslimEttigimKitaplarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem henüzTeslimEtmediğimKitaplarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kütüphanedekiKitapListesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem;
    }
}