using Briefcase.Handlers.Handleds.Interfaces;
using Briefcase.Handlers.Operations.Base.Interfaces;
using Briefcase.System.Reflections;
using Briefcase.System.Reflections.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Briefcase.Handlers.Operations.Base
{
    internal abstract class HandlerResultTimeLiner<T> : HandlerResultOrdenableChanges<T>, IHandlerResultTimeLiner<T>
                where T : class, new()

    {
        public T Result => GetResultFor(Changes);
        public HandlerResultTimeLiner(T entity) : base(entity)
        {
        }

        public T GetResultFor(params string[] properties)
        {
            return GetResultFor(properties.Select(x => typeof(T).GetProperty(x)).ToArray());
        }

        public T GetResultFor(Action<IPropertyGetter<T>> getterFunc)
        {
            using var getter = new PropertyGetter<T>();
            getterFunc(getter);
            return GetResultFor(getter.ToArray());
        }

        public T GetResultFor(params PropertyInfo[] properties)
        {
            return GetResultFor(properties.Select(GetChangeFor));
        }
        public T GetResultFor(IEnumerable<IHandledChange> changes)
        {
            changes = changes.Where(x => x != null);
            foreach (IHandledChange change in changes)
            {
                change.Property.SetValue(Entity, change.Value);
            }

            var propertiesChanged = changes.Select(x => x.Property);

            foreach (KeyValuePair<PropertyInfo, object> propertyStart in propertyStartValues.Where(x => IsToSetDefaultValue(propertiesChanged, x.Key)))
            {
                propertyStart.Key.SetValue(Entity, propertyStart.Value);
            }
            return Entity;
        }

        private bool IsToSetDefaultValue(IEnumerable<PropertyInfo> propertiesChanged, PropertyInfo propertyInfo)
        {
            return !propertiesChanged.Any(x => x == propertyInfo);
        }
    }
}