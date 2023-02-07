using Case.Handlers.Builder;
using Case.Handlers.Configurations;

namespace Case.Handlers.Customizes.Interfaces
{
    public interface IEditHandlerMapperConfigurarion<T, TMapper> 
        where T : class, new()
    {
        void ConfigureMapper(MapperConfigurationBuilder<T, TMapper> builder);

         MapperConfiguration Build()
        {
            var builder = new MapperConfigurationBuilder<T, TMapper>();
            ConfigureMapper(builder);
            return builder.Build();
        } 
    }

}