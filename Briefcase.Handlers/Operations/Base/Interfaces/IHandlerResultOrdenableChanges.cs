using Briefcase.Handlers.Handleds.Interfaces;
using Briefcase.System.Reflections.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Briefcase.Handlers.Operations.Base.Interfaces
{
    public interface IHandlerResultOrdenableChanges<T> :
        IHandlerResultChanges<T>, IEnumerable<IHandled>
    {
        IEnumerable<PropertyInfo> Order { get; }
        IEnumerable<IHandled> Values { get; }
        IEnumerable<IHandledChange> Changes { get; }
        int ExecutedLength { get; }
        int NotExecutedLength { get; }
        int ManuallyValuesAdded { get; }
        void OrderBy(Action<IPropertyGetter<T>> getterFunc);
        void OrderBy(params PropertyInfo[] properties);
        void OrderBy(params string[] properties);
        void OrderBy<TProp>(Func<PropertyInfo, TProp> properties);
    }
}