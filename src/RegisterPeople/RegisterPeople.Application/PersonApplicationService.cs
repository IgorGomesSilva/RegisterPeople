using AutoMapper;
using RegisterPeople.Application.Dtos;
using RegisterPeople.Application.Interfaces;
using RegisterPeople.Domain.Entitys;
using RegisterPeople.Domain.Interfaces.Service;
using System.Collections.Generic;

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

        public void Add(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            _personService.Add(person);
        }

        public IEnumerable<PersonDto> GetAll()
        {
            var persons = _personService.GetAll();
            var personsDto = _mapper.Map<IEnumerable<PersonDto>>(persons);

            return personsDto;
        }

        public PersonDto GetById(int id)
        {
            var person = _personService.GetById(id);
            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }

        public void Remove(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            _personService.Remove(person);
        }

        public void Update(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            _personService.Update(person);
        }
    }
}
