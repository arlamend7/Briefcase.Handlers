using Case.Handlers.Builder.Interfaces;
using Case.Handlers.Configurations;
using Case.System.Builders;
using Case.System.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Case.Handlers.Builder
{
    public class PropertyMapperBuilder
                 : BuilderOf<PropertyMapperConfiguration>
    {
        public bool Conclude => true;

        public PropertyMapperBuilder SetMappedType(Type type)
        {
            EditOn(x => x.MappedType, type);
            return this;
        }
        public PropertyMapperBuilder SetProperty(PropertyInfo property)
        {
            EditOn(x => x.Property, property);
            EditOn(x => x.MappedProperty, property);
            return this;
        }

        public PropertyMapperBuilder IgnoreDefaultValue(bool ignore = false)
        {
            if (ignore)
            {
                EditOn(x => x.IgnoreConditions, Value.IgnoreDefaultValueFunc);
            }
            return this;
        }
    }
    public class PropertyMapperBuilder<T, TRequest, TProp>
        : PropertyMapperBuilder,
        IPropertyMapperBuilder<T, TRequest, TProp>
    {

        protected override void OnInstanciate(PropertyMapperConfiguration Value)
        {
            EditOn(x => x.MappedType, typeof(TRequest));
        }

        public PropertyMapperBuilder<T, TRequest, TProp> SetProperty(Expression<Func<T, TProp>> expression)
        {
            var property = typeof(T).GetProperty(expression.GetMemberName());
            EditOn(x => x.Property, property);
            return this;
        }


        public bool Ignore()
        {
            EditOn(x => x.Ignored, true);
            return true;
        }

        public IPropertyMapperConvertBuilder<T, TProp, TRequest, TProp> MapFrom(Expression<Func<TRequest, TProp>> getValue)
        {
            EditOn(x => x.MappedProperty, typeof(TRequest).GetProperty(getValue.GetMemberName()));
            return new PropertyMapperConvertBuilder<T, TProp, TRequest, TProp>(this);
        }
        public IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp> MapFrom<TRequestProp>(Expression<Func<TRequest, TRequestProp>> getValue)
        {
            EditOn(x => x.MappedProperty, typeof(TRequest).GetProperty(getValue.GetMemberName()));
            return new PropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp>(this);
        }

        public IPropertyMapperBuilder<TProp> IgnoreValue(TProp ignoredValue, string message = null)
        {
            EditOn(x => x.MappedProperty, typeof(TRequest).GetProperty(Value.Property.Name));
            EditOn(x => x.IgnoreConditions, PropertyMapperConfiguration.ConvertToIgnore<TProp>((x) => (x == null && ignoredValue == null) || ignoredValue.Equals(x), (x) => message));
            return this;
        }

        public IPropertyMapperBuilder<TProp> IgnoreDefaultValue(string message = null)
        {
            EditOn(x => x.MappedProperty, typeof(TRequest).GetProperty(Value.Property.Name));
            EditOn(x => x.IgnoreConditions, Value.IgnoreDefaultValueFuncMessage<TProp>((x) => message));
            return this;
        }

        public bool MapExactlyFrom(Expression<Func<TRequest, TProp>> getValue)
        {
            EditOn(x => x.MappedProperty, typeof(TRequest).GetProperty(getValue.GetMemberName()));
            return true;
        }
    }
    public class PropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp>
        : BuilderOf<PropertyMapperConfiguration>,
        IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp>
    {
        public PropertyMapperConvertBuilder(BuilderOf<PropertyMapperConfiguration> builder) : base(builder)
        {
        }

        public IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp> IgnoreIf(Func<TRequestProp, bool> ignoreCondition, string message = null)
        {
            EditOn(x => x.IgnoreConditions, PropertyMapperConfiguration.ConvertToIgnore<TRequestProp>((prop) => ignoreCondition(prop), (x) => message));
            return this;
        }

        public IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp> IgnoreDefaultValue(string message = null)
        {
            EditOn(x => x.IgnoreConditions, Value.IgnoreDefaultValueFuncMessage<TRequestProp>((x) => message));
            return this;
        }
        public IPropertyMapperConvertBuilderConverted<T, TAnotherType, TAnotherType, TProp> ConvertUsing<TAnotherType>(Func<TRequestProp, TAnotherType> converter, string errorMessage = null)
        {
            EditOn(x => x.Converters, PropertyMapperConfiguration.ConvertToConvert(converter, (x) => errorMessage));
            return new PropertyMapperConvertBuilder<T, TProp, TAnotherType, TAnotherType>(this);       
        }

        public IPropertyMapperConvertBuilderConverted<T, TAnotherType, TAnotherType, TProp> ConvertUsing<TAnotherType>(Func<TRequestProp, TAnotherType> converter, Func<TRequestProp, string> message)
        {
            EditOn(x => x.Converters, PropertyMapperConfiguration.ConvertToConvert(converter, message));
            return new PropertyMapperConvertBuilder<T, TProp, TAnotherType, TAnotherType>(this);
        }


        public IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp> IgnoreIf(Func<TRequestProp, bool> ignoreCondition, Func<TRequestProp, string> messageFunc)
        {
            EditOn(x => x.IgnoreConditions, PropertyMapperConfiguration.ConvertToIgnore((prop) => ignoreCondition(prop), messageFunc));
            return this;
        }

        public bool ConvertUsing(Func<TRequestProp, TProp> converter, string message)
        {
            EditOn(x => x.Converters, PropertyMapperConfiguration.ConvertToConvert(converter, (x) => message));
            return true;
        }

        public bool ConvertUsing(Func<TRequestProp, TProp> converter, Func<TRequestProp, string> message)
        {
            EditOn(x => x.Converters, PropertyMapperConfiguration.ConvertToConvert(converter, message));
            return true;
        }

        public IPropertyMapperConvertBuilderConverted<T, TAnotherType, TAnotherType, TProp> ConvertUsing<TAnotherType>(System.Delegates.TryConvert<TRequestProp, TAnotherType> converter, Func<TRequestProp, string> message)
        {
            EditOn(x => x.Converters, PropertyMapperConfiguration.ConvertToConvert(converter, message));
            return new PropertyMapperConvertBuilder<T, TProp, TAnotherType, TAnotherType>(this);
        }

        public IPropertyMapperConvertBuilderConverted<T, TAnotherType, TAnotherType, TProp> ConvertUsing<TAnotherType>(System.Delegates.TryConvert<TRequestProp, TAnotherType> converter, string message)
        {
            EditOn(x => x.Converters, PropertyMapperConfiguration.ConvertToConvert(converter, (x) => message));
            return new PropertyMapperConvertBuilder<T, TProp, TAnotherType, TAnotherType>(this);        }
    }
}
