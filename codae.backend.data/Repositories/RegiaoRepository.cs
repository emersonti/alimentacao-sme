using codae.backend.core.Models;
using codae.backend.data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace codae.backend.data.Repositories
{
    public class RegiaoRepository: Repository<Regiao>
    {
        public RegiaoRepository(CODAEContext context): base(context)  {}

        public IEnumerable<Regiao> GetRegioesPorAgrupamento(AgrupamentoEnum agrupamentoId) =>        
            _dbSet.AsNoTracking().Where(r => r.AgrupamentoId == agrupamentoId).ToList();        
    }
}
