using Briefcase.Handlers.Handleds.Interfaces;
using Briefcase.System.Reflections.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Briefcase.Handlers.Operations.Base.Interfaces
{
    public interface IHandlerResultTimeLiner<T> : IHandlerResultOrdenableChanges<T>
    {
        T Result { get; }
        T GetResultFor(Action<IPropertyGetter<T>> getterFunc);
        T GetResultFor(IEnumerable<IHandledChange> changes);
        T GetResultFor(params PropertyInfo[] properties);
        T GetResultFor(params string[] properties);
    }
}