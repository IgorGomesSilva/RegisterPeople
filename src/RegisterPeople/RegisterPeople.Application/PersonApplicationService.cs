using AutoMapper;
using RegisterPeople.Application.Dtos;
using RegisterPeople.Application.Dtos.Person;
using RegisterPeople.Application.Interfaces;
using RegisterPeople.Domain.Entitys;
using RegisterPeople.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterPeople.Application
{
    public class PersonApplicationService : IPersonApplicationService
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonApplicationService(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task AddAsync(PersonDtoCreate personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            await _personService.AddAsync(person);
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync()
        {
            var persons = await _personService.GetAllAsync();
            var personsDto = _mapper.Map<IEnumerable<PersonDto>>(persons);

            return personsDto;
        }

        public async Task<PersonDto> GetByIdAsync(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }

        public async Task RemoveAsync(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            await _personService.RemoveAsync(person);
        }

        public async Task UpdateAsync(PersonDtoUpdate personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            await _personService.UpdateAsync(person);
        }
    }
}
