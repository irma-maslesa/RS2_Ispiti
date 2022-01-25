
namespace eProdaja.WinUI
{
    partial class frmCovidPasos
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
            this.btnDodaj = new System.Windows.Forms.Button();
            this.dgvPasosi = new System.Windows.Forms.DataGridView();
            this.PasosId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KupacId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KupacImePrezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumIzdavanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumVazenja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasosi)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(12, 12);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 0;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // dgvPasosi
            // 
            this.dgvPasosi.AllowUserToAddRows = false;
            this.dgvPasosi.AllowUserToDeleteRows = false;
            this.dgvPasosi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPasosi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasosi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PasosId,
            this.KupacId,
            this.KupacImePrezime,
            this.DatumIzdavanja,
            this.DatumVazenja});
            this.dgvPasosi.Location = new System.Drawing.Point(13, 52);
            this.dgvPasosi.Name = "dgvPasosi";
            this.dgvPasosi.ReadOnly = true;
            this.dgvPasosi.Size = new System.Drawing.Size(775, 386);
            this.dgvPasosi.TabIndex = 1;
            // 
            // PasosId
            // 
            this.PasosId.DataPropertyName = "CovidPasosId";
            this.PasosId.HeaderText = "PasosId";
            this.PasosId.Name = "PasosId";
            this.PasosId.ReadOnly = true;
            this.PasosId.Visible = false;
            this.PasosId.Width = 70;
            // 
            // KupacId
            // 
            this.KupacId.DataPropertyName = "KupacId";
            this.KupacId.HeaderText = "KupacId";
            this.KupacId.Name = "KupacId";
            this.KupacId.ReadOnly = true;
            this.KupacId.Visible = false;
            this.KupacId.Width = 72;
            // 
            // KupacImePrezime
            // 
            this.KupacImePrezime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KupacImePrezime.DataPropertyName = "KupacImePrezime";
            this.KupacImePrezime.HeaderText = "Ime i prezime kupca";
            this.KupacImePrezime.Name = "KupacImePrezime";
            this.KupacImePrezime.ReadOnly = true;
            // 
            // DatumIzdavanja
            // 
            this.DatumIzdavanja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DatumIzdavanja.DataPropertyName = "DatumIzdavanja";
            this.DatumIzdavanja.HeaderText = "Datum izdavanja";
            this.DatumIzdavanja.Name = "DatumIzdavanja";
            this.DatumIzdavanja.ReadOnly = true;
            // 
            // DatumVazenja
            // 
            this.DatumVazenja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DatumVazenja.DataPropertyName = "DatumVazenja";
            this.DatumVazenja.HeaderText = "Datum važenja";
            this.DatumVazenja.Name = "DatumVazenja";
            this.DatumVazenja.ReadOnly = true;
            // 
            // frmCovidPasos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPasosi);
            this.Controls.Add(this.btnDodaj);
            this.Name = "frmCovidPasos";
            this.Text = "frmCovidPasos";
            this.Load += new System.EventHandler(this.frmCovidPasos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasosi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.DataGridView dgvPasosi;
        private System.Windows.Forms.DataGridViewTextBoxColumn PasosId;
        private System.Windows.Forms.DataGridViewTextBoxColumn KupacId;
        private System.Windows.Forms.DataGridViewTextBoxColumn KupacImePrezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumIzdavanja;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumVazenja;
    }
}