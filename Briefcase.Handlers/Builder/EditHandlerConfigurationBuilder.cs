using Case.Handlers.Builder.Interfaces;
using Case.Handlers.Configurations;
using Case.Handlers.Customizes.Interfaces;
using Case.System.Builders;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Case.Handlers.Builder
{
    public class EditHandlerConfigurationBuilder : BuilderOf<EditHandlerConfiguration>
    {
        public EditHandlerConfigurationBuilder SetMapper(MapperConfiguration mapper)
        {
            EditOn(x => x.EditMappers, mapper);
            return this;
        }
    }

    public class EditHandlerConfigurationBuilder<T>
        : EditHandlerConfigurationBuilder, 
        IEditHandlerConfigurationBuilder<T> where T : class, new()
    {
        public new EditHandlerConfiguration<T> Value => new EditHandlerConfiguration<T>(base.Value);
        public IEditHandlerConfigurationBuilder<T> ForProperty<TProp>(Expression<Func<T, TProp>> expression, Func<IPropertyConfigInfoBuilder<T, TProp>, bool> configurationMethod)
        {
            PropertyConfigBuilder<T, TProp> propertyEditConfig = new PropertyConfigBuilder<T, TProp>();

            propertyEditConfig.ForMember(expression);

            configurationMethod(propertyEditConfig);

            var build = propertyEditConfig.Build();

            EditOn(x => x.Properties, build);

            return this;
        }

        public IEditHandlerConfigurationBuilder<T> SetMapper<TMapper>(IEditHandlerMapperConfigurarion<T, TMapper> editHandlerMapperConfig)
        {
            if (typeof(T) != Value.Type)
                throw new Exception("Classe mapeada esta incoerente");

            var config = new MapperConfigurationBuilder<T, TMapper>();
            editHandlerMapperConfig.ConfigureMapper(config);
            var build = config.Build();
            SetMapper(build);
            return this;
        }
        public IEditHandlerConfigurationBuilder<T> CreateMapper<TMapper>(Action<IMapperConfigurationBuilder<T, TMapper>> configureMapper)
        {
            var mapperBuilder = new MapperConfigurationBuilder<T, TMapper>();
            configureMapper(mapperBuilder);

            var build = mapperBuilder.Build();
            SetMapper(build);
            return this;
        }
        protected override void OnInstanciate(EditHandlerConfiguration Value)
        {
            EditOn(x => x.Type, typeof(T));
        }
    }
}
