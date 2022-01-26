
namespace eProdaja.WinUI
{
    partial class frmDodajKomentar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.cbVrsta = new System.Windows.Forms.ComboBox();
            this.cbProizvod = new System.Windows.Forms.ComboBox();
            this.txtKomentar = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // cbVrsta
            // 
            this.cbVrsta.FormattingEnabled = true;
            this.cbVrsta.Location = new System.Drawing.Point(131, 40);
            this.cbVrsta.Name = "cbVrsta";
            this.cbVrsta.Size = new System.Drawing.Size(150, 21);
            this.cbVrsta.TabIndex = 0;
            this.cbVrsta.SelectedIndexChanged += new System.EventHandler(this.cbVrsta_SelectedIndexChanged);
            // 
            // cbProizvod
            // 
            this.cbProizvod.FormattingEnabled = true;
            this.cbProizvod.Location = new System.Drawing.Point(131, 79);
            this.cbProizvod.Name = "cbProizvod";
            this.cbProizvod.Size = new System.Drawing.Size(150, 21);
            this.cbProizvod.TabIndex = 1;
            // 
            // txtKomentar
            // 
            this.txtKomentar.Location = new System.Drawing.Point(3, 19);
            this.txtKomentar.MaxLength = 50;
            this.txtKomentar.Name = "txtKomentar";
            this.txtKomentar.Size = new System.Drawing.Size(237, 96);
            this.txtKomentar.TabIndex = 2;
            this.txtKomentar.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = " Vrsta proizvoda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = " Proizvod";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKomentar);
            this.groupBox1.Location = new System.Drawing.Point(35, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 125);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Komentar";
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(243, 276);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 6;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // frmDodajKomentar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 311);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbProizvod);
            this.Controls.Add(this.cbVrsta);
            this.Name = "frmDodajKomentar";
            this.Text = "drmDodajKomentar";
            this.Load += new System.EventHandler(this.frmDodajKomentar_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbVrsta;
        private System.Windows.Forms.ComboBox cbProizvod;
        private System.Windows.Forms.RichTextBox txtKomentar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.ErrorProvider err;
    }
}