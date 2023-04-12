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
        IHandlerResult<T>
        where T : class, new()
    {
        public IEnumerable<PropertyInfo> EditedProperties => dictionary.Keys;

        protected T Entity { get; set; }
        protected IDictionary<PropertyInfo, IInteractableCreator<IHandled>> dictionary;
        protected IDictionary<PropertyInfo, object> propertyStartValues;

        public HandlerResult(T entity)
        {
            Entity = entity;
            dictionary = new Dictionary<PropertyInfo, IInteractableCreator<IHandled>>();
            propertyStartValues = new Dictionary<PropertyInfo, object>();
        }
        public IInteractable<IHandled> For<TProp>(Expression<Func<T, TProp>> expression)
        {
            var property = typeof(T).GetProperty(expression.GetMemberName());
            return For(property);
        }
        public IInteractable<IHandled> For(PropertyInfo property)
        {
            if (property is null)
                return null;

            return dictionary[property];
        }

        public IInteractable<IHandled> For(string propertyName)
        {
            return For(typeof(T).GetProperty(propertyName));
        }

        protected void Add(PropertyInfo propertyInfo, Func<IHandled> func)
        {
            if (dictionary.TryGetValue(propertyInfo, out IInteractableCreator<IHandled> result))
            {
                result.Prepend(func);
            }
            else
            {
                IInteractableCreator<IHandled> resultAsync = Interactable<IHandled>.Create();
                resultAsync.Prepend(func);
                dictionary[propertyInfo] = resultAsync;
            }
        }
        protected void Add(PropertyInfo propertyInfo, IHandled handled)
        {
            if (dictionary.TryGetValue(propertyInfo, out IInteractableCreator<IHandled> result))
            {
                result.Prepend(handled);
            }
            else
            {
                IInteractableCreator<IHandled> resultAsync = Interactable<IHandled>.Create();
                resultAsync.Prepend(handled);
                dictionary[propertyInfo] =  resultAsync;
            }
        }

        public virtual void Dispose()
        {
            Entity = new T();
            dictionary = new Dictionary<PropertyInfo, IInteractableCreator<IHandled>>();
            propertyStartValues = new Dictionary<PropertyInfo, object>();
        }
    }
}