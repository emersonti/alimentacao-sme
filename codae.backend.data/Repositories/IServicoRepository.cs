using codae.backend.core.Models;
using codae.backend.interfaces;
using System.Collections;
using System.Collections.Generic;

namespace codae.backend.data.Repositories
{
    public interface IServicoRepository: IRepository<Servico>
    {
        IEnumerable<ItemServico> GetItensServico(int servicoId);
    }
}