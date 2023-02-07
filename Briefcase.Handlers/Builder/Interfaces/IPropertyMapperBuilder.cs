using Case.Handlers.Configurations;
using System;
using System.Linq.Expressions;

namespace Case.Handlers.Builder.Interfaces
{
    public interface IPropertyMapperBuilder<TProp>
    {
        IPropertyMapperBuilder<TProp> IgnoreValue(TProp ignoredValue, string message = null);
        IPropertyMapperBuilder<TProp> IgnoreDefaultValue(string message = null);
    }
    public interface IPropertyMapperBuilder<T, TRequest, TProp>
        : IPropertyMapperBuilder<TProp>
    {
        bool Ignore();
        IPropertyMapperConvertBuilder<T, TProp, TRequest, TProp> MapFrom(Expression<Func<TRequest, TProp>> getValue);
        IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp> MapFrom<TRequestProp>(Expression<Func<TRequest, TRequestProp>> getValue);
        bool MapExactlyFrom(Expression<Func<TRequest, TProp>> getValue);
    }
}