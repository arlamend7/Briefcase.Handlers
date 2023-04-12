using Briefcase.Handlers.Configurations;
using Briefcase.Handlers.Customizes.Interfaces;
using Briefcase.System.Builders.Interfaces;
using System;
using System.Linq.Expressions;

namespace Briefcase.Handlers.Builder.Interfaces
{
    public interface IHandlerConfigurationBuilder : IBuilderOf<HandlerConfiguration>
    {
        IHandlerConfigurationBuilder SetMapper(MapperConfiguration mapper);
    }
    public interface IHandlerConfigurationBuilder<T> : IHandlerConfigurationBuilder
        where T : class, new()
    {
        IHandlerConfigurationBuilder<T> CreateMapper<TMapper>(Action<IMapperConfigurationBuilder<T, TMapper>> configureMapper);
        IHandlerConfigurationBuilder<T> For<TProp>(Expression<Func<T, TProp>> expression, Func<IPropertyConfigInfoBuilder<T, TProp>, bool> configurationMethod);
        IHandlerConfigurationBuilder<T> SetMapper<TMapper>(IHandlerMapperConfigurarion<T, TMapper> editHandlerMapperConfig);
        IHandlerConfigurationBuilder<T> Ignore(string property);
        IHandlerConfigurationBuilder<T> Ignore<TProp>(Expression<Func<T, TProp>> expression);
        IHandlerConfigurationBuilder<T> OnCreate(Action<T> action);
        IHandlerConfigurationBuilder<T> OnEdit(Action<T> action);
        IHandlerConfigurationBuilder<T> OnDelete(Action<T> action);
    }
}