using AutoMapper;
using RegisterPeople.Application.Dtos;
using RegisterPeople.Domain.Entitys;

namespace RegisterPeople.Application.Mapping
{
    public class DtoToModelMappingPerson : Profile
    {
        public DtoToModelMappingPerson()
        {
            PersonMap();
        }

        private void PersonMap()
        {
            CreateMap<PersonDto, Person>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(x => x.Sobrenome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(x => x.CPF))
                .ForMember(dest => dest.DataCadastro, opt => opt.Ignore())
                .ForMember(dest => dest.IsAtivo, opt => opt.Ignore());
        }
    }
}
