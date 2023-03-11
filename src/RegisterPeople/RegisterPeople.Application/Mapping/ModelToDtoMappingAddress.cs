using AutoMapper;
using RegisterPeople.Application.Dtos;
using RegisterPeople.Domain.Entitys;

namespace RegisterPeople.Application.Mapping
{
    public class ModelToDtoMappingAddress : Profile
    {
        public ModelToDtoMappingAddress()
        {
            AddressDtoMap();
        }

        private void AddressDtoMap()
        {
            CreateMap<Address, AddressDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Logadouro, opt => opt.MapFrom(x => x.Logadouro))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(x => x.Bairro))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(x => x.Numero))
                .ForMember(dest => dest.Complemento, opt => opt.MapFrom(x => x.Complemento))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(x => x.Cidade))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(x => x.Estado))
                .ForMember(dest => dest.Pais, opt => opt.MapFrom(x => x.Pais))
                .ForMember(dest => dest.CEP, opt => opt.MapFrom(x => x.CEP));
        }
    }
}
