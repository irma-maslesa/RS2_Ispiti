using eProdaja.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Mobile.Services
{
    public static class CartService
    {
        public static Dictionary<int, ProizvodiDetailViewModel> Cart { get; set; } = new Dictionary<int, ProizvodiDetailViewModel>();
    }
}
