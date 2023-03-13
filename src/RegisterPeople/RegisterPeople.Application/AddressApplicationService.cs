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

        public async Task Add(AddressDtoCreate addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _addressService.Add(address);
        }

        public async Task<IEnumerable<AddressDto>> GetAll()
        {
            var addresss = await _addressService.GetAll();
            var addresssDto = _mapper.Map<IEnumerable<AddressDto>>(addresss);

            return addresssDto;
        }

        public async Task<AddressDto> GetById(int id)
        {
            var address = await _addressService.GetById(id);
            var addressDto = _mapper.Map<AddressDto>(address);

            return addressDto;
        }

        public async Task Remove(int id)
        {
            var address = await _addressService.GetById(id);
            await _addressService.Remove(address);
        }

        public async Task Update(AddressDtoUpdate addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _addressService.Update(address);
        }
    }
}
