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
    public partial class frmCovidPasos : Form
    {

        APIService Service = new APIService("CovidPasos");

        public frmCovidPasos() {
            InitializeComponent();
            dgvPasosi.AutoGenerateColumns = false;
        }

        private async void btnDodaj_Click(object sender, EventArgs e) {
            frmAddCPasos frm = new frmAddCPasos();

            if(frm.ShowDialog() == DialogResult.OK)
                await getPasose();
        }

        private async void frmCovidPasos_Load (object sender, EventArgs e) {
            await getPasose();
        }

        private async Task getPasose() {
            var list = await Service.Get();

            dgvPasosi.DataSource = list;
        }
    }
}
