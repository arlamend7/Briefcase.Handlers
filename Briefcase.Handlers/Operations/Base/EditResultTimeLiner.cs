using Case.Handlers.Handleds.Interfaces;
using Case.Handlers.Operations.Base.Interfaces;
using Case.System.Asyncronuos.Interfaces;
using Case.System.Reflections;
using Case.System.Reflections.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Case.Handlers.Operations.Base
{
    public abstract class EditResultTimeLiner<T> : EditResultOrdenableChanges<T>, IEditResultTimeLiner<T>
    {
        public T ResultEntity => GetResultEntityFor(Changes);
        public EditResultTimeLiner(T entity) : base(entity)
        {
            dictionary = new Dictionary<PropertyInfo, IResultAsyncCreator<IHandled>>();
        }

        public T GetResultEntityFor(params string[] properties)
        {
            return GetResultEntityFor(properties.Select(x => typeof(T).GetProperty(x)).ToArray());
        }

        public T GetResultEntity(Action<IPropertyGetter<T>> getterFunc)
        {
            using var getter = new PropertyGetter<T>();
            getterFunc(getter);
            return GetResultEntityFor(getter.ToArray());
        }

        public T GetResultEntityFor(params PropertyInfo[] properties)
        {
            return GetResultEntityFor(properties.Select(GetChangeFor));
        }
        public T GetResultEntityFor(IEnumerable<IHandledChange> changes)
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