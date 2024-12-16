using AgendaAPI.Domain.Model;
using AgendaAPI.Infra;
using Microsoft.EntityFrameworkCore;

public class ContactRepository : IContactRepository
{
    private readonly ConnectionContext _context;

    public ContactRepository(ConnectionContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contact>> GetAllAsync() => await _context.Contact.ToListAsync();
    public async Task<Contact> GetByIdAsync(int id) => await _context.Contact.FindAsync(id);
    public async Task AddAsync(Contact contact) { await _context.Contact.AddAsync(contact); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(Contact contact) { _context.Contact.Update(contact); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(int id) { var contact = await GetByIdAsync(id); _context.Contact.Remove(contact); await _context.SaveChangesAsync(); }
}