using codae.backend.application.ViewModels;
using System.Collections;
using System.Collections.Generic;

namespace codae.backend.application.Services
{
    public interface IRegiaoService
    {
        int CreateRegiao(RegiaoViewModel regiao);
        void UpdateRegiao(RegiaoViewModel regiao);
        void RemoveRegiao(int regiaoId);
        IEnumerable<RegiaoViewModel> GetAll();
        RegiaoViewModel GetByKey(int regiaoId);
    }
}