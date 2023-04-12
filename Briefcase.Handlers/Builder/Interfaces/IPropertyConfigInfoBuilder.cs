using System;

namespace Briefcase.Handlers.Builder.Interfaces
{
    public interface IPropertyConfigInfoBuilder<T, TProp>
        : IPropertyConfigBuilder<T, TProp>
    {
        IPropertyConfigBuilder<T, TProp> FormatAfterChanged(Func<TProp, TProp> prop);
        bool Ignore();
    }
}