using System;
using System.Linq.Expressions;

namespace Briefcase.Handlers.Builder.Interfaces
{
    public interface IPropertyConfigNoPropertyBuilder<T, TProp>
    {
        IPropertyConfigInfoBuilder<T, TProp> ForMember(Expression<Func<T, TProp>> expression, string description = null);
        bool Ignore();
    }
}