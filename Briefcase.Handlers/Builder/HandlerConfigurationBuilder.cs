using Briefcase.Handlers.Builder.Interfaces;
using Briefcase.Handlers.Configurations;
using Briefcase.Handlers.Customizes.Interfaces;
using Briefcase.System.Builders;
using System;
using System.Linq.Expressions;

namespace Briefcase.Handlers.Builder
{
    internal class HandlerConfigurationBuilder : BuilderOf<HandlerConfiguration>, IHandlerConfigurationBuilder
    {
        public IHandlerConfigurationBuilder SetMapper(MapperConfiguration mapper)
        {
            EditOn(x => x.EditMappers, mapper);
            return this;
        }
    }

    internal class EditHandlerConfigurationBuilder<T>
        : HandlerConfigurationBuilder,
        IHandlerConfigurationBuilder<T> where T : class, new()
    {
        public new HandlerConfiguration<T> Value => new HandlerConfiguration<T>(base.Value);
        public IHandlerConfigurationBuilder<T> For<TProp>(Expression<Func<T, TProp>> expression, Func<IPropertyConfigInfoBuilder<T, TProp>, bool> configurationMethod)
        {
            PropertyConfigurationBuilder<T, TProp> propertyEditConfig = new PropertyConfigurationBuilder<T, TProp>();

            propertyEditConfig.ForMember(expression);

            configurationMethod(propertyEditConfig);

            var build = propertyEditConfig.Build();

            EditOn(x => x.Properties, build);

            return this;
        }

        public IHandlerConfigurationBuilder<T> SetMapper<TMapper>(IHandlerMapperConfigurarion<T, TMapper> editHandlerMapperConfig)
        {
            if (typeof(T) != Value.Type)
                throw new Exception("Classe mapeada esta incoerente");

            var config = new MapperConfigurationBuilder<T, TMapper>();
            editHandlerMapperConfig.ConfigureMapper(config);
            var build = config.Build();
            SetMapper(build);
            return this;
        }
        public IHandlerConfigurationBuilder<T> CreateMapper<TMapper>(Action<IMapperConfigurationBuilder<T, TMapper>> configureMapper)
        {
            var mapperBuilder = new MapperConfigurationBuilder<T, TMapper>();
            configureMapper(mapperBuilder);

            var build = mapperBuilder.Build();
            SetMapper(build);
            return this;
        }
        protected override void OnInstanciate(HandlerConfiguration Value)
        {
            EditOn(x => x.Type, typeof(T));
        }

        public IHandlerConfigurationBuilder<T> OnCreate(Action<T> action)
        {
            EditOn(x => x.OnCreate, x => action((T)x));
            return this;
        }

        public IHandlerConfigurationBuilder<T> OnEdit(Action<T> action)
        {
            EditOn(x => x.OnEdit, x => action((T)x));
            return this;
        }

        public IHandlerConfigurationBuilder<T> OnDelete(Action<T> action)
        {
            EditOn(x => x.OnDelete, x => action((T)x));
            return this;
        }

        public IHandlerConfigurationBuilder<T> Ignore(string property)
        {
            PropertyConfigurationBuilder<T> propertyEditConfig = new PropertyConfigurationBuilder<T>();

            propertyEditConfig.ForMember(property);

            propertyEditConfig.Ignore();

            var build = propertyEditConfig.Build();

            EditOn(x => x.Properties, build);
            return this;
        }

        public IHandlerConfigurationBuilder<T> Ignore<TProp>(Expression<Func<T, TProp>> expression)
        {
            PropertyConfigurationBuilder<T, TProp> propertyEditConfig = new PropertyConfigurationBuilder<T, TProp>();

            propertyEditConfig.ForMember(expression);

            propertyEditConfig.Ignore();

            var build = propertyEditConfig.Build();

            EditOn(x => x.Properties, build);
            return this;
        }
    }
}
