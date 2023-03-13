using RegisterPeople.Application.Dtos;
using RegisterPeople.Application.Dtos.Person;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterPeople.Application.Interfaces
{
    public interface IPersonApplicationService
    {
        Task AddAsync(PersonDtoCreate personDto);
        Task UpdateAsync(PersonDtoUpdate personDto);
        Task RemoveAsync(int id);
        Task<IEnumerable<PersonDto>> GetAllAsync();
        Task<PersonDto> GetByIdAsync(int id);
    }
}
