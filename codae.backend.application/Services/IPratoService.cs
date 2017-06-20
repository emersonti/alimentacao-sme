using codae.backend.application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace codae.backend.application.Services
{
    public interface IPratoService
    {
        int CreateGrupoPrato(GrupoPratoViewModel grupoPratoVM);
        void UpdateGrupoPrato(GrupoPratoViewModel grupoPratoVM);
        void RemoveGrupoPrato(int grupoPratoId);

        int CreatePrato(PratoViewModel pratoVM);
        void UpdatePrato(PratoViewModel pratoVM);
        void RemovePrato(int pratoId);

        Task<IEnumerable<GrupoPratoViewModel>> GetAllAsync();
        GrupoPratoViewModel GetByKey(int grupoPratoId);
        PratoViewModel GetPratoByKey(int pratoId);
    }
}