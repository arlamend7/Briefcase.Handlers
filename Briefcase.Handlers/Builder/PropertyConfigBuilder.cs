using Case.Handlers.Builder.Interfaces;
using Case.Handlers.Configurations;
using Case.System.Builders;
using Case.System.Extensions;
using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Case.Handlers.Builder
{
    public class PropertyConfigBuilder<T> : BuilderOf<PropertyConfiguration>
    {
        public PropertyConfiguration BuildWith(PropertyInfo property)
        {
            var description = property.GetCustomAttribute<DescriptionAttribute>()?.Description;

            EditOn(x => x.PropertyInfo, property);
            EditOn(x => x.Description, description);
            return Value;
        }
    }
    public class PropertyConfigBuilder<T, TProp>
        : PropertyConfigBuilder<T>,
        
        IPropertyConfigBuilder<T, TProp>,
        IPropertyConfigInfoBuilder<T, TProp>,
        IPropertyConfigNoPropertyBuilder<T, TProp>
        where T : new()
    {

        public bool Ignore()
        {
            EditOn(x => x.Ignore, true);
            return true;
        }

        public IPropertyConfigInfoBuilder<T, TProp> ForMember(Expression<Func<T, TProp>> expression, string description = null)
        {
            var property = typeof(T).GetProperty(expression.GetMemberName());
            description ??= property.GetCustomAttribute<DescriptionAttribute>()?.Description;

            EditOn(x => x.PropertyInfo, property);
            EditOn(x => x.Description, description);
            return this;
        }
        public IPropertyConfigBuilder<T, TProp> ThrowErrorIf(Func<T, TProp, bool> action, string errorMessage = null)
        {
            return ThrowErrorIf(action, (x) => errorMessage);
        }

        public IPropertyConfigBuilder<T, TProp> ThrowErrorIfValue(Func<TProp, bool> action, string errorMessage = null)
        {
            Func<T, TProp, bool> actionIngoreEntity = (entity, prop) => action(prop);
            return ThrowErrorIf(actionIngoreEntity, errorMessage);
        }

        public IPropertyConfigBuilder<T, TProp> ThrowErrorIfValueIs(TProp value, string errorMessage = null)
        {
            Func<T, TProp, bool> thowErrorFun = (entity, prop) => (value == null && prop == null) || value.Equals(prop);
            return ThrowErrorIf(thowErrorFun, errorMessage);
        }

        public IPropertyConfigBuilder<T, TProp> ThrowErrorIf(Func<T, TProp, bool> action, Func<TProp, string> errorMessageFunc = null)
        {
            return ThrowErrorIf(PropertyConfiguration.Convert(action, errorMessageFunc));
        }

        public IPropertyConfigBuilder<T, TProp> ThrowErrorIfValue(Func<TProp, bool> action, Func<TProp, string> errorMessageFunc = null)
        {
            Func<T, TProp, bool> actionIngoreEntity = (entity, prop) => action(prop);
            return ThrowErrorIf(actionIngoreEntity, errorMessageFunc);
        }

        private IPropertyConfigBuilder<T, TProp> ThrowErrorIf(PropertyConfiguration.ThrowErrorIf throwErrorFunc)
        {
            EditOn(x => x.ErrorsValidations, throwErrorFunc);
            return this;
        }

        public IPropertyConfigBuilder<T, TProp> FormatAfterChanged(Func<TProp, TProp> propFormatter)
        {
            EditOn(x => x.Formatter, (x) => propFormatter((TProp)x));
            return this;
        }

        public IPropertyConfigBuilder<T, TProp> IgnoreIfValueIs(TProp value)
        {
            Func<object, bool> ignoreValue = (x) => (value == null && x == null) || value.Equals(x);
            EditOn(x => x.IgnoreConditions, ignoreValue);
            return this;
        }

        public IPropertyConfigBuilder<T, TProp> IgnoreIf(Func<TProp, bool> ignore)
        {
            Func<object, bool> ignoreCondition = (x) => ignore((TProp)x);
            EditOn(x => x.IgnoreConditions, ignoreCondition);
            return this;
        }
    }
}
