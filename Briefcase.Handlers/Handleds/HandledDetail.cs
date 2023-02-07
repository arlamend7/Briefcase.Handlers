using Case.Handlers.Handleds.Enums;
using Case.Handlers.Handleds.Interfaces;
using System.Reflection;

namespace Case.Handlers.Handleds
{
    public class HandledDetail : IHandled
    {
        public PropertyInfo Property { get; }
        public object Value { get; }
        public HandledStopStageEnum StopedStage { get; }
        public object OriginalValue { get; }

        public HandledDetail(PropertyInfo property, object value, HandledStopStageEnum stopedStage, object originalValue)
        {
            Property = property;
            Value = value;
            StopedStage = stopedStage;
            OriginalValue = originalValue;
        }
        public HandledDetail(PropertyInfo property, object value, object originalValue)
        {
            Property = property;
            Value = value;
            StopedStage = HandledStopStageEnum.SetValue;
            OriginalValue = originalValue;
        }
    }
}
