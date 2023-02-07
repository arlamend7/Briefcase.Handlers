using Case.Handlers.Handleds.Interfaces;
using Case.System.Asyncronuos;
using Case.System.Asyncronuos.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Case.Handlers.Operations.Base
{
    public abstract class EditResult<T> : IDisposable
    {
        protected T Entity { get; set; }
        protected Dictionary<PropertyInfo, IResultAsyncCreator<IHandled>> dictionary;
        protected Dictionary<PropertyInfo, object> propertyStartValues;

        public EditResult(T entity)
        {
            Entity = entity;
            dictionary = new Dictionary<PropertyInfo, IResultAsyncCreator<IHandled>>();
            propertyStartValues = new Dictionary<PropertyInfo, object>();
        }

        protected void Add(PropertyInfo propertyInfo, Func<IHandled> func)
        {
            if (dictionary.TryGetValue(propertyInfo, out IResultAsyncCreator<IHandled> result))
            {
                result.Add(func);
            }
            else
            {
                IResultAsyncCreator<IHandled> resultAsync = ResultAsync<IHandled>.Create();
                resultAsync.Add(func);
                dictionary.Add(propertyInfo, resultAsync);
            }
        }
        protected void Add(PropertyInfo propertyInfo, IHandled handled)
        {
            if (dictionary.TryGetValue(propertyInfo, out IResultAsyncCreator<IHandled> result))
            {
                result.Add(handled);
            }
            else
            {
                IResultAsyncCreator<IHandled> resultAsync = ResultAsync<IHandled>.Create();
                resultAsync.Add(handled);
                dictionary.Add(propertyInfo, resultAsync);
            }
        }

        public virtual void Dispose()
        {
            foreach (var item in dictionary)
            {
                item.Value.Dispose();
            }
            dictionary.Clear();
            propertyStartValues.Clear();
        }
    }
}