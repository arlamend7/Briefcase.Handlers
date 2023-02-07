using Case.Handlers.Configurations;
using System;

namespace Case.Handlers.Builder.Interfaces
{
    public interface IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp>
        : IPropertyMapperConvertBuilderConverted<TRequestProp, TRequestProp, TProp>
    {
        public bool UseSameValue => true;
        IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp> IgnoreIf(Func<TRequestProp, bool> ignoreCondition, string message = null);
        IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp> IgnoreIf(Func<TRequestProp, bool> ignoreCondition, Func<TRequestProp, string> messageFunc);
        IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp> IgnoreDefaultValue(string message = null);
    }
}