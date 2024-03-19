using VueApp.Server.Models;

namespace VueApp.Server.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<IEnumerable<Person>> GetAllAsync(int pageNumber, int pageSize);
        Task<Person> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(Person entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> UpdateAsync(Person entity);
    }
}
