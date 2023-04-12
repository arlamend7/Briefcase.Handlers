using System;

namespace Briefcase.Handlers.Builder.Interfaces
{
    public interface IPropertyConfigBuilder<T, TProp>
    {
        bool Conclude => true;
        IPropertyConfigBuilder<T, TProp> ThrowErrorIf(Func<T, TProp, bool> action, Func<TProp, string> errorMessageFunc = null);
        IPropertyConfigBuilder<T, TProp> ThrowErrorIf(Func<T, TProp, bool> action, string errorMessage = null);
        IPropertyConfigBuilder<T, TProp> ThrowErrorIfValue(Func<TProp, bool> action, Func<TProp, string> errorMessageFunc = null);
        IPropertyConfigBuilder<T, TProp> ThrowErrorIfValue(Func<TProp, bool> action, string errorMessage = null);
        IPropertyConfigBuilder<T, TProp> ThrowErrorIfValueIs(TProp value, string errorMessage = null);
        IPropertyConfigBuilder<T, TProp> IgnoreIfValueIs(TProp ignore);
        IPropertyConfigBuilder<T, TProp> IgnoreIf(Func<TProp, bool> ignore);
        IPropertyConfigBuilder<T, TProp> IgnoreIf(Func<T, TProp, bool> ignore);
    }
}