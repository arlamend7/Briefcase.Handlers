using Briefcase.Handlers.Builder.Interfaces;
using Briefcase.Handlers.Configurations;
using Briefcase.System.Builders;
using Briefcase.System.Extensions;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Briefcase.Handlers.Builder
{
    internal class PropertyConfigurationBuilder<T> : BuilderOf<PropertyConfiguration>
    {

        public PropertyConfigurationBuilder<T> ForMember(string propertyName, string description = null)
        {
            var property = typeof(T).GetProperty(propertyName);
            description ??= property.GetCustomAttribute<DescriptionAttribute>()?.Description;

            EditOn(x => x.PropertyInfo, property);
            EditOn(x => x.Description, description);
            return this;
        }

        public bool Ignore()
        {
            EditOn(x => x.Ignore, true);
            return true;
        }

        public PropertyConfiguration BuildWith(PropertyInfo property)
        {
            var description = property.GetCustomAttribute<DescriptionAttribute>()?.Description;

            EditOn(x => x.PropertyInfo, property);
            EditOn(x => x.Description, description);
            return Value;
        }
    }
    internal class PropertyConfigurationBuilder<T, TProp>
        : PropertyConfigurationBuilder<T>,

        IPropertyConfigBuilder<T, TProp>,
        IPropertyConfigInfoBuilder<T, TProp>,
        IPropertyConfigNoPropertyBuilder<T, TProp>
        where T : new()
    {
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
            Func<T, TProp, bool> thowErrorFun = (entity, prop) => (value == null && prop == null) || prop == null || prop.Equals(value);
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
            Func<object, object, bool> ignoreValue = (entity, x) => value == null && x == null || value.Equals(x);
            EditOn(x => x.IgnoreConditions, ignoreValue);
            return this;
        }

        public IPropertyConfigBuilder<T, TProp> IgnoreIf(Func<TProp, bool> ignore)
        {
            Func<object, object, bool> ignoreCondition = (entity, x) => ignore((TProp)x);
            EditOn(x => x.IgnoreConditions, ignoreCondition);
            return this;
        }

        public IPropertyConfigBuilder<T, TProp> IgnoreIf(Func<T, TProp, bool> ignore)
        {
            Func<object, object, bool> ignoreCondition = (entity, x) => ignore((T)entity, (TProp)x);
            EditOn(x => x.IgnoreConditions, ignoreCondition);
            return this;
        }
    }
}
