using Briefcase.Handlers.Handleds.Interfaces;
using Briefcase.Handlers.Operations.Base.Interfaces;
using Briefcase.System.Asyncronuos;
using Briefcase.System.Asyncronuos.Interfaces;
using Briefcase.System.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Briefcase.Handlers.Operations.Base
{
    internal abstract class HandlerResult<T> : 
        IDisposable,
        IHandlerResult<T>
    {
        public IEnumerable<PropertyInfo> EditedProperties => dictionary.Keys;

        protected T Entity { get; set; }
        protected Dictionary<PropertyInfo, IResultAsyncCreator<IHandled>> dictionary;
        protected Dictionary<PropertyInfo, object> propertyStartValues;

        public HandlerResult(T entity)
        {
            Entity = entity;
            dictionary = new Dictionary<PropertyInfo, IResultAsyncCreator<IHandled>>();
            propertyStartValues = new Dictionary<PropertyInfo, object>();
        }
        public IResultAsync<IHandled> For<TProp>(Expression<Func<T, TProp>> expression)
        {
            var property = typeof(T).GetProperty(expression.GetMemberName());
            return For(property);
        }
        public IResultAsync<IHandled> For(PropertyInfo property)
        {
            if (dictionary.TryGetValue(property, out var result))
            {
                return result;
            }
            return null;
        }

        public IResultAsync<IHandled> For(string property)
        {
            if (dictionary.TryGetValue(typeof(T).GetProperty(property), out var result))
            {
                return result;
            }
            return null;
        }

        protected void Add(PropertyInfo propertyInfo, Func<IHandled> func)
        {
            if (dictionary.TryGetValue(propertyInfo, out IResultAsyncCreator<IHandled> result))
            {
                result.Prepend(func);
            }
            else
            {
                IResultAsyncCreator<IHandled> resultAsync = ResultAsync<IHandled>.Create();
                resultAsync.Prepend(func);
                dictionary.Add(propertyInfo, resultAsync);
            }
        }
        protected void Add(PropertyInfo propertyInfo, IHandled handled)
        {
            if (dictionary.TryGetValue(propertyInfo, out IResultAsyncCreator<IHandled> result))
            {
                result.Prepend(handled);
            }
            else
            {
                IResultAsyncCreator<IHandled> resultAsync = ResultAsync<IHandled>.Create();
                resultAsync.Prepend(handled);
                dictionary.Add(propertyInfo, resultAsync);
            }
        }

        public virtual void Dispose()
        {
            dictionary = new Dictionary<PropertyInfo, IResultAsyncCreator<IHandled>>();
            propertyStartValues = new Dictionary<PropertyInfo, object>();
        }
    }
}