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
    public partial class frmDodajKomentar : Form
    {
        APIService Service = new APIService("ProizvodKomentari");

        APIService VrstaProizvodaService = new APIService("VrsteProizvodum");
        APIService ProizvodService = new APIService("Proizvodi");

        public frmDodajKomentar() {
            InitializeComponent();
            cbProizvod.Enabled = false;
        }

        private async void frmDodajKomentar_Load(object sender, EventArgs e) {
            await LoadVrste();
        }

        private async Task LoadVrste() {
            var vrsteProizvoda = await VrstaProizvodaService.GetAll<List<VrsteProizvodum>>();
            cbVrsta.DataSource = vrsteProizvoda;
            cbVrsta.ValueMember = "VrstaId";
            cbVrsta.DisplayMember = "Naziv";
        }

        private async void cbVrsta_SelectedIndexChanged(object sender, EventArgs e) {
            var odabrani = ((VrsteProizvodum)cbVrsta.SelectedItem).VrstaId;

            ProizvodiSearchObject search = new ProizvodiSearchObject { VrstaId = odabrani };

            var proizvodi = await ProizvodService.GetAll<List<Model.Proizvodi>>(search);
            cbProizvod.DataSource = proizvodi;
            cbProizvod.ValueMember = "ProizvodId";
            cbProizvod.DisplayMember = "Naziv";

            cbProizvod.Enabled = true;
        }

        private async void btnSpremi_Click(object sender, EventArgs e) {

            var odabraniProizvod = ((Model.Proizvodi)cbProizvod.SelectedItem);
            var komentar = txtKomentar.Text;

            if (Validiraj(odabraniProizvod, komentar)) {
                ProizvodKomentarInsertRequest request = new ProizvodKomentarInsertRequest {
                    Datum = DateTime.Now,
                    Komentar = komentar,
                    KupacId = APIService.Id,
                    ProizvodId = odabraniProizvod.ProizvodId
                };

                var response = await Service.Insert<ProizvodKomentarResponse>(request);


                if (response != null) {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }


        }

        private bool Validiraj(Model.Proizvodi odabraniProizvod, string komentar) {
            bool validno = true;

            if (odabraniProizvod == null) {
                err.SetError(cbProizvod, "Obavezno polje");
                validno = false;
            }
            else
                err.SetError(cbProizvod, null);

            if (string.IsNullOrWhiteSpace(komentar)) {
                err.SetError(txtKomentar, "Obavezno polje");
                validno = false;
            }
            else
                err.SetError(txtKomentar, null);

            return validno;
        }
    }
}
