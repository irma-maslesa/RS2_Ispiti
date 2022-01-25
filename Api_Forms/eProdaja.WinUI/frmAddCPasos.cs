using eProdaja.Model;
using eProdaja.Model.Requests;
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
    public partial class frmAddCPasos : Form
    {
        APIService Service = new APIService("CovidPasos");
        public frmAddCPasos() {
            InitializeComponent();
        }

        private async void frmAddCPasos_Load(object sender, EventArgs e) {
            await LoadKupce();
        }

        private async Task LoadKupce() {
            var uloge = await Service.GetKupce();
            cmbKupac.DataSource = uloge;
            cmbKupac.ValueMember = "Id";
            cmbKupac.DisplayMember = "Naziv";
        }

        private async void btnSpremi_Click(object sender, EventArgs e) {
            if (validirajFormu()) {
                CovidPasosInsertRequest request = new CovidPasosInsertRequest {
                    KupacId = ((LoV)cmbKupac.SelectedItem).Id,
                    DatumIzdavanja = dtpIzdavanje.Value,
                    DatumVazenja = dtpVazenje.Value
                };

                await Service.InsertPasos(request);

                DialogResult = DialogResult.OK;
                Close();

            }
        }

        private bool validirajFormu() {
            bool validno = true;

            if (cmbKupac.SelectedItem == null) {
                validno = false;
                err.SetError(cmbKupac, "Obavezno polje");
            }
            else
                err.SetError(cmbKupac, null);

            if (dtpVazenje.Value < dtpIzdavanje.Value) {
                validno = false;
                err.SetError(dtpVazenje, "Vrijednost nije validna");
            }
            else
                err.SetError(dtpVazenje, null);


            return validno;
        }
    }
}
