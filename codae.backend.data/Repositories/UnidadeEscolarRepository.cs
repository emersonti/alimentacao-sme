using codae.backend.core.Models;
using codae.backend.data.Contexts;

namespace codae.backend.data.Repositories
{
    public class UnidadeEscolarRepository : Repository<UnidadeEscolar>
    {
        public UnidadeEscolarRepository(CODAEContext context) : base(context) { }
    }
}