using Case.Handlers.Builder.Interfaces;
using Case.Handlers.Configurations;
using Case.Handlers.Customizes.Interfaces;
using Case.System.Builders.Interfaces;
using System;
using System.Linq.Expressions;

namespace Case.Handlers.Builder
{
    public interface IEditHandlerConfigurationBuilder : IBuilderOf<EditHandlerConfiguration>
    {
        IEditHandlerConfigurationBuilder SetMapper(MapperConfiguration mapper);
    }
    public interface IEditHandlerConfigurationBuilder<T> : IEditHandlerConfigurationBuilder
        where T : class, new()
    {
        IEditHandlerConfigurationBuilder<T> CreateMapper<TMapper>(Action<IMapperConfigurationBuilder<T, TMapper>> configureMapper);
        IEditHandlerConfigurationBuilder<T> ForProperty<TProp>(Expression<Func<T, TProp>> expression, Func<IPropertyConfigInfoBuilder<T, TProp>, bool> configurationMethod);
        IEditHandlerConfigurationBuilder<T> SetMapper<TMapper>(IEditHandlerMapperConfigurarion<T, TMapper> editHandlerMapperConfig);
    }
}