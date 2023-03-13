using RegisterPeople.Domain.Entitys;
using RegisterPeople.Domain.Interfaces.Repository;
using RegisterPeople.Domain.Interfaces.Service;

namespace RegisterPeople.Domain.Services
{
    public class PersonService : ServiceBase<Person>, IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository) : base(personRepository)
        {
            _personRepository = personRepository;
        }
    }
}
