using Briefcase.Handlers.Handleds.Interfaces;
using Briefcase.Handlers.Operations.Base.Interfaces;
using Briefcase.System.Reflections;
using Briefcase.System.Reflections.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Briefcase.Handlers.Operations.Base
{
    internal abstract class HandlerResultOrdenableChanges<T> : HandlerResultChanges<T>, IHandlerResultOrdenableChanges<T>
                where T : class, new()

    {
        public IEnumerable<IHandled> Values => OrdernedValues();
        public IEnumerable<IHandledChange> Changes => GetOrderOfExecution().Select(GetChangeFor);
        public int ExecutedLength => dictionary.Sum(x => x.Value.ExecutedLength);
        public int NotExecutedLength => dictionary.Sum(x => x.Value.NotExecutedLength);
        public int ManuallyValuesAdded => dictionary.Sum(x => x.Value.ManuallyValuesAdded);
        public IEnumerable<PropertyInfo> Order => GetOrderOfExecution();

        private List<PropertyInfo> ExectutionOrderned;
        public HandlerResultOrdenableChanges(T entity) : base(entity)
        {

        }

        protected IEnumerable<IHandled> OrdernedValues()
        {
            return Order.SelectMany(For);
        }

        protected IEnumerable<PropertyInfo> GetOrderOfExecution()
        {
            var lastIndex = EditedProperties.Count() + 1;
            return ExectutionOrderned != null ? 
                EditedProperties.OrderBy(x => OrderOfExecution(x, lastIndex))
                : EditedProperties;
        }

        private int OrderOfExecution(PropertyInfo property, int lastIndex)
        {
            int index = ExectutionOrderned.IndexOf(property);
            if (index == -1)
                return lastIndex;
            return index;
        }

        public void OrderBy(Action<IPropertyGetter<T>> getterFunc)
        {
            using var getter = new PropertyGetter<T>();
            getterFunc(getter);
            OrderBy(getter.ToArray());
        }
        public void OrderBy(params string[] properties)
        {
            OrderBy(properties.Select(x => typeof(T).GetProperty(x)).ToArray());
        }

        public void OrderBy<TProp>(Func<PropertyInfo, TProp> properties)
        {
            ExectutionOrderned = EditedProperties.OrderBy(properties).ToList();
        }

        public void OrderBy(params PropertyInfo[] properties)
        {
            ExectutionOrderned = properties.ToList();
        }

        public IEnumerator<IHandled> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        public new virtual void Dispose()
        {
            base.Dispose();
            ExectutionOrderned = null;
        }
    }
}