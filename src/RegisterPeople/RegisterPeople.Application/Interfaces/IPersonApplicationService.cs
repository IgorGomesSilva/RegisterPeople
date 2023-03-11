using RegisterPeople.Application.Dtos;
using System.Collections.Generic;

namespace RegisterPeople.Application.Interfaces
{
    public interface IPersonApplicationService
    {
        void Add(PersonDto personDto);
        void Update(PersonDto personDto);
        void Remove(PersonDto personDto);
        IEnumerable<PersonDto> GetAll();
        PersonDto GetById(int id);
    }
}
