using AutoMapper;
using RegisterPeople.Application.Dtos;
using RegisterPeople.Domain.Entitys;

namespace RegisterPeople.Application.Mapping
{
    public class DtoToModelMappingAddress : Profile
    {
        public DtoToModelMappingAddress()
        {
            AddressMap();
        }

        private void AddressMap()
        {
            CreateMap<AddressDto, Address>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
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
