using Case.System.Delegates;
using System;

namespace Case.Handlers.Builder.Interfaces
{
    public interface IPropertyMapperConvertBuilderConverted<T, TRequest, TRequestProp, TProp>
    {
        bool ConvertUsing(Func<TRequest, TProp> converter, string message = null);
        bool ConvertUsing(Func<TRequest, TProp> converter, Func<TRequest, string> message);
        IPropertyMapperConvertBuilderConverted<T, TAnotherType, TAnotherType, TProp> ConvertUsing<TAnotherType>(Func<TRequest, TAnotherType> converter, Func<TRequest, string> message);
        IPropertyMapperConvertBuilderConverted<T, TAnotherType, TAnotherType, TProp> ConvertUsing<TAnotherType>(Func<TRequest, TAnotherType> converter, string message = null);
        IPropertyMapperConvertBuilderConverted<T, TAnotherType, TAnotherType, TProp> ConvertUsing<TAnotherType>(TryConvert<TRequest, TAnotherType> converter, Func<TRequest, string> message);
        IPropertyMapperConvertBuilderConverted<T, TAnotherType, TAnotherType, TProp> ConvertUsing<TAnotherType>(TryConvert<TRequest, TAnotherType> converter, string message);
    }
}