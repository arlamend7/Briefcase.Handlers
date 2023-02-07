using Case.Handlers.Handleds.Interfaces;
using Case.Handlers.Operations.Base.Interfaces;
using Case.System.Reflections;
using Case.System.Reflections.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Case.Handlers.Operations.Base
{
    public abstract class EditResultOrdenableChanges<T> : EditResultChanges<T>, IEditResultOrdenableChanges<T>
    {
        public IEnumerable<IHandled> Values => OrdernedValues();
        public IEnumerable<IHandledChange> Changes => GetOrderOfExecution().Select(GetChangeFor);
        public int ExecutedLength => dictionary.Sum(x => x.Value.ExecutedLength);
        public int NotExecutedLength => dictionary.Sum(x => x.Value.NotExecutedLength);
        public int ManuallyValuesAdded => dictionary.Sum(x => x.Value.ManuallyValuesAdded);
        public IEnumerable<PropertyInfo> ExecutionOrder => GetOrderOfExecution();

        private List<PropertyInfo> ExectutionOrderned;
        public EditResultOrdenableChanges(T entity) : base(entity)
        {

        }

        protected IEnumerable<IHandled> OrdernedValues()
        {
            return ExecutionOrder.SelectMany(ForProperty);
        }

        protected IEnumerable<PropertyInfo> GetOrderOfExecution()
        {
            var lastIndex = EditedProperties.Count() + 1;
            return EditedProperties.OrderBy(x => OrderOfExecution(x, lastIndex));
        }

        private int OrderOfExecution(PropertyInfo property, int lastIndex)
        {
            var index = ExectutionOrderned.IndexOf(property);
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
            ExectutionOrderned.Clear();
        }
    }
}