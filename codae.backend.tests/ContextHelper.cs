using codae.backend.data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace codae.backend.tests
{
    public static class ContextHelper
    {
        private static readonly CODAEContext _context;

        static ContextHelper()
        {
            _context = new CODAEContext();

            _context.Database.Migrate();
            _context.EnsureSeed();
        }

        public static CODAEContext Context => _context;
    }
}
