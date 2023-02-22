using Briefcase.Handlers.Configurations;
using Briefcase.Handlers.Handleds.Creators;
using Briefcase.Handlers.Handleds.Enums;
using Briefcase.Handlers.Interfaces;
using Briefcase.Handlers.Operations.Base;
using Briefcase.System.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Briefcase.Handlers.Operations
{
    internal class HandlerOperation<T>
        : HandlerOperationBase<T>,
        IHandlerOperation<T>
        where T : class, new()
    {
        public HandlerOperation(HandlerConfiguration editHandler, T entity) : base(editHandler, entity)
        {
        }

        public IHandlerOperation<T> Edit<TProp>(Expression<Func<T, TProp>> prop, TProp value)
        {
            return Edit(prop.GetMemberName(), value);
        }

        public IHandlerOperation<T> Edit(Action<T> requestFunc)
        {
            T request = new T();
            requestFunc(request);
            return EditBy(request);
        }

        public IHandlerOperation<T> Edit(string prop, object value)
        {
            var property = typeof(T).GetProperty(prop);

            if (IgnoredProperty(property))
                return this;

            TryEdit(property, value);

            return this;
        }

        public IHandlerOperation<T> EditBy<TRequest>(TRequest request)
        {
            return EditBy(typeof(TRequest), request);
        }

        public IHandlerOperation<T> EditBy(Type type, object request)
        {
            var mapper = _handlerConfiguration.EditMappers.FirstOrDefault(x => x.InteractioType == type);

            if (mapper == null)
            {
                throw new Exception($"Não foi encontrado nenhum mapeamento para {type}");
            }
            return EditByMapper(mapper, request);
        }

        private IHandlerOperation<T> EditByMapper(MapperConfiguration mapper, object request)
        {
            foreach (PropertyMapperConfiguration propertyMapper in mapper.Properties)
            {
                if (propertyMapper.Ignored)
                    continue;

                if (IgnoredProperty(propertyMapper.Property))
                    continue;

                object mapperValue = propertyMapper.MappedProperty.GetValue(request);

                var creator = HandledCreator.Instanciate(propertyMapper, mapperValue);

                string message = null;

                if (propertyMapper.IgnoreConditions.Any(x => x.Invoke(mapperValue, out message)))
                {
                    Add(propertyMapper.Property, creator.StopedOnMapper(mapperValue, HandledStopStageEnum.IgnoreOnMapping, message));
                    continue;
                }

                TryEdit(propertyMapper, creator, mapperValue);
            }
            return this;
        }
    }
}
