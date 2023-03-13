using AutoMapper;
using RegisterPeople.Application.Dtos.Person;
using RegisterPeople.Domain.Entitys;

namespace RegisterPeople.Application.Mapping
{
    public class ModelToDtoMappingPerson : Profile
    {
        public ModelToDtoMappingPerson()
        {
            PersonDtoMap();
        }

        private void PersonDtoMap()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(x => x.Sobrenome))
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(x => x.CPF))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email));

            CreateMap<Person, PersonDtoCreate>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(x => x.Sobrenome))
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(x => x.CPF))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email));

            CreateMap<Person, PersonDtoUpdate>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
               .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
               .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(x => x.Sobrenome))
               .ForMember(dest => dest.IsAtivo, opt => opt.MapFrom(x => x.IsAtivo))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email));
        }
    }
}
