using Case.Handlers.Handleds.Interfaces;
using Case.System.Reflections.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Case.Handlers.Operations.Base.Interfaces
{
    public interface IEditResultTimeLiner<T> : IEditResultOrdenableChanges<T>
    {
        T ResultEntity { get; }
        T GetResultEntity(Action<IPropertyGetter<T>> getterFunc);
        T GetResultEntityFor(IEnumerable<IHandledChange> changes);
        T GetResultEntityFor(params PropertyInfo[] properties);
        T GetResultEntityFor(params string[] properties);
    }
}