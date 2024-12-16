using AgendaAPI.Domain.Model;

namespace AgendaAPI.Application.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task AddAsync(Contact contact);
        Task UpdateAsync(Contact contact);
        Task DeleteAsync(int id);
    }

    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Contact>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Contact> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Contact contact) => _repository.AddAsync(contact);
        public Task UpdateAsync(Contact contact) => _repository.UpdateAsync(contact);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
