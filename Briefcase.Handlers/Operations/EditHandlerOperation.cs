using Case.Handlers.Configurations;
using Case.Handlers.Handleds.Creators;
using Case.Handlers.Handleds.Enums;
using Case.Handlers.Interfaces;
using Case.Handlers.Operations.Base;
using Case.System.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Case.Handlers.Operations
{
    public class EditHandlerOperation<T> 
        : EditOperation<T>,
        IEditHandlerOperation<T>
        where T : new()
    {
        public EditHandlerOperation(EditHandlerConfiguration editHandler, T entity) : base(editHandler, entity)
        {
        }

        public IEditHandlerOperation<T> Edit<TProp>(Expression<Func<T, TProp>> prop, TProp value)
        {
            return Edit(prop.GetMemberName(), value);
        }
        public IEditHandlerOperation<T> Edit(Action<T> requestFunc)
        {
            T request = new T();
            requestFunc(request);
            return EditBy(request);
        }
        public IEditHandlerOperation<T> Edit(string prop, object value)
        {
            var property = typeof(T).GetProperty(prop);

            if (IgnoredProperty(property))
                return this;

            TryEdit(property, value);

            return this;
        }

        public IEditHandlerOperation<T> EditBy<TRequest>(TRequest request)
        {
            return EditBy(typeof(TRequest), request);
        }

        public IEditHandlerOperation<T> EditBy(Type type, object request)
        {
            var mapper = _editHandler.EditMappers.FirstOrDefault(x => x.InteractioType == type);

            if (mapper == null)
            {
                throw new Exception($"Não foi encontrado nenhum mapeamento para {type}");
            }
            return EditByMapper(mapper, request);
        }

        private IEditHandlerOperation<T> EditByMapper(MapperConfiguration mapper, object request)
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
                }

                TryEdit(propertyMapper, creator, mapperValue);
            }
            return this;
        }
    }
}
