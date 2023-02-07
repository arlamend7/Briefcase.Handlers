using Case.Handlers.Base;
using Case.Handlers.Builder;
using Case.Handlers.Configurations;
using Case.Handlers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Case.Handlers
{
    public class EditHandlerCollection
        : EditHandlerBase,
        IEditHandler
    {
        private readonly IEnumerable<EditHandlerConfiguration> _handlers;

        public EditHandlerCollection(IEnumerable<EditHandlerConfiguration> editHandler)
        {
            _handlers = editHandler;
        }

        public IEditHandlerOperation<T> Create<T>() where T : class, new()
        {
            return CreateOperation<T>();
        }

        public IEditHandlerOperation<T> Delete<T>(T entity) where T : class, new()
        {
            return CreateOperation(entity);
        }

        public IEditHandlerOperation<T> Edit<T>(T entity) where T : class, new()
        {
            return CreateOperation(entity);
        }

        private IEditHandlerOperation<T> CreateOperation<T>(T entity = null)
          where T : class, new()
        {
            entity ??= new T();
            return CreateOperation(_handlers?.FirstOrDefault(x => x.Type == typeof(T)), entity);
        }
    }
}
