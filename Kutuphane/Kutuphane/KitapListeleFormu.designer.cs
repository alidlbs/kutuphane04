
namespace kutuphane
{
    partial class KitapListeleFormu
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.KitapAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KitapYazarAdı = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KitapBasımEvi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KitapBasımYılı = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KitapSayısı = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KitapAdi,
            this.KitapYazarAdı,
            this.KitapBasımEvi,
            this.KitapBasımYılı,
            this.KitapSayısı});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(784, 361);
            this.dataGridView1.TabIndex = 0;
            // 
            // KitapAdi
            // 
            this.KitapAdi.HeaderText = "KitapAdi";
            this.KitapAdi.Name = "KitapAdi";
            this.KitapAdi.ReadOnly = true;
            // 
            // KitapYazarAdı
            // 
            this.KitapYazarAdı.HeaderText = "KitapYazarAdı";
            this.KitapYazarAdı.Name = "KitapYazarAdı";
            this.KitapYazarAdı.ReadOnly = true;
            // 
            // KitapBasımEvi
            // 
            this.KitapBasımEvi.HeaderText = "KitapBasımEvi";
            this.KitapBasımEvi.Name = "KitapBasımEvi";
            this.KitapBasımEvi.ReadOnly = true;
            // 
            // KitapBasımYılı
            // 
            this.KitapBasımYılı.HeaderText = "KitapBasımYılı";
            this.KitapBasımYılı.Name = "KitapBasımYılı";
            this.KitapBasımYılı.ReadOnly = true;
            // 
            // KitapSayısı
            // 
            this.KitapSayısı.HeaderText = "KitapSayısı";
            this.KitapSayısı.Name = "KitapSayısı";
            this.KitapSayısı.ReadOnly = true;
            // 
            // KitapListeleFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.dataGridView1);
            this.Name = "KitapListeleFormu";
            this.Text = "KitapListeleFormu";
            this.Load += new System.EventHandler(this.KitapListeleFormu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn KitapAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn KitapYazarAdı;
        private System.Windows.Forms.DataGridViewTextBoxColumn KitapBasımEvi;
        private System.Windows.Forms.DataGridViewTextBoxColumn KitapBasımYılı;
        private System.Windows.Forms.DataGridViewTextBoxColumn KitapSayısı;
    }
}