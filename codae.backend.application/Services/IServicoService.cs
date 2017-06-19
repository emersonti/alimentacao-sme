using codae.backend.application.ViewModels;
using System.Collections.Generic;

namespace codae.backend.application.Services
{
    public interface IServicoService
    {
        int CreateServico(ServicoViewModel servico);
        void UpdateServico(ServicoViewModel servico);
        void RemoveServico(int servicoId);

        IEnumerable<ServicoViewModel> GetAll();
        ServicoViewModel GetByKey(int servicoId);
    }
}