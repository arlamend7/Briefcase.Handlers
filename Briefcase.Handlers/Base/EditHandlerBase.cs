using Case.Handlers.Builder;
using Case.Handlers.Configurations;
using Case.Handlers.Interfaces;
using Case.Handlers.Operations;

namespace Case.Handlers.Base
{
    public abstract class EditHandlerBase
    {
        protected IEditHandlerOperation<T> CreateOperation<T>(EditHandlerConfiguration handler, T entity = null)
            where T : class, new()
        {
            entity ??= new T();
            handler ??= new EditHandlerConfigurationBuilder<T>().Value;
            return new EditHandlerOperation<T>(handler, entity);
        }
    }
}