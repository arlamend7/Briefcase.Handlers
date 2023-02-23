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
        IInteractable<IHandled> For(PropertyInfo property);
        IInteractable<IHandled> For(string property);
        IInteractable<IHandled> For<TProp>(Expression<Func<T, TProp>> expression);
    }
}