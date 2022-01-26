using eProdaja.Model;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eProdaja.Services
{
    public interface IProizvodKomentarService
    {
        IEnumerable<ProizvodKomentarResponse> Get();
        IEnumerable<ProizvodKomentarResponse> Search(ProizvodKomentarSearchRequest search);
        ProizvodKomentarResponse Insert(ProizvodKomentarInsertRequest request);
    }
}
