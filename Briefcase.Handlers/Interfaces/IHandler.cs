using Briefcase.Handlers.Builder;
using Briefcase.Handlers.Builder.Interfaces;
using Briefcase.Handlers.Configurations;
using System;
using System.Collections.Generic;

namespace Briefcase.Handlers.Interfaces
{
    public interface IHandlerCollection : IHandler
    {
        void Add(HandlerConfiguration handlerConfiguration);
        void AddRange(IEnumerable<HandlerConfiguration> handlerConfiguration);
        static IHandlerCollection Instanciate()
        {
            return new HandlerCollection();
        }
    }
    public interface IHandler
    {
        IHandlerOperation<T> Create<T>() where T : class, new();
        IHandlerOperation<T> Edit<T>(T entity) where T : class, new();
        IHandlerOperation<T> Delete<T>(T entity) where T : class, new();
        IHandler<T> Get<T>() where T : class, new();
        bool HasConfiguration<T>() where T : class, new();
    }
    public interface IHandler<T>
        where T : class, new()
    {
        /// <summary>
        ///  Este metodo foi feito para criar novos objetos
        /// </summary>
        /// <returns></returns>
        IHandlerOperation<T> Create();
        IHandlerOperation<T> Edit(T entity);
        IHandlerOperation<T> Delete(T entity);

        static IHandler<T> CreateUsing(HandlerConfiguration handlerConfiguration)
        {
            return new Handler<T>(handlerConfiguration);
        }

        static IHandler<T> CreateDefault()
        {
            var builder = new EditHandlerConfigurationBuilder<T>()
                .CreateMapper<T>(x => x.IgnoreAllDefaultValues());
            return CreateUsing(builder.Build());
        }

        static IHandler<T> CreateUsing(Action<IHandlerConfigurationBuilder<T>> configurationBuilder)
        {
            var builder = new EditHandlerConfigurationBuilder<T>();
            configurationBuilder(builder);
            return CreateUsing(builder.Build());
        }
    }
}