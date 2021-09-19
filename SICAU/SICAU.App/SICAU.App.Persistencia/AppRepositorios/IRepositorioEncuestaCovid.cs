using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioEncuestaCovid
    {
        IEnumerable<EncuestaCovid> GetAllEncuestaCovid();
        EncuestaCovid AddEncuestaCovid(EncuestaCovid encuestaCovid);
        EncuestaCovid UpdateEncuestaCovid(EncuestaCovid encuestaCovid);
        void DeleteEncuestaCovid(int idEncuestaCovid);
        EncuestaCovid GetEncuestaCovid(int idEncuestaCovid);
    }
}