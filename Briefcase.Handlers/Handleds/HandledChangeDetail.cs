using Briefcase.Handlers.Handleds.Interfaces;
using System.Reflection;

namespace Briefcase.Handlers.Handleds
{
    internal class HandledChangeDetail : HandledDetail,
        IHandledChange
    {
        public object LastValue { get; }

        public HandledChangeDetail(PropertyInfo property, object value, object originalValue, object lastValue)
            : base(property, value, originalValue)
        {
            LastValue = lastValue;
        }
    }
}
