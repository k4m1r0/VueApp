using Bogus;
using VueApp.Server.Repository.Interfaces;
using Person = VueApp.Server.Models.Person;

namespace VueApp.Server.Repository.FakerRepositories
{
    public class FakerPersonRepository : IPersonRepository
    {
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            Faker<Person> fakePersonReport = FakeData();

            var result = await Task.Run(() => fakePersonReport.Generate(100));

            return result;
        }

        public async Task<IEnumerable<Person>> GetAllAsync(int pageNumber, int pageSize)
        {

            Faker<Person> fakePersonReport = FakeData();

            var result = await Task.Run(() => fakePersonReport.Generate(100));

            return result.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public async Task<Person> GetByIdAsync(Guid id)
        {
            throw await Task.Run(() => new NotImplementedException());
        }

        public async Task<Guid> AddAsync(Person entity)
        {
            throw await Task.Run(() => new NotImplementedException());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            throw await Task.Run(() => new NotImplementedException());
        }

        public async Task<int> UpdateAsync(Person entity)
        {
            throw await Task.Run(() => new NotImplementedException());

        }

        private static Faker<Person> FakeData()
        {
            var fakePerson = new Faker<Person>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(c => c.PhoneNumber, f => f.Person.Phone);

            return fakePerson;
        }

    }
}
