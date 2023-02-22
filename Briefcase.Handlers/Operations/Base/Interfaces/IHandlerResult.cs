using Briefcase.Handlers.Handleds.Interfaces;
using Briefcase.System.Asyncronuos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Briefcase.Handlers.Operations.Base.Interfaces
{
    public interface IHandlerResult<T> : IDisposable
    {
        IEnumerable<PropertyInfo> EditedProperties { get; }
        IResultAsync<IHandled> For(PropertyInfo property);
        IResultAsync<IHandled> For(string property);
        IResultAsync<IHandled> For<TProp>(Expression<Func<T, TProp>> expression);
    }
}