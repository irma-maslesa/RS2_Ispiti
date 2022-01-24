using eProdaja.Mobile.Services;
using eProdaja.Mobile.ViewModels;
using eProdaja.Model;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eProdaja.Mobile.ViewModels
{
    public class ProizvodiViewModel : BaseViewModel
    {
        private readonly APIService _proizvodiService = new APIService("Proizvodi");
        private readonly APIService _vrsteProizvodaService = new APIService("VrsteProizvodum");


        public ProizvodiViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Proizvodi> ProizvodiList { get; set; } = new ObservableCollection<Proizvodi>();
        public ObservableCollection<VrsteProizvodum> VrsteProizvodaList { get; set; } = new ObservableCollection<VrsteProizvodum>();
        VrsteProizvodum _selectedVrstaProizvoda = null;

        public VrsteProizvodum SelectedVrstaProizvoda
        {
            get { return _selectedVrstaProizvoda; }
            set
            {
                SetProperty(ref _selectedVrstaProizvoda, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }

            }
        }

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            if (VrsteProizvodaList.Count == 0)
            {
                var vrsteProizvodaList = await _vrsteProizvodaService.Get<List<VrsteProizvodum>>(null);

                foreach (var vrsteProizvoda in vrsteProizvodaList)
                {
                    VrsteProizvodaList.Add(vrsteProizvoda);
                }
            }

            if (SelectedVrstaProizvoda != null)
            {
                ProizvodiSearchRequest searchRequest = new ProizvodiSearchRequest();
                searchRequest.VrstaId = SelectedVrstaProizvoda.VrstaId;

                var list = await _proizvodiService.Get<IList<Proizvodi>>(searchRequest);
                ProizvodiList.Clear();
                foreach (var item in list)
                {
                    ProizvodiList.Add(item);
                }
            }
            
        }

    }
}
