using codae.backend.core.Models;
using codae.backend.data.Contexts;

namespace codae.backend.data.Repositories
{
    public class CardapioRepository : Repository<Cardapio>
    {
        public CardapioRepository(CODAEContext context) : base(context) { }
    }
}
