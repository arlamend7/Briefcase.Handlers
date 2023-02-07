using Case.Handlers.Configurations;
using Case.Handlers.Handleds.Creators.Interfaces;
using Case.Handlers.Handleds.Enums;
using Case.Handlers.Handleds.Interfaces;
using System;
using System.Reflection;

namespace Case.Handlers.Handleds.Creators
{
    public class HandledCreator : IHandledCreator
    {
        private Type MappedType { get; }
        private PropertyInfo MappedProperty { get; }
        private PropertyInfo Property { get; }
        private object Value { get; }
        private HandledCreator(PropertyInfo property, object value)
        {
            Property = property;
            Value = value;
        }
        private HandledCreator(PropertyMapperConfiguration mapper, object value)
        {
            MappedType = mapper.MappedType;
            MappedProperty = mapper.MappedProperty;
            Property = mapper.Property;
            Value = value;
        }

        public static IHandledCreator Instanciate(PropertyInfo property, object value)
        {
            return new HandledCreator(property, value);
        }
        public static IHandledCreator Instanciate(PropertyMapperConfiguration property, object value)
        {
            return new HandledCreator(property, value);
        }


        public IHandled StopedOn(object value, HandledStopStageEnum stopedEnum, string message)
        {
            return CreateAndDispose(() =>
            {
                if (message is null)
                    return new HandledDetail(Property, value, stopedEnum, Value);
                if(MappedType is null)
                    return new HandledMessagedDetail(Property, Value, stopedEnum, value ,message);
                return new MapperHandledMessagedDetail(MappedType, MappedProperty, Value, Property, value, stopedEnum, message);
            });
        }

        public IHandled StopedOnMapper(object value, HandledStopStageEnum stopedEnum, string message)
        {
            return CreateAndDispose(() =>
            {
                return new MapperHandledMessagedDetail(MappedType, MappedProperty, Value, Property, value, stopedEnum, message);
            });
        }

        public IHandled Successfully(object value, object lastValue)
        {
            return CreateAndDispose(() =>
            {
                if (MappedType is null)
                    return new HandledChangeDetail(Property, value,  Value, lastValue);
                return new MapperHandledChangeDetail(MappedType, MappedProperty, Value, Property, value, lastValue);
            });
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IHandled CreateAndDispose(Func<IHandled> create)
        {
            var handled = create();
            Dispose();
            return handled;
        }
    }
}
