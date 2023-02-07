using Case.Handlers.Handleds.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Case.Handlers.Operations.Base.Interfaces
{
    public interface IEditResultChanges<T>
    {
        IEnumerable<PropertyInfo> EditedProperties { get; }

        IEnumerable<IHandled> ForProperty(PropertyInfo property);
        IEnumerable<IHandled> ForProperty<TProp>(Expression<Func<T, TProp>> expression);
        IHandledChange GetChangeFor(PropertyInfo property);
    }
}