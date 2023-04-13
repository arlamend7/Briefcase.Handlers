using Briefcase.Handlers.Configurations;
using Briefcase.System.Builders.Interfaces;
using System;
using System.Reflection;

namespace Briefcase.Handlers.Builder.Interfaces
{
    internal interface IPropertyMapperConfigurationBuilder : IBuilderOf<PropertyMapperConfiguration>
    {
        bool Conclude { get; }

        IPropertyMapperConfigurationBuilder IgnoreDefaultValue(bool ignore = false);
        IPropertyMapperConfigurationBuilder SetMappedType(Type type);
        IPropertyMapperConfigurationBuilder SetProperty(PropertyInfo property);
        IPropertyMapperConfigurationBuilder SetMappedProperty(PropertyInfo property);
    }
}