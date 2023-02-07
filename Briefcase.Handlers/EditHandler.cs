using Case.Handlers.Base;
using Case.Handlers.Builder;
using Case.Handlers.Builder.Interfaces;
using Case.Handlers.Configurations;
using Case.Handlers.Interfaces;
using System;

namespace Case.Handlers
{
    public class EditHandler<T> :
        EditHandlerBase,
       IEditHandler<T>
       where T : class, new()
    {

        private readonly EditHandlerConfiguration _configuration;
        public EditHandler(EditHandlerConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IEditHandlerOperation<T> Create()
        {
            return CreateOperation<T>(_configuration);
        }

        public IEditHandlerOperation<T> Delete(T entity)
        {
            return CreateOperation(_configuration, entity);
        }

        public IEditHandlerOperation<T> Edit(T entity)
        {
            return CreateOperation(_configuration, entity);
        }

        public static IEditHandler<T> CreateUsing(Action<IEditHandlerConfigurationBuilder<T>> configurationBuilder)
        {
            var builder = new EditHandlerConfigurationBuilder<T>();
            configurationBuilder(builder);
            return new EditHandler<T>(builder.Build());
        }
    }
}
