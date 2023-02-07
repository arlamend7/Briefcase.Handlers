using Case.Handlers.Configurations;
using Case.System.Builders.Interfaces;
using System;
using System.Reflection;

namespace Case.Handlers.Builder
{
    internal interface IPropertyMapperConfigurationBuilder : IBuilderOf<PropertyMapperConfiguration>
    {
        bool Conclude { get; }

        IPropertyMapperConfigurationBuilder IgnoreDefaultValue(bool ignore = false);
        IPropertyMapperConfigurationBuilder SetMappedType(Type type);
        IPropertyMapperConfigurationBuilder SetProperty(PropertyInfo property);
    }
}