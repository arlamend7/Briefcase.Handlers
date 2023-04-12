using Briefcase.System.Delegates;
using System;

namespace Briefcase.Handlers.Builder.Interfaces
{
    public interface IPropertyMapperConvertBuilderConverted<TRequest, TRequestProp, TProp>
    {
        bool ConvertUsing(Func<TRequest, TProp> converter, string message = null);
        bool ConvertUsing(Func<TRequest, TProp> converter, Func<TRequest, string> message);
        IPropertyMapperConvertBuilderConverted<TAnotherType, TAnotherType, TProp> ConvertUsing<TAnotherType>(Func<TRequest, TAnotherType> converter, Func<TRequest, string> message);
        IPropertyMapperConvertBuilderConverted<TAnotherType, TAnotherType, TProp> ConvertUsing<TAnotherType>(Func<TRequest, TAnotherType> converter, string message = null);
        IPropertyMapperConvertBuilderConverted<TAnotherType, TAnotherType, TProp> ConvertUsing<TAnotherType>(TryConvert<TRequest, TAnotherType> converter, Func<TRequest, string> message);
        IPropertyMapperConvertBuilderConverted<TAnotherType, TAnotherType, TProp> ConvertUsing<TAnotherType>(TryConvert<TRequest, TAnotherType> converter, string message);
    }
}