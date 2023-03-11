using AutoMapper;
using RegisterPeople.Application.Dtos;
using RegisterPeople.Application.Interfaces;
using RegisterPeople.Domain.Entitys;
using RegisterPeople.Domain.Interfaces.Service;
using System.Collections.Generic;

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

        public void Add(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            _addressService.Add(address);
        }

        public IEnumerable<AddressDto> GetAll()
        {
            var addresss = _addressService.GetAll();
            var addresssDto = _mapper.Map<IEnumerable<AddressDto>>(addresss);

            return addresssDto;
        }

        public AddressDto GetById(int id)
        {
            var address = _addressService.GetById(id);
            var addressDto = _mapper.Map<AddressDto>(address);

            return addressDto;
        }

        public void Remove(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            _addressService.Remove(address);
        }

        public void Update(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            _addressService.Update(address);
        }
    }
}
