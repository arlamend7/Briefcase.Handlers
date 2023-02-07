using Case.Handlers.Configurations;
using Case.Handlers.Handleds.Creators;
using Case.Handlers.Handleds.Creators.Interfaces;
using Case.Handlers.Handleds.Enums;
using Case.Handlers.Handleds.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Case.Handlers.Operations.Base
{
    public abstract class EditOperation<T> : EditResultTimeLiner<T>
    {
        protected readonly EditHandlerConfiguration _editHandler;
        public EditOperation(EditHandlerConfiguration editHandler, T entity) : base(entity)
        {
            _editHandler = editHandler;
        }

        protected bool IgnoredProperty(PropertyInfo property)
        {
            return GetConfiguration(property)?.Ignore == true;
        }

        protected PropertyConfiguration GetConfiguration(PropertyInfo property)
        {
            return _editHandler.Properties?.FirstOrDefault(X => X.PropertyInfo.Name == property.Name);
        }

        protected void TryEdit(PropertyMapperConfiguration propertyMapper, IHandledCreator creator, object mapperValue)
        {
            string message = null;
            PropertyInfo property = propertyMapper.Property;

            Add(property, () => {

                bool HasErrorOnConvert = propertyMapper.Converters.Any(x => !x.Invoke(mapperValue, out mapperValue, out message));

                if (HasErrorOnConvert)
                    return creator.StopedOnMapper(mapperValue, HandledStopStageEnum.Convert, message);
                

                return TryEdit(property, creator, mapperValue);
            });
        }

        protected void TryEdit(PropertyInfo property, object value)
        {
            var creator = HandledCreator.Instanciate(property, value);
            Add(property, () =>  TryEdit(property, creator, value));
        }

        private IHandled TryEdit(PropertyInfo property, IHandledCreator creator, object value)
        {
            var propertyConfig = GetConfiguration(property);
            var lastValue = property.GetValue(Entity);

            string message = null;

            if (propertyConfig?.IgnoreConditions.Any(ignoreCondition => ignoreCondition(value)) ?? false)
                return creator.StopedOn(value, HandledStopStageEnum.IgnoreAfterSet, message);

            if (IsEqual(value, lastValue))
                return creator.StopedOn(value, HandledStopStageEnum.IgnoreAfterSet, $"The new and last is equal, {value}");

            if (IsInvalid(property, value))
                return creator.StopedOn(value, HandledStopStageEnum.IgnoreAfterSet, $"The is invalid for {property.PropertyType}");

            if (propertyConfig?.ErrorsValidations.Any(x => x.Invoke(Entity, value, out message)) ?? false)
                return creator.StopedOn(value, HandledStopStageEnum.Validations, message);

            if(propertyConfig?.Formatter != null && !Try(() => value = propertyConfig.Formatter.Invoke(value), out message))
                return creator.StopedOn(value, HandledStopStageEnum.Format, message);

            if (!Try(() => property.SetValue(Entity, value), out message))
                return creator.StopedOn(value, HandledStopStageEnum.SetValue, message);

            propertyStartValues.TryAdd(property, lastValue);

            return creator.Successfully(value, lastValue);
        }

        private bool IsEqual(object value, object lastValue)
        {
            if (lastValue == null && value == null)
                return true;

            if (lastValue != null && lastValue.Equals(value))
                return true;

            return false;
        }

        private bool IsInvalid(PropertyInfo propertyInfo, object newValue)
        {
            if (newValue == null && (Nullable.GetUnderlyingType(propertyInfo.PropertyType) == null || propertyInfo.PropertyType.IsClass))
                return true;

            return false;
        }

        private bool Try(Action action, out string message)
        {
            message = null;
            try
            {
                action();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
            return true;
        }
    }
}