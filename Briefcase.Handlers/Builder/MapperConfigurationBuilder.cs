using Briefcase.Handlers.Builder.Interfaces;
using Briefcase.Handlers.Configurations;
using Briefcase.System.Builders;
using Briefcase.System.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Briefcase.Handlers.Builder
{
    internal class MapperConfigurationBuilder
               : BuilderOf<MapperConfiguration>, IMapperConfigurationBuilder
    {
        private bool _ignoreDefaultValues = false;

        public IMapperConfigurationBuilder SetTypes(Type type, Type interactionType)
        {
            EditOn(x => x.Type, type);
            EditOn(x => x.InteractioType, interactionType);
            return this;
        }
        public IMapperConfigurationBuilder IgnoreAllDefaultValues()
        {
            _ignoreDefaultValues = true;
            return this;
        }

        protected IEnumerable<PropertyMapperConfiguration> EqualsPropertiesNotConfigurated()
        {
            foreach (PropertyInfo requestProperty in Value.InteractioType.GetProperties())
            {
                PropertyInfo propertyInfo = Value.Type.GetProperty(requestProperty.Name);

                if (propertyInfo == null)
                    continue;

                var propertyMapper = Value.Properties?.FirstOrDefault(x => x.Property.Name == requestProperty.Name &&
                                                                                   x.Property.PropertyType == requestProperty.PropertyType);
                if (propertyMapper != null)
                    continue;
                else
                    yield return new PropertyMapperConfigurationBuilder()
                                                .SetProperty(requestProperty)
                                                .IgnoreDefaultValue(_ignoreDefaultValues)
                                                .Build();

            }
        }
    }

    internal class MapperConfigurationBuilder<T, TRequest>
        : MapperConfigurationBuilder,
        IMapperConfigurationBuilder<T, TRequest>
    {
        public IMapperConfigurationBuilder<T, TRequest> For<TProp>(Expression<Func<T, TProp>> expression, Func<IPropertyMapperBuilder<T, TRequest, TProp>, bool> configurationMethod)
        {
            var propertyName = expression.GetMemberName();
            if (Value.Properties?.Any(y => y.Property.Name == propertyName) ?? false)
                throw new Exception("Propriedade ja configurada");

            var propertyMapperConfig = new PropertyMapperBuilder<T, TRequest, TProp>();

            propertyMapperConfig.SetProperty(expression);

            configurationMethod(propertyMapperConfig);
            EditOn(x => x.Properties, propertyMapperConfig.Build());
            return this;
        }

        protected override void OnBuild(MapperConfiguration Value)
        {
            foreach (var propertyMapper in EqualsPropertiesNotConfigurated())
            {
                EditOn(x => x.Properties, propertyMapper);
            }
        }
        protected override void OnInstanciate(MapperConfiguration Value)
        {
            SetTypes(typeof(T), typeof(TRequest));
        }

        public new MapperConfigurationBuilder<T, TRequest> IgnoreAllDefaultValues()
        {
            base.IgnoreAllDefaultValues();
            return this;
        }

        IMapperConfigurationBuilder<T, TRequest> IMapperConfigurationBuilder<T, TRequest>.IgnoreAllDefaultValues()
        {
            base.IgnoreAllDefaultValues();
            return this;
        }
    }
}
