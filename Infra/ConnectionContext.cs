using AgendaAPI.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Infra
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) { }

        public DbSet<Contact> Contact { get; set; }
    }
}
