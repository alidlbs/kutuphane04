﻿
namespace kutuphane
{
    partial class KitapGuncelleFormu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitapGuncelleFormu));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBx_KitapListesi = new System.Windows.Forms.ComboBox();
            this.kitapaditxtBx = new System.Windows.Forms.TextBox();
            this.kitapYazaritxtBx = new System.Windows.Forms.TextBox();
            this.kitapYayinEvitxtBx = new System.Windows.Forms.TextBox();
            this.kitapBasimYilitxtBx = new System.Windows.Forms.TextBox();
            this.kitapsayisitxtBx = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Güncelleme:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "KitapAdi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "KitapYazari:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "KitapYayinEvi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "KitapBasimYili:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "KitapSayisi:";
            // 
            // cmbBx_KitapListesi
            // 
            this.cmbBx_KitapListesi.DisplayMember = "KitapAdi";
            this.cmbBx_KitapListesi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBx_KitapListesi.FormattingEnabled = true;
            this.cmbBx_KitapListesi.Location = new System.Drawing.Point(103, 6);
            this.cmbBx_KitapListesi.Name = "cmbBx_KitapListesi";
            this.cmbBx_KitapListesi.Size = new System.Drawing.Size(140, 21);
            this.cmbBx_KitapListesi.TabIndex = 6;
            this.cmbBx_KitapListesi.ValueMember = "Kitap_id";
            this.cmbBx_KitapListesi.SelectedIndexChanged += new System.EventHandler(this.cmbBx_KitapListesi_SelectedIndexChanged);
            // 
            // kitapaditxtBx
            // 
            this.kitapaditxtBx.Location = new System.Drawing.Point(103, 35);
            this.kitapaditxtBx.Name = "kitapaditxtBx";
            this.kitapaditxtBx.Size = new System.Drawing.Size(116, 20);
            this.kitapaditxtBx.TabIndex = 7;
            // 
            // kitapYazaritxtBx
            // 
            this.kitapYazaritxtBx.Location = new System.Drawing.Point(103, 62);
            this.kitapYazaritxtBx.Name = "kitapYazaritxtBx";
            this.kitapYazaritxtBx.Size = new System.Drawing.Size(116, 20);
            this.kitapYazaritxtBx.TabIndex = 8;
            // 
            // kitapYayinEvitxtBx
            // 
            this.kitapYayinEvitxtBx.Location = new System.Drawing.Point(103, 91);
            this.kitapYayinEvitxtBx.Name = "kitapYayinEvitxtBx";
            this.kitapYayinEvitxtBx.Size = new System.Drawing.Size(116, 20);
            this.kitapYayinEvitxtBx.TabIndex = 9;
            // 
            // kitapBasimYilitxtBx
            // 
            this.kitapBasimYilitxtBx.Location = new System.Drawing.Point(103, 118);
            this.kitapBasimYilitxtBx.Name = "kitapBasimYilitxtBx";
            this.kitapBasimYilitxtBx.Size = new System.Drawing.Size(116, 20);
            this.kitapBasimYilitxtBx.TabIndex = 10;
            // 
            // kitapsayisitxtBx
            // 
            this.kitapsayisitxtBx.Location = new System.Drawing.Point(103, 148);
            this.kitapsayisitxtBx.Name = "kitapsayisitxtBx";
            this.kitapsayisitxtBx.Size = new System.Drawing.Size(116, 20);
            this.kitapsayisitxtBx.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(22, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Guncelle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(164, 212);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "İptal";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // KitapGuncelleFormu
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(583, 310);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.kitapsayisitxtBx);
            this.Controls.Add(this.kitapBasimYilitxtBx);
            this.Controls.Add(this.kitapYayinEvitxtBx);
            this.Controls.Add(this.kitapYazaritxtBx);
            this.Controls.Add(this.kitapaditxtBx);
            this.Controls.Add(this.cmbBx_KitapListesi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KitapGuncelleFormu";
            this.Text = "KitapGuncelleFormu";
            this.Load += new System.EventHandler(this.KitapGuncelleFormu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBx_KitapListesi;
        private System.Windows.Forms.TextBox kitapaditxtBx;
        private System.Windows.Forms.TextBox kitapYazaritxtBx;
        private System.Windows.Forms.TextBox kitapYayinEvitxtBx;
        private System.Windows.Forms.TextBox kitapBasimYilitxtBx;
        private System.Windows.Forms.TextBox kitapsayisitxtBx;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}