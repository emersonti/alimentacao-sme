using codae.backend.core.Models;
using codae.backend.data.Contexts;

namespace codae.backend.data.Repositories
{
    public class PratoRepository : Repository<Prato>
    {
        public PratoRepository(CODAEContext context) : base(context) { }
    }
}