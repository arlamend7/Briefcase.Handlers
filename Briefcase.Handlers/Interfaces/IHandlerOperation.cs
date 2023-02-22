using Briefcase.Handlers.Operations.Base.Interfaces;
using System;
using System.Linq.Expressions;

namespace Briefcase.Handlers.Interfaces
{
    public interface IHandlerOperation<T> : IHandlerResultTimeLiner<T>
        where T : class, new()
    {
        IHandlerOperation<T> Edit<TProp>(Expression<Func<T, TProp>> prop, TProp value);
        IHandlerOperation<T> Edit(string prop, object value);
        IHandlerOperation<T> Edit(Action<T> request);
        IHandlerOperation<T> EditBy(Type type, object request);
        IHandlerOperation<T> EditBy<TRequest>(TRequest request);
        IHandler<T> Reset()
        {
            this.Dispose();
            return (IHandler<T>)this;
        }
    }
}
