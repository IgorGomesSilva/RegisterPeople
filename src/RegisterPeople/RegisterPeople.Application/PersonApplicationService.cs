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

        public async Task Add(PersonDtoCreate personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            await _personService.Add(person);
        }

        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            var persons = await _personService.GetAll();
            var personsDto = _mapper.Map<IEnumerable<PersonDto>>(persons);

            return personsDto;
        }

        public async Task<PersonDto> GetById(int id)
        {
            var person = await _personService.GetById(id);
            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }

        public async Task Remove(int id)
        {
            var person = await _personService.GetById(id);
            await _personService.Remove(person);
        }

        public async Task Update(PersonDtoUpdate personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            await _personService.Update(person);
        }
    }
}
