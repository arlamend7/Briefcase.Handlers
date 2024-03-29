﻿using Briefcase.Handlers.Handleds.Enums;
using Briefcase.Handlers.Handleds.Interfaces;
using System.Reflection;

namespace Briefcase.Handlers.Handleds
{
    internal class HandledMessagedDetail : IHandledMessaged
    {
        public PropertyInfo Property { get; }
        public object Value { get; }
        public HandledStopStageEnum StopedStage { get; }
        public object OriginalValue { get; }

        public string Message { get; }

        public HandledMessagedDetail(PropertyInfo property, object value, HandledStopStageEnum stopedStage, object originalValue, string message)
        {
            Property = property;
            Value = value;
            StopedStage = stopedStage;
            OriginalValue = originalValue;
            Message = message;
        }
    }
}
