using Case.Handlers.Customizes.Interfaces;
using System;
using System.Linq.Expressions;

namespace Case.Handlers.Builder.Interfaces
{
    public interface IEditHandlerConfigurationBuilder<T> where T : class, new()
    {
        IEditHandlerConfigurationBuilder<T> CreateMapper<TMapper>(Action<IMapperConfigurationBuilder<T, TMapper>> configureMapper);
        IEditHandlerConfigurationBuilder<T> ForProperty<TProp>(Expression<Func<T, TProp>> expression, Func<IPropertyConfigInfoBuilder<T, TProp>, bool> configurationMethod);
        IEditHandlerConfigurationBuilder<T> SetMapper<TMapper>(IEditHandlerMapperConfigurarion<T, TMapper> editHandlerMapperConfig);
    }
}