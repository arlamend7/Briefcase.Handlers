using Case.Handlers.Handleds.Interfaces;
using Case.System.Asyncronuos.Interfaces;
using Case.System.Reflections.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Case.Handlers.Operations.Base.Interfaces
{
    public interface IEditResultOrdenableChanges<T> :
        IResultAsync<IHandled>,
        IEditResultChanges<T>
    {
        IEnumerable<PropertyInfo> ExecutionOrder { get; }
        IEnumerable<IHandled> Values { get; }
        IEnumerable<IHandledChange> Changes { get; }
        void OrderBy(Action<IPropertyGetter<T>> getterFunc);
        void OrderBy(params PropertyInfo[] properties);
    }
}