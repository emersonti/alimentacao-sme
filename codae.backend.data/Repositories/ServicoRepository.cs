using System;
using codae.backend.core.Models;
using codae.backend.data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace codae.backend.data.Repositories
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(CODAEContext context) : base(context) { }

        public override Servico GetByKey(object key)
        {
            var entity = base.GetByKey(key);
            if (entity != null)
                _context.Entry(entity).Collection(s => s.Composicao).Load();

            return entity;
        }

        public IEnumerable<ItemServico> GetItensServico(int servicoId) => 
            _dbSet.Include(s => s.Composicao).SelectMany(s => s.Composicao).Where(c => c.ServicoId == servicoId);
    }    
}
