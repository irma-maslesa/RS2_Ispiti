using eProdaja.Mobile.ViewModels;
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eProdaja.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProizvodiDetailPage : ContentPage
    {
        ProizvodiDetailViewModel model = null;
        public ProizvodiDetailPage(Proizvodi proizvod)
        {
            InitializeComponent();
            BindingContext = model = new ProizvodiDetailViewModel() {  Proizvod = proizvod};
        }
    }
}