using Briefcase.Handlers.Handleds.Interfaces;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Briefcase.Handlers.Operations.Base.Interfaces
{
    public interface IHandlerResultChanges<T> : IHandlerResult<T>
    {
        IHandledChange GetChangeFor(PropertyInfo property);
        IHandledChange GetChangeFor<TProp>(Expression<Func<T, TProp>> expression);
        IHandledChange GetChangeFor(string property);
    }
}