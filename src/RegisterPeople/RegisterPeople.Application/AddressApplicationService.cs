using AutoMapper;
using RegisterPeople.Application.Dtos;
using RegisterPeople.Application.Dtos.Address;
using RegisterPeople.Application.Interfaces;
using RegisterPeople.Domain.Entitys;
using RegisterPeople.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterPeople.Application
{
    public class AddressApplicationService : IAddressApplicationService
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AddressApplicationService(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        public async Task AddAsync(AddressDtoCreate addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _addressService.AddAsync(address);
        }

        public async Task<IEnumerable<AddressDto>> GetAllAsync()
        {
            var address = await _addressService.GetAllAsync();
            var addresssDto = _mapper.Map<IEnumerable<AddressDto>>(address);

            return addresssDto;
        }

        public async Task<AddressDto> GetByIdAsync(int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            var addressDto = _mapper.Map<AddressDto>(address);

            return addressDto;
        }

        public async Task RemoveAsync(int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            await _addressService.RemoveAsync(address);
        }

        public async Task UpdateAsync(AddressDtoUpdate addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _addressService.UpdateAsync(address);
        }

        public async Task<IEnumerable<AddressDto>> GetByIdPersonAsync(int idPerson)
        {
            var address = await _addressService.GetByIdPersonAsync(idPerson);
            var addressDto = _mapper.Map<IEnumerable<AddressDto>>(address);

            return addressDto;
        }
    }
}
