using Case.Handlers.Configurations;
using Case.System.Builders.Interfaces;
using System;
using System.Linq.Expressions;

namespace Case.Handlers.Builder.Interfaces
{
    public interface IMapperConfigurationBuilder : IBuilderOf<MapperConfiguration>
    {
        IMapperConfigurationBuilder IgnoreAllDefaultValues();
        IMapperConfigurationBuilder SetTypes(Type type, Type interactionType);
    }

    public interface IMapperConfigurationBuilder<T, TRequest> : IMapperConfigurationBuilder
    {
        /// <summary>
        ///     Set a configuration for a property of the entity based on the class that you are using to map
        /// </summary>
        /// <typeparam name="TProp">Property of the entity</typeparam>
        /// <param name="expression">Expression to return the simples property and get the name of it</param>
        /// <param name="configurationMethod">The function the configure the property on the class that you want to use to map</param>
        /// <returns></returns>
        IMapperConfigurationBuilder<T, TRequest> ForProperty<TProp>(Expression<Func<T, TProp>> expression, Func<IPropertyMapperBuilder<T, TRequest, TProp>, bool> configurationMethod);
        
        /// <summary>
        ///  It will ignore all default values for all not configurated properties
        /// </summary>
        /// <returns></returns>
        new IMapperConfigurationBuilder<T, TRequest> IgnoreAllDefaultValues();
    }
}