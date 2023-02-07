using System;

namespace Case.Handlers.Interfaces
{
    public interface IEditHandler
    {
        IEditHandlerOperation<T> Create<T>() where T : class, new();
        IEditHandlerOperation<T> Edit<T>(T entity) where T : class, new();
        IEditHandlerOperation<T> Delete<T>(T entity) where T : class, new();
    }
    public interface IEditHandler<T>
        where T : new()
    {
        IEditHandlerOperation<T> Create();
        IEditHandlerOperation<T> Edit(T entity);
        IEditHandlerOperation<T> Delete(T entity);
    }
}