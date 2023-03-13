using RegisterPeople.Application.Dtos;
using RegisterPeople.Application.Dtos.Person;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterPeople.Application.Interfaces
{
    public interface IPersonApplicationService
    {
        Task Add(PersonDtoCreate personDto);
        Task Update(PersonDtoUpdate personDto);
        Task Remove(int id);
        Task<IEnumerable<PersonDto>> GetAll();
        Task<PersonDto> GetById(int id);
    }
}
