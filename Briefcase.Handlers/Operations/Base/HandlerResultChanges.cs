using Briefcase.Handlers.Handleds.Interfaces;
using Briefcase.Handlers.Operations.Base.Interfaces;
using Briefcase.Handlers.Handleds;
using Briefcase.System.Asyncronuos.Interfaces;
using Briefcase.System.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Briefcase.Handlers.Operations.Base
{
    internal abstract class HandlerResultChanges<T>
        : HandlerResult<T>,
        IHandlerResultChanges<T>
    {

        protected HandlerResultChanges(T entity) : base(entity)
        {

        }

        public IHandledChange GetChangeFor(string propertyName)
        {
            var property = typeof(T).GetProperty(propertyName);
            if (property is null)
                return null;
            return GetChangeFor(property);
        }

        public IHandledChange GetChangeFor(PropertyInfo property)
        {
            if (dictionary.TryGetValue(property, out var result))
            {
                return JoinChangeDetail(new KeyValuePair<PropertyInfo, IResultAsync<IHandled>>(property, result));
            }
            return null;
        }

        public IHandledChange GetChangeFor<TProp>(Expression<Func<T, TProp>> expression)
        {
            var property = typeof(T).GetProperty(expression.GetMemberName());
            return GetChangeFor(property);
        }

        private IHandledChange JoinChangeDetail(KeyValuePair<PropertyInfo, IResultAsync<IHandled>> item)
        {
            var handledChange = item.Value.FirstOrDefault(x => x.ChangedProperty) as IHandledChange;
            if (handledChange != null)
            {
                return new HandledChangeDetail(item.Key, handledChange.Value, handledChange.OriginalValue, propertyStartValues.GetValueOrDefault(item.Key));
            }
            return null;
        }
    }
}