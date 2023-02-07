using Case.Handlers.Operations.Base.Interfaces;
using System;
using System.Linq.Expressions;

namespace Case.Handlers.Interfaces
{
    public interface IEditHandlerOperation<T> : IEditResultTimeLiner<T>
    {
        IEditHandlerOperation<T> Edit<TProp>(Expression<Func<T, TProp>> prop, TProp value);
        IEditHandlerOperation<T> Edit(string prop, object value);
        IEditHandlerOperation<T> EditBy(Type type, object request);
        IEditHandlerOperation<T> Edit(Action<T> request);
        IEditHandlerOperation<T> EditBy<TRequest>(TRequest request);
    }
}
