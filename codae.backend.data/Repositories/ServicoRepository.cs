using codae.backend.core.Models;
using codae.backend.data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace codae.backend.data.Repositories
{
    public class ServicoRepository : Repository<Servico>
    {
        public ServicoRepository(CODAEContext context) : base(context) { }

        public override Servico GetByKey(object key)
        {
            var entity = base.GetByKey(key);
            if (entity != null)
                _context.Entry(entity).Collection(s => s.Composicao).Load();

            return entity;
        }
        
    }    
}
