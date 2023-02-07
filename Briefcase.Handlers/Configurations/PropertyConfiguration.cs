using System;
using System.Collections.Generic;
using System.Reflection;

namespace Case.Handlers.Configurations
{
    public class PropertyConfiguration
    {
        public PropertyInfo PropertyInfo { get; protected set; }
        public IEnumerable<ThrowErrorIf> ErrorsValidations { get; protected set; }
        public IEnumerable<Func<object, bool>> IgnoreConditions { get; protected set; }
        public Func<object, object> Formatter { get; protected set; }
        public string Description { get; protected set; }
        public bool Ignore { get; protected set; }
        public PropertyConfiguration()
        {
            ErrorsValidations = new ThrowErrorIf[0];
            IgnoreConditions = new Func<object, bool>[0];
            Ignore = false;
        }
        public delegate bool ThrowErrorIf(object entity, object property, out string message);
        public static ThrowErrorIf Convert<T,TProp>(Func<T, TProp, bool> action, Func<TProp, string> errorMessageFunc)
        {
            return (object entity, object property, out string message) =>
            {
                message = null;
                var hasError = action((T)entity, (TProp)property);
                if (hasError)
                    message = errorMessageFunc((TProp)property);
                return hasError;
            };
        }
    }
}
