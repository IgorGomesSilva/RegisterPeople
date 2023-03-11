using Autofac;
using AutoMapper;
using RegisterPeople.Application;
using RegisterPeople.Application.Interfaces;
using RegisterPeople.Application.Mapping;
using RegisterPeople.Domain.Interfaces.Repository;
using RegisterPeople.Domain.Interfaces.Service;
using RegisterPeople.Domain.Services;
using RegisterPeople.Infrastructure.Data.Repository;

namespace RegisterPeople.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            // Application
            builder.RegisterType<PersonApplicationService>().As<IPersonApplicationService>();
            builder.RegisterType<AddressApplicationService>().As<IAddressApplicationService>();
            // Service
            builder.RegisterType<PersonService>().As<IPersonService>();
            builder.RegisterType<AddressService>().As<IAddressService>();
            // Repository
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>();
            // Mapping
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelMappingPerson());
                cfg.AddProfile(new ModelToDtoMappingPerson());
                cfg.AddProfile(new DtoToModelMappingAddress());
                cfg.AddProfile(new ModelToDtoMappingAddress());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();


            #endregion IOC
        }
    }
}
