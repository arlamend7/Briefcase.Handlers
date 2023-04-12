using Briefcase.Handlers.Builder.Interfaces;
using Briefcase.Handlers.Configurations;
using Briefcase.Handlers.Builder;

namespace Briefcase.Handlers.Customizes.Interfaces
{
    public interface IHandlerMapperConfigurarion<T, TMapper>
        where T : class, new()
    {
        void ConfigureMapper(IMapperConfigurationBuilder<T, TMapper> builder);

        MapperConfiguration Build()
        {
            var builder = new MapperConfigurationBuilder<T, TMapper>();
            ConfigureMapper(builder);
            return builder.Build();
        }
    }

}