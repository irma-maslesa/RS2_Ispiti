using eProdaja.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace eProdaja.Mobile.ViewModels
{
    public class NarudzbaViewModel : BaseViewModel
    {
        public ObservableCollection<ProizvodiDetailViewModel> ProizvodiList { get; set; } = new ObservableCollection<ProizvodiDetailViewModel>();

        public void Init()
        {
            ProizvodiList.Clear();
            foreach(var item in CartService.Cart)
            {
                ProizvodiList.Add(item.Value);
            }
        }
    }
}
