using Briefcase.Handlers.Interfaces;

namespace Briefcase.Handlers.Base
{
    public abstract class HandlerResolverBase : IHandler
    {
        public IHandlerOperation<T> Create<T>() where T : class, new()
        {
            return GetHandler<T>().Create();
        }

        public IHandlerOperation<T> Delete<T>(T entity) where T : class, new()
        {
            return GetHandler<T>().Delete(entity);
        }

        public IHandlerOperation<T> Edit<T>(T entity) where T : class, new()
        {
            return GetHandler<T>().Edit(entity);
        }
        public IHandler<T> Get<T>() where T : class, new()
        {
            return GetHandler<T>();
        }
        public bool HasConfiguration<T>() where T : class, new()
        {
            return ResolveHandler<T>() != null;
        }

        public abstract IHandler<T> ResolveHandler<T>() where T : class, new(); 
        protected IHandler<T> GetHandler<T>()
            where T : class, new()
        {
            var handler = ResolveHandler<T>();

            if (handler is null)
                handler = IHandler<T>.CreateDefault();

            return handler;
        }
    }
}
