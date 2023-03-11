using RegisterPeople.Application.Dtos;
using System.Collections.Generic;

namespace RegisterPeople.Application.Interfaces
{
    public interface IAddressApplicationService
    {
        void Add(AddressDto addressDto);
        void Update(AddressDto addressDto);
        void Remove(AddressDto addressDto);
        IEnumerable<AddressDto> GetAll();
        AddressDto GetById(int id);
    }
}
