using Briefcase.Handlers.Base;
using Briefcase.Handlers.Configurations;
using Briefcase.Handlers.Interfaces;
using Briefcase.Handlers.Operations;

namespace Briefcase.Handlers
{
    internal class Handler<T> 
        : HandlerOperation<T>,
       IHandler<T>
       where T : class, new()
    {
        private readonly HandlerConfiguration _configuration;
        public Handler(HandlerConfiguration configuration) : base(configuration, null)
        {
            _configuration = configuration;
        }
        public IHandlerOperation<T> Create()
        {
            T entity = new T();
            _configuration.OnCreate?.Invoke(entity);
            Entity = entity;
            return this; 
        }

        public IHandlerOperation<T> Delete(T entity)
        {
            _configuration.OnDelete?.Invoke(entity);
            Entity = entity;
            return this;
        }

        public IHandlerOperation<T> Edit(T entity)
        {
            _configuration.OnEdit?.Invoke(entity);
            Entity = entity;
            return this;
        }
    }
}
