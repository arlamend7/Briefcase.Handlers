using Case.Handlers.Handleds;
using Case.Handlers.Handleds.Interfaces;
using Case.Handlers.Operations.Base.Interfaces;
using Case.System.Asyncronuos.Interfaces;
using Case.System.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Case.Handlers.Operations.Base
{
    public abstract class EditResultChanges<T> 
        : EditResult<T>, 
        IEditResultChanges<T>
    {
        public IEnumerable<PropertyInfo> EditedProperties => dictionary.Keys;
        protected EditResultChanges(T entity) : base(entity)
        {
        }

        public IEnumerable<IHandled> ForProperty<TProp>(Expression<Func<T, TProp>> expression)
        {
            var property = typeof(T).GetProperty(expression.GetMemberName());
            return ForProperty(property);
        }
        public IEnumerable<IHandled> ForProperty(PropertyInfo property)
        {
            if (dictionary.TryGetValue(property, out var result))
            {
                return result;
            }
            return new IHandled[0];
        }

        public IHandledChange GetChangeFor(PropertyInfo property)
        {
            if (dictionary.TryGetValue(property, out var result))
            {
                return JoinChangeDetail(new KeyValuePair<PropertyInfo, IResultAsyncCreator<IHandled>>(property, result));
            }
            return null;
        }
        public IHandledChange GetChangeFor<TProp>(Expression<Func<T, TProp>> expression)
        {
            var property = typeof(T).GetProperty(expression.GetMemberName());
            return GetChangeFor(property);
        }

        private IHandledChange JoinChangeDetail(KeyValuePair<PropertyInfo, IResultAsyncCreator<IHandled>> item)
        {
            var values = item.Value.Where(x => x.ChangedProperty).Select(x => x as IHandledChange);
            if (values.Any())
            {
                return new HandledChangeDetail(item.Key, values.Last().Value, values.Last().OriginalValue, values.First().LastValue);
            }
            return null;
        }
    }
}