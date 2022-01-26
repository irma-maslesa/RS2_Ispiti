using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdaja.WinUI
{
    public partial class frmProizvodKomentar : Form
    {
        APIService Service = new APIService("ProizvodKomentari");

        public frmProizvodKomentar() {
            InitializeComponent();
            dgvKomentari.AutoGenerateColumns = false;
        }

        private async void frmProizvodKomentar_Load(object sender, EventArgs e) {
            await getGridData();
        }

        private async Task getGridData() {
            var list = await Service.GetAll<List<ProizvodKomentarResponse>>(null);

            dgvKomentari.DataSource = list;
        }

        private async void btnDodaj_Click(object sender, EventArgs e) {
            frmDodajKomentar frm = new frmDodajKomentar();

            if (frm.ShowDialog() == DialogResult.OK)
                await getGridData();
        }
    }
}
