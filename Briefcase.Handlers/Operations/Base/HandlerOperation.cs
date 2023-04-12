using Briefcase.Handlers.Configurations;
using Briefcase.Handlers.Handleds.Creators;
using Briefcase.Handlers.Handleds.Creators.Interfaces;
using Briefcase.Handlers.Handleds.Enums;
using Briefcase.Handlers.Handleds.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Briefcase.Handlers.Operations.Base
{
    internal abstract class HandlerOperationBase<T> : HandlerResultTimeLiner<T>
                where T : class, new()

    {
        protected readonly HandlerConfiguration _handlerConfiguration;
        public HandlerOperationBase(HandlerConfiguration editHandler, T entity) : base(entity)
        {
            _handlerConfiguration = editHandler;
        }

        protected bool IgnoredProperty(PropertyInfo property)
        {
            return GetConfiguration(property)?.Ignore == true;
        }

        protected PropertyConfiguration GetConfiguration(PropertyInfo property)
        {
            return _handlerConfiguration.Properties?.FirstOrDefault(X => X.PropertyInfo.Name == property.Name);
        }

        protected void TryEdit(PropertyMapperConfiguration propertyMapper, IHandledCreator creator, object mapperValue)
        {
            string message = null;
            PropertyInfo property = propertyMapper.Property;

            Add(property, () =>
            {
                bool HasErrorOnConvert = propertyMapper.Converters.Any(x => !x.Invoke(mapperValue, out mapperValue, out message));

                if (HasErrorOnConvert)
                    return creator.StopedOnMapper(mapperValue, HandledStopStageEnum.Convert, message);


                return TryEdit(property, creator, mapperValue);
            });
        }

        protected void TryEdit(PropertyInfo property, object value)
        {
            var creator = HandledCreator.Instanciate(property, value);
            Add(property, () => TryEdit(property, creator, value));
        }

        private IHandled TryEdit(PropertyInfo property, IHandledCreator creator, object value)
        {
            var propertyConfig = GetConfiguration(property);
            var lastValue = property.GetValue(Entity);

            string message = null;

            if (propertyConfig?.IgnoreConditions.Any(ignoreCondition => ignoreCondition(Entity, value)) ?? false)
                return creator.StopedOn(value, HandledStopStageEnum.IgnoreAfterSet, message);

            if (IsEqual(value, lastValue))
                return creator.StopedOn(value, HandledStopStageEnum.IgnoreAfterSet, $"The new and last is equal, {value}");

            if (IsInvalid(property, value))
                return creator.StopedOn(value, HandledStopStageEnum.IgnoreAfterSet, $"The is invalid for {property.PropertyType}");

            if (propertyConfig?.ErrorsValidations.Any(x => x.Invoke(Entity, value, out message)) ?? false)
                return creator.StopedOn(value, HandledStopStageEnum.Validations, message);

            if (propertyConfig?.Formatter != null && !Try(() => value = propertyConfig.Formatter.Invoke(value), out message))
                return creator.StopedOn(value, HandledStopStageEnum.Format, message);

            if (!Try(() => property.SetValue(Entity, value), out message))
                return creator.StopedOn(value, HandledStopStageEnum.SetValue, message);

            propertyStartValues.Add(property, lastValue);

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