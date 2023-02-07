using Case.System.Delegates;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Case.Handlers.Configurations
{
    public class PropertyMapperConfiguration
    {
        public Type MappedType { get; protected set; }
        public PropertyInfo MappedProperty { get; protected set; }
        public PropertyInfo Property { get; protected set; }
        public bool Ignored { get; protected set; }
        public IEnumerable<IgnoreifMessage> IgnoreConditions { get; protected set; }
        public IEnumerable<TryConvertMessage> Converters { get; protected set; }
        public PropertyMapperConfiguration()
        {
            Ignored = false;
            IgnoreConditions = new IgnoreifMessage[0];
            Converters = new TryConvertMessage[0];
        }

        public IgnoreifMessage IgnoreDefaultValueFunc => (object x, out string message) =>
        {
            message = "default value";
            if (x == default)
                return true;
            return (bool)Property.PropertyType.GetMethod("Equals", new Type[1] { Property.PropertyType }).Invoke(x, new object[1] { default });
        };

        public IgnoreifMessage IgnoreDefaultValueFuncMessage<T>(Func<T, string> errorMessage)
        {
            return (object x, out string message) =>
            {
                message = errorMessage((T)x);
                if (x == default)
                    return true;
                return (bool)MappedProperty.PropertyType.GetMethod("Equals", new Type[1] { Property.PropertyType }).Invoke(x, new object[1] { default });
            };
        }

        public delegate bool TryConvertMessage(object obj, out object result, out string errorMessage);
        public delegate bool IgnoreifMessage(object obj, out string errorMessage);

        public static TryConvertMessage ConvertToConvert<T, TType>(Func<T, TType> action, Func<T, string> errorMessageFunc)
        {
            return (object lastValue, out object newValue, out string errorMessage) =>
                {
                    newValue = lastValue;
                    errorMessage = errorMessageFunc((T)lastValue);
                    try
                    {
                        newValue = action((T)lastValue);
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                };
        }

        public static TryConvertMessage ConvertToConvert<T, TType>(TryConvert<T, TType> action, Func<T, string> errorMessageFunc)
        {
            return (object lastValue, out object newValue, out string errorMessage) =>
            {
                newValue = null;
                errorMessage = null;

                if (action((T)lastValue, out TType result))
                    newValue = result;
                else
                {
                    errorMessage = errorMessageFunc((T)lastValue);
                }

                return errorMessage == null;
            };
        }
        public static IgnoreifMessage ConvertToIgnore<T>(Func<T, bool> action, Func<T, string> errorMessageFunc)
        {
            return (object value, out string errorMessage) =>
            {
                errorMessage = null;
                var ignore = action((T)value);
                if (ignore)
                    errorMessage = errorMessageFunc((T)value);
                return ignore;
            };
        }
    }
}
